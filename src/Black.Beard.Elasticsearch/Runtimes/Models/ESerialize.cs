using Oldtonsoft.Json.Linq;

namespace Bb.Elastic.Runtimes.Models
{

    public abstract class ESerialize
    {

        public abstract JToken Serialize();


        public override string ToString()
        {
            return Serialize().ToString(Oldtonsoft.Json.Formatting.None);
        }

    }

}