using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{


    /// <summary>
    /// return the Sha256 of the value
    /// </summary>
    [DisplayName("sha256")]
    public class ServiceSha256 : ITransformJsonService
    {

        public ServiceSha256()
        {

        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {

                using (SHA256 mySHA256 = SHA256.Create())
                using (MemoryStream stream = new MemoryStream())
                {

                    var buffer = System.Text.Encoding.UTF8.GetBytes(token.ToString());
                    stream.Write(buffer, 0, buffer.Length);

                    byte[] hashValue = mySHA256.ComputeHash(stream);
                    return new JValue(hashValue.PrintByteArray());
                }

            }

            return new JValue(string.Empty);

        }

     
    }

}
