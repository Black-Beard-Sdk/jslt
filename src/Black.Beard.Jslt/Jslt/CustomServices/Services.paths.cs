using Bb.Attributes;
using Bb.Jslt.Services;
using Oldtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Bb.Jslt.CustomServices
{



    public static partial class CServices
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
