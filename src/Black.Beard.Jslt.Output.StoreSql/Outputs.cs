using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{

    public class Outputs
    {

        [JsltExtensionMethod("to_sqlserver", ForOutput = true)]
        public static StringBuilder ExecuteToSqlServer(RuntimeContext ctx, string connection)
        {

            var source = ctx.TokenResult;

            var result = new StringBuilder();


            var schemaObject = JsonSchema.FromSampleJson(source.ToString());
            var datasPayload = schemaObject.ToJson();
            var datas = JObject.Parse(datasPayload);


            return result;

        }

    }

}
