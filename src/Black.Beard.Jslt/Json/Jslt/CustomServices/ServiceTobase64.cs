using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return the value in base 64 format
    /// </summary>
    [DisplayName("tobase64")]
    public class ServiceTobase64 : ITransformJsonService
    {

        public ServiceTobase64()
        {

        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {
                var data = System.Text.Encoding.UTF8.GetBytes(token.ToString());
                return new JValue(Convert.ToBase64String(data));
            }

            return new JValue(string.Empty);

        }

    }
}
