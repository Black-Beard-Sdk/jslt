using Bb.Elastic.Parser;
using Elasticsearch.Net;
using Elasticsearch.Net.Specification.CatApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Elastic.Runtimes.Models
{

    public class ElasticProcessor : ElasticAbstractProcessor
    {

        internal ElasticProcessor(string name, ElasticLowLevelClient client) : base(name)
        {
            this._client = client;


            this.callMethod = typeof(ElasticProcessor).GetMethod("Call", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        }

        public override Result ExecuteQuery<TResponse>(ContextExecutor ctx, object query)
        {

            string queryString = string.Empty;

            if (query is ECall ecall)
            {
                var q = ecall.GetQuery();
                queryString = q.ToString();

                Func<string, string, TResponse> tunedMethod = GettunedMethod<TResponse>();
                var response = tunedMethod(ecall.Index, queryString);

                return new Result<TResponse>()
                {
                    Request = new RequestQuery()
                    {
                        Query = q,
                        Connection = this,
                        Table = ecall.Index,

                    },

                    Datas = response
                };

            }

            return null;

        }

        public override RequestQuery Plane(ContextExecutor ctx, object query)
        {

            var ecall = query as ECall;
            var q = ecall.GetQuery();

            return new RequestQuery()
            {
                Query = q,
                Connection = this,
                Table = ecall.Index,
            };

        }

        

        protected override ServerTablesStructure ResolveCatalogue(ContextExecutor ctx)
        {

            var result = new ServerTablesStructure()
            {
                ConnectionName = this.ConnectionName,
            };
            
            result.Creator = () => new ServerTableStructureElastic(this._client, result);
            

            var filename = Path.Combine(ctx.WorkingSpace.FullName, $"{this.ConnectionName}.json");
            result.Filename = filename;

            if (File.Exists(filename))
            {

                var old = DateTime.UtcNow.Subtract(File.GetLastWriteTimeUtc(filename));
                if (old.TotalDays > 3)
                {
                    LoadRemoteDatas(result);
                    result.Save();
                }
                else
                    result.Load();

            }
            else
            {
                LoadRemoteDatas(result);
                result.Save();
            }

            return result;

        }

    

        private void LoadRemoteDatas(ServerTablesStructure result)
        {

            var requestAliasArgument = new CatAliasesRequestParameters() { Format = "json" };
            var o = this._client.Cat.Aliases<StringResponse>(requestAliasArgument);

            JArray array = JArray.Parse(o.Body);

            foreach (var item in array)
            {
                var tName = item["alias"].ToString();
                var table = (ServerTableStructureElastic)result.Add(tName);
                var indice = table.GetIndice(item["index"].ToString());
            }

        }

        private Func<string, string, TResponse> GettunedMethod<TResponse>() where TResponse : class, new()
        {

            var type = typeof(TResponse);
            if (!this._methods.TryGetValue(type, out object result))
            {

                var m = this.callMethod.MakeGenericMethod(typeof(TResponse));

                var arg1 = Expression.Parameter(typeof(string), "arg1");
                var arg2 = Expression.Parameter(typeof(string), "arg2");
                var lbd = Expression.Lambda<Func<string, string, TResponse>>(Expression.Call(Expression.Constant(this), m, arg1, arg2), arg1, arg2);

                result = lbd.Compile();
                _methods.Add(type, result);

            }

            return (Func<string, string, TResponse>)result;

        }

        private TResponse Call<TResponse>(string index, string query)
             where TResponse : class, IElasticsearchResponse, new()
        {
            return _client.Search<TResponse>(index, query);
        }


        private readonly ElasticLowLevelClient _client;
        private readonly MethodInfo callMethod;
        private Dictionary<Type, object> _methods = new Dictionary<Type, object>();
        

    }

    public class ElasticServerIndiceStructure
    {
        public string Indice { get; set; }

    }


}