using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{

    public class Outputs
    {

        [JsltExtensionMethod("to_json", ForOutput = true)]
        //[JsltExtensionMethodParameter("sourcePath", "source file path")]
        public static StringBuilder ExecuteToJson(RuntimeContext ctx, bool indented)
        {
            var source = ctx.TokenResult;
            var result = new StringBuilder();

            if (indented)
                result.AppendLine(source.ToString(Newtonsoft.Json.Formatting.Indented));

            else
                result.AppendLine(source.ToString(Newtonsoft.Json.Formatting.None));

            return result;

        }


        [JsltExtensionMethod("to_block", ForOutput = true)]
        public static StringBuilder ExecuteToBlock(RuntimeContext ctx)
        {

            var source = ctx.TokenResult;

            var result = new StringBuilder();

            if (source is JObject o)
                result.AppendLine(o.ToString(Newtonsoft.Json.Formatting.None));

            else if (source is JArray a)
            {
                foreach (var item in a)
                    result.AppendLine(item.ToString(Newtonsoft.Json.Formatting.None));
            }

            return result;

        }


    }

}
