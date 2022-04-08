using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {

        [JsltExtensionMethod("concatpath", "concat items for create a file path")]
        [JsltExtensionMethodParameter("path", "array of string")]
        public static JToken ExecuteConcatPath(RuntimeContext ctx, JArray path)
        {

            List<string> p = new List<string>();

            foreach (var item in path)
                if (item is JValue v && v.Value != null)
                    p.Add(v.Value.ToString());

            return new JValue(Path.Combine(p.ToArray()));

        }

    }

}
