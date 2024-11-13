using Bb;
using Bb.Attributes;
using Bb.JPaths;
using Bb.Jslt.Services;
using Bb.Json.Linq;
using Bb.JsonParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Refs.System.Resources;

namespace Black.Beard.LiteDb
{

    public class Class1
    {

        [JsltExtensionMethod("ReadBigJson")]
        [JsltExtensionMethodParameter("fileSource", "json file")]
        [JsltExtensionMethodParameter("slicer", "slicer json path expression.")]
        public static JToken ExecuteSelectOne(RuntimeContext ctx, string fileSource, JsonPath slicer)
        {

            var file = ctx.Configuration.ResolveFile(fileSource);
            if (!file.Exists)
                throw new Exception($"missing file {file.FullName}");

            using var loader = new BigJsonReader(file);
            {
                foreach (var item in loader.Read())
                {


                }
            }

            return JValue.CreateNull();

        }

    }

}
