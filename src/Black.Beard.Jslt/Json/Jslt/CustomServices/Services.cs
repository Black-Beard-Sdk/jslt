using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {

        [JsltExtensionMethod("loadjson")]
        public static JToken ExecuteLoadSource(RuntimeContext ctx, string sourcePath)
        {

            var file = ctx.Configuration.ResolveFile(sourcePath);

            if( file.Exists)
                return file.FullName.LoadContentFromFile().ConvertToJson();
            return JValue.CreateNull();
        }

        /// <summary>
        /// return the current datetime
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="token"></param>
        /// <param name="utc"></param>
        /// <returns></returns>
        [JsltExtensionMethod("now")]
        public static JToken ExecuteNow(RuntimeContext ctx, bool utc)
        {
            var n = utc ? DateTime.UtcNow : DateTime.Now;
            return new JValue(n);
        }

        [JsltExtensionMethod("sum")]
        public static JToken ExecuteSum(RuntimeContext ctx, JToken token)
        {

            double result = 0;
            if (token != null)
            {

                if (token is JArray a && a.Count > 0)
                {

                    foreach (var item in a)
                    {

                        if (item.Type == JTokenType.Integer)
                        {
                            int i = item.Value<int>();
                            result += i;
                        }
                        else if (item.Type == JTokenType.Float)
                        {
                            float i = item.Value<float>();
                            result += i;
                        }
                        else
                            throw new InvalidOperationException("Interger or float expected value");

                    }

                }

            }

            var r = (int)result;
            if (r < result)
                return new JValue(result);

            return new JValue(r);

        }

        [JsltExtensionMethod("uuid")]
        public static JToken ExecuteUuid(RuntimeContext ctx)
        {
            return new JValue(Guid.NewGuid());
        }

        [JsltExtensionMethod("parsedate")]
        public static JToken ExecuteParseDate(RuntimeContext ctx, JToken token, string Culture)
        {

            if (token is JValue v)
            {

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(Culture))
                    culture = CultureInfo.GetCultureInfo(Culture);

                if (v.Type == JTokenType.String)
                    return new JValue(DateTime.Parse(v.Value.ToString(), culture) );

            }

            return token;

        }
     
        [JsltExtensionMethod("convert")]
        public static JToken ExecuteConvert(RuntimeContext ctx, JToken token, Type targetType)
        {
            if (token is JValue v)
                return new JValue(Convert.ChangeType(v.Value, targetType));
            return token;
        }

    }

}
