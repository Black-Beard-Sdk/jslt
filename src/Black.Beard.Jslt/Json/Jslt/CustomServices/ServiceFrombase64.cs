using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return the string from value
    /// </summary>
    [DisplayName("frombase64")]
    public class ServiceFrombase64 : ITransformJsonService
    {

        public ServiceFrombase64()
        {

        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {
                var d2 = Convert.FromBase64String(token.ToString());
                var data = System.Text.Encoding.UTF8.GetString(d2);
                return new JValue(data);

            }

            return new JValue(string.Empty);

        }

    }
}
