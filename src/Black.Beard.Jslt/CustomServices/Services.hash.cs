﻿using Bb.Attributes;
using Bb.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Bb.Jslt.CustomServices
{

    public static partial class CServices
    {

        /// <summary>
        /// return the crc32 of the value
        /// if one of the term is not a number
        /// </summary>
        [JsltExtensionMethod("crc32")]
        [JsltExtensionMethodParameter("token", "object to hash")]
        public static JToken ExecuteCrc32(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {
                var r = token.ToString();
                return new JValue(r.CalculateCrc32());
            }

            return new JValue(0);

        }

        /// <summary>
        /// return the value in base 64 format
        /// </summary>
        [JsltExtensionMethod("tobase64")]
        [JsltExtensionMethodParameter("token", "string to encode")]
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
        [JsltExtensionMethodParameter("token", "string to decode")]
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
        [JsltExtensionMethodParameter("token", "string to hash")]
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
        [JsltExtensionMethodParameter("token", "string to hash")]
        public static JToken ExecuteSha512(RuntimeContext ctx, JToken token)
        {

            if (token != null)
            {

                var data = System.Text.Encoding.UTF8.GetBytes(token.ToString());
                using (SHA512 shaM = SHA512.Create())
                {
                    var hashValue = shaM.ComputeHash(data);
                    return new JValue(hashValue.PrintByteArray());
                }
            }

            return new JValue(string.Empty);

        }

    }

}
