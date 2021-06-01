using Newtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class ETerm : ESerialize
    {

        public ETerm()
        {
        }

        public string Name { get; set; }

        public object value { get; set; }

        public override JToken Serialize()
        {

            var v = value;
            if (value is ESerialize s)
                v = s.Serialize();

            return new JObject()
            {
                new JProperty("term", new JObject() { new JProperty(Name, v) }),
            };

        }

    }

}