using Elasticsearch.Net;
using Newtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class ECall
    {

        public ESpecification Query { get; set; }
        public string Index { get; set; }
        public Connection Connection { get; set; }


        public Result<TResponse> ExecuteQuery<TResponse>(ContextExecutor ctx)
             where TResponse : class, IElasticsearchResponse, new()
        {
            return (Result<TResponse>)this.Connection.ExecuteQuery<TResponse>(ctx, this);
        }

        internal JToken GetQuery()
        {

            return Query.Serialize();

        }

        public override string ToString()
        {
            return Index + " --> " + Query.ToString();
        }

    }

}