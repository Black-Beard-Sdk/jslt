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

        [JsltExtensionMethod("load")]
        public static JToken ExecuteLoadSource(RuntimeContext ctx, string sourcePath)
        {

            var file = ctx.Configuration.ResolveFile(sourcePath);

            if( file.Exists)
            {

                return file.FullName.LoadContentFromFile().ConvertToJson();

            }
            else
            {

                

            }

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

        [JsltExtensionMethod("concat")]
        public static JToken ExecuteConcat(RuntimeContext ctx, JToken token, string SplitChar, string DelimitChar)
        {

            string _delimitChar = DelimitChar ?? string.Empty;
            string _splitChar = SplitChar ?? string.Empty;

            StringBuilder sb = new StringBuilder();

            if (token != null)
            {

                if (token is JArray a && a.Count > 0)
                {

                    bool t = false;
                    foreach (var item in a)
                    {

                        if (t)
                        {
                            sb.Append(_splitChar);
                            sb.Append(_delimitChar);
                        }

                        string i = item.Value<string>();
                        sb.Append(i);

                        if (t)
                        {
                            sb.Append(_delimitChar);
                        }

                        t = true;

                    }

                }

            }

            return new JValue(sb.ToString());

        }

        [JsltExtensionMethod("uuid")]
        public static JToken ExecuteUuid(RuntimeContext ctx)
        {
            return new JValue(Guid.NewGuid());
        }

        [JsltExtensionMethod("format")]
        public static JToken ExecuteFormat(RuntimeContext ctx, JToken token, string Mask, string Culture)
        {

            if (token is JValue v)
            {

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(Culture))
                    culture = CultureInfo.GetCultureInfo(Culture);

                if (v.Type == JTokenType.Integer)
                {
                    var i = v.Value<int>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Float)
                {
                    var i = v.Value<double>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Date)
                {
                    var i = v.Value<DateTime>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.TimeSpan)
                {
                    var i = v.Value<TimeSpan>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Guid)
                {
                    var i = v.Value<Guid>();
                    return new JValue(i.ToString(Mask, culture));
                }

                return new JValue(v.Value.ToString());

            }

            return new JValue(token.ToString());
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

        /// <summary>
        /// return the value in base 64 format
        /// </summary>
      
        [JsltExtensionMethod("convert")]
        public static JToken ExecuteConvert(RuntimeContext ctx, JToken token, Type targetType)
        {
            if (token is JValue v)
                return new JValue(Convert.ChangeType(v.Value, targetType));
            return token;
        }

        //private static HashSet<char> _availables = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    }

}
