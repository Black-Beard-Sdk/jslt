using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;

namespace Bb.Json.Jslt.CustomServices
{


    
    public static class Services
    {

        /// <summary>
        /// return the crc32 of the value
        /// if one of the term is not a number
        /// </summary>
        [JsltExtensionMethod("crc32")]
        public static JToken ExecuteCrc32(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {

                var r = token.ToString();
                    return new JValue(Crc32.Calculate(r));

            }

            return new JValue(0);

        }


        /// <summary>
        /// return the current datetime
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="token"></param>
        /// <param name="utc"></param>
        /// <returns></returns>
        [JsltExtensionMethod("now")]
        public static JToken ExecuteNow(RuntimeContext ctx, JToken token, bool utc)
        {
            var n = utc ? DateTime.UtcNow : DateTime.Now;
            return new JValue(n);
        }

    }

}
