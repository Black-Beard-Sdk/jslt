using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using NJsonSchema;

namespace Bb.Jslt.Services.Schemas
{


    public static partial class ServicesSchema
    {

        [JsltExtensionMethod("schema", "use json fragment for build a schema.")]
        [JsltExtensionMethodParameter("fragment", "fragment to analyze.")]
        public static JToken LoadSchema(RuntimeContext ctx, JToken fragment)
        {
            var schemaObject = JsonSchema.FromSampleJson(fragment.ToString());
            var datasPayload = schemaObject.ToJson();
            var datas = JObject.Parse(datasPayload);
            return datas;
        }
    }
}
