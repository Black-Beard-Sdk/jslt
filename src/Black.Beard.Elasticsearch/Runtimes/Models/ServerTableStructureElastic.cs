using Elasticsearch.Net;
using Elasticsearch.Net.Specification.IndicesApi;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bb.Elastic.Runtimes.Models
{

    public class ServerTableStructureElastic : ServerTableStructure
    {

        public ServerTableStructureElastic(ElasticLowLevelClient client, ServerTablesStructure parent)
            : base(client, parent)
        {
            this._items = new List<ServerIndiceStructureElastic>();
        }


        public ServerIndiceStructureElastic GetIndice(string key)
        {

            var resultIndice = _items.Where(c => c.Indice == key).FirstOrDefault();
            if (resultIndice == null)
                _items.Add(resultIndice = new ServerIndiceStructureElastic(this._client) { Indice = key });

            return resultIndice;

        }

        protected override ServerFieldsStructure resolveStructure(ContextExecutor ctx)
        {

            var b = base.resolveStructure(ctx);

            var requestMappingArgument = new GetMappingRequestParameters() { };
            var o2 = _client.Indices.GetMapping<StringResponse>(this.TableName, requestMappingArgument);
            JObject o = JObject.Parse(o2.Body);

            foreach (JProperty property1 in o.Properties())
            {

                var indice = property1.Name;
                var indiceObject = this.GetIndice(indice);

                JObject index1 = (JObject)property1.Value;
                JObject mappings = (JObject)index1["mappings"];
                JObject syslog = (JObject)mappings["syslog"];
                JObject properties = (JObject)syslog["properties"];

                foreach (JProperty property2 in properties.Properties())
                {
                    var propertyName = property2.Name.Trim('@');
                    JObject datas = (JObject)property2.Value;
                    string type = datas["type"].Value<string>();

                    var field = indiceObject.Fields.Add(propertyName, type);

                    JObject dataFields = (JObject)datas["fields"];
                    if (dataFields != null)
                    {
                        foreach (JProperty property3 in dataFields.Properties())
                        {

                            var propertyName2 = property3.Name;
                            var propertyValue = property3.Value;
                            switch (propertyName2)
                            {

                                case "keyword":

                                    break;

                                default:
                                    break;
                            }

                        }
                    }

                }

                b.Merge(indiceObject);

            }


            if (string.IsNullOrEmpty(this._parent.Filename))
                this._parent.Filename = Path.Combine(ctx.WorkingSpace.FullName, $"{this._parent.ConnectionName}.json");

            this._parent.Save();

            return b;

        }

    
        public override JObject Serialize()
        {

            var result = base.Serialize();
            var a = new JArray();
            result.Add(new JProperty("Indices", a));

            foreach (var item in this._items)
                a.Add( item.Serialize());

            return result;

        }

        public override void Deserialize(JObject o)
        {
            base.Deserialize(o);
            var a = o["Indices"].Value<JArray>();
            foreach (var item in a)
            {
                var i = new ServerIndiceStructureElastic(this._client);
                i.Deserialize(item as JObject);
                this._items.Add(i);
            }

        }



        private readonly List<ServerIndiceStructureElastic> _items;

    }


}