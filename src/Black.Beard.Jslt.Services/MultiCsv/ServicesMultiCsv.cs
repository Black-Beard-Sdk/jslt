using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System.Collections.Generic;

namespace Bb.Jslt.Services.MultiCsv
{

    public static partial class ServicesMultiCsv
    {

        [JsltExtensionMethod("loadmcsv", "Load csv with multi header")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("rulePayload", "rule for resolve tree of data")]
        public static JToken LoadMultiCsv(RuntimeContext ctx, string sourcePath, string rulePayload)
        {

            List<JToken> datas = new List<JToken>();

            var file = ctx.Configuration.ResolveFile(sourcePath);
            if (file.Exists)
            {

                var visitor = new JsonVisitor()
                {
                    //IgnoreEmptyProperties = true,
                };

                FileReader reader = FileReader.Readfile(file.FullName, rulePayload ?? string.Empty);

                foreach (var item in reader.Items)
                {
                    var resultVisitor = visitor.Visit(item);

                    var info = reader.FileInformations;

                    var metadatas = new JObject(
                        new JProperty("Filename", info.FileInfo.FullName),
                        new JProperty("EncodingFile", info.EncodingByUde.HeaderName),
                        new JProperty("EncodingFileBody", info.EncodingByUde.BodyName)
                        );

                    foreach (var meta in info.Metadatas)
                    {
                        metadatas.Add(new JProperty(meta.Key, meta.Value));
                    }

                    if (resultVisitor is JObject obj)
                        obj.Add(new JProperty("_metadatas", metadatas));

                    else if (resultVisitor is JArray arr)
                        arr.Insert(0, metadatas);

                    else
                    {

                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();

                    }

                    datas.Add(resultVisitor);
                }

            }

            if (datas.Count == 0)    
                return JValue.CreateNull();

            if (datas.Count == 1)
                return datas[0];

            var array = new JArray(datas.ToArray());

            return array;

        }
    }
}
