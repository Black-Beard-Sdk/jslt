using Newtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class EBool : ESerialize
    {


        public EMust Must { get; set; }
        public EFilter Filter { get; set; }


        public override JToken Serialize()
        {

            var r = new JObject();

            if (this.Must != null)
                r.Add(new JProperty("must", this.Must.Serialize()));

            if (this.Filter != null)
                r.Add(new JProperty("filter", this.Filter.Serialize()));

            return r;

        }
    }

}