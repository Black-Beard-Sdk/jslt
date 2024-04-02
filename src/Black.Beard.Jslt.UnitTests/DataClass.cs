using Bb.Contracts;
using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;

namespace Black.Beard.Jslt.UnitTests
{

    public class DataClass : ITransformJsonService
    {

        public DataClass(double id1, string id2)
        {
            this.Id1 = id1;
            this.Id2 = id2;
        }

        public double Id1 { get; set; }

        public string Id2 { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken source)
        {

            return new JObject(
                    new JProperty("Uuid", new JValue(Id1))
                );

        }

    }

}