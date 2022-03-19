using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{

    public class Outputs
    {

        [JsltExtensionMethod("to_json", ForOutput = FunctionKindEnum.Output)]
        [JsltExtensionMethodParameter("indented", "serialize json indented if value is true")]
        [JsltExtensionMethodParameter("ignoreNullAndEmptyValue", "remove empty and null value of the output")]
        public static StringBuilder ExecuteToJson(RuntimeContext ctx, bool indented, bool ignoreNullAndEmptyValue)
        {
            var source = ctx.TokenResult;
            var result = new StringBuilder();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = indented ? Formatting.Indented : Formatting.None,
                Culture = ctx.Configuration.Culture,
                DefaultValueHandling = ignoreNullAndEmptyValue ? DefaultValueHandling.Ignore : DefaultValueHandling.Include,
                NullValueHandling = ignoreNullAndEmptyValue ? NullValueHandling.Ignore : NullValueHandling.Include,
                TypeNameHandling = TypeNameHandling.All,
            };

            if (ignoreNullAndEmptyValue)
            {
                var visitor = new JsonVisitor();
                visitor.Visit(source);
            }

            result.AppendLine(JsonConvert.SerializeObject(source, settings));

            return result;

        }

        private class JsonVisitor
        {

            public void Visit(JToken token)
            {

                List<string> toRemove = new List<string>();
                if (token is JValue v)
                {
                    if (v.Value is string s && string.IsNullOrEmpty(s))
                    {
                        v.Value = null;
                    }
                }
                else if (token is JObject o)
                {
                    foreach (var item in o.Properties())
                    {

                        Visit(item.Value);

                        if (item.Value is JValue v2 && v2.Value == null)
                            toRemove.Add(item.Name);

                    }

                    foreach (var item in toRemove)
                        o.Remove(item);

                }
                else if (token is JArray a)
                {
                    foreach (var item in a)
                    {
                        Visit(item);
                    }
                }

            }

        }


        [JsltExtensionMethod("to_block", ForOutput = FunctionKindEnum.Output)]
        public static StringBuilder ExecuteToBlock(RuntimeContext ctx)
        {

            var source = ctx.TokenResult;

            var result = new StringBuilder();

            if (source is JObject o)
                result.AppendLine(o.ToString(Newtonsoft.Json.Formatting.None));

            else if (source is JArray a)
                foreach (var item in a)
                    result.AppendLine(item.ToString(Newtonsoft.Json.Formatting.None));

            return result;

        }


    }

}
