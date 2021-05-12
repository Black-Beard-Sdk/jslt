using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return the Sha512 of the value
    /// </summary>
    [DisplayName("sha512")]
    public class ServiceSha512 : ITransformJsonService
    {

        public ServiceSha512()
        {

        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {

                var data = System.Text.Encoding.UTF8.GetBytes(token.ToString());
                SHA512 shaM = new SHA512Managed();
                var hashValue = shaM.ComputeHash(data);
                return new JValue(hashValue.PrintByteArray());

            }

            return new JValue(string.Empty);

        }

    }

}
