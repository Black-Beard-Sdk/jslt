using Elasticsearch.Net;
using Elasticsearch.Net.Specification.IndicesApi;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Models
{
    public class ServerTableStructure
    {

        public ServerTableStructure(ElasticLowLevelClient client, ServerTablesStructure parent)
        {
            this._client = client;
            this._parent = parent;
        }

        public ServerFieldsStructure Fields(ContextExecutor ctx)
        {
            if (this._dic == null)
                this._dic = resolveStructure(ctx);
            return this._dic;
        }

        public ServerFieldStructure Field(string fieldName, ContextExecutor ctx)
        {
            if (this._dic == null)
                this._dic = resolveStructure(ctx);

            return this._dic[fieldName];

        }

        protected virtual ServerFieldsStructure resolveStructure(ContextExecutor ctx)
        {

            var result = new ServerFieldsStructure();



            return result;

        }

        public string TableName { get; set; }

        public virtual JObject Serialize()
        {
            var o = new JObject()
            {
                new JProperty("Name", TableName),
            };

            if (this._dic != null)
                o.Add(new JProperty("Fields", this._dic.Serialize()));

            return o;
        }

        public virtual void Deserialize(JObject o)
        {

            this.TableName = o["Name"].Value<String>();
            if (o.ContainsKey("Fields"))
            {
                var f = o["Fields"].Value<JArray>();
                _dic.Deserialize(f);
            }

        }


        protected readonly ElasticLowLevelClient _client;
        protected readonly ServerTablesStructure _parent;
        protected ServerFieldsStructure _dic;




    }
}