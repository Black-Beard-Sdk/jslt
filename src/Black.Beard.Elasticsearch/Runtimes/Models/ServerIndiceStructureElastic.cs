using Elasticsearch.Net;
using Newtonsoft.Json.Linq;
using System;

namespace Bb.Elastic.Runtimes.Models
{

    public class ServerIndiceStructureElastic
    {

        public ServerIndiceStructureElastic(ElasticLowLevelClient client)
        {
            this._client = client;
            this.Fields = new ServerFieldsStructure();
        }

        public string Indice { get; set; }


        private readonly ElasticLowLevelClient _client;

        public virtual JObject Serialize()
        {

            var result = new JObject()
            {
                new JProperty("Name", Indice),
            };

            if (this.Fields != null)
                result.Add(new JProperty("Fields", this.Fields.Serialize()));

            return result;

        }

        public void Deserialize(JObject o)
        {

            var Indice = o["Name"].Value<string>();
            var f = o["Fields"].Value<JArray>();
            Fields.Deserialize(f);
        }

        public ServerFieldsStructure Fields { get; set; }

    }



}