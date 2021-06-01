using Newtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public abstract class ESerialize
    {

        public abstract JToken Serialize();


        public override string ToString()
        {
            return Serialize().ToString(Newtonsoft.Json.Formatting.None);
        }

    }

}