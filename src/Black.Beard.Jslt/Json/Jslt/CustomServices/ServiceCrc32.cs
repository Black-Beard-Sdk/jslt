using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Bb.Json.Jslt.CustomServices
{


    /// <summary>
    /// return the crc32 of the value
    /// if one of the term is not a number
    /// </summary>
    [DisplayName("crc32")]
    public class ServiceCrc32 : ITransformJsonService
    {

        public ServiceCrc32()
        {

        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {

                var r = token.ToString();
                    return new JValue(Crc32.Calculate(r));

            }

            return new JValue(0);

        }

    }

}
