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
        public static JToken Execute(RuntimeContext ctx)
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
        [JsltExtensionMethod("tobase64")]
        public static JToken ExecuteToBase64(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {
                var data = System.Text.Encoding.UTF8.GetBytes(token.ToString());
                return new JValue(Convert.ToBase64String(data));
            }

            return new JValue(string.Empty);

        }

        [JsltExtensionMethod("frombase64")]
        public static JToken ExecuteFromBase64(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {
                var d2 = Convert.FromBase64String(token.ToString());
                var data = System.Text.Encoding.UTF8.GetString(d2);
                return new JValue(data);

            }

            return new JValue(string.Empty);

        }

        [JsltExtensionMethod("sha256")]
        public static JToken ExecuteSha256(RuntimeContext ctx, JToken token)
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

        [JsltExtensionMethod("sha512")]
        public static JToken ExecuteSha512(RuntimeContext ctx, JToken token)
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

        [JsltExtensionMethod("convert")]
        public static JToken Execute(RuntimeContext ctx, JToken token, Type targetType)
        {
            if (token is JValue v)
                return new JValue(Convert.ChangeType(v.Value, targetType));
            return token;
        }

        private static HashSet<char> _availables = new HashSet<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    }

}
