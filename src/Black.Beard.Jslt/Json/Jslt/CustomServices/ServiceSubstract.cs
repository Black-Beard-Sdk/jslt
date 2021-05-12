using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Bb.Json.Jslt.CustomServices
{
    /// <summary>
    /// return the Left value substracted from Right value
    /// </summary>
    [DisplayName("substract")]
    public class ServiceSubstract : ITransformJsonService
    {

        public ServiceSubstract()
        {

        }

        public double Left { get; set; }

        public double Right { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            var value = Left - Right;
            var v = (int)value;

            if (v < value)
                return new JValue(value);

            return new JValue(v);

        }

    }



}
