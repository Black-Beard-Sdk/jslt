using Newtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class ServerFieldStructure
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }

        public virtual JObject Serialize()
        {

            var a = new JObject()
            {
                new JProperty("Name", Name),
                new JProperty("Type", Type),
            };

            return a;

        }

    }
}