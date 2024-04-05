using Bb.Attributes;
using Bb.Jslt.Services;
using Bb.MultiCsv;
using Oldtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace Bb.Jslt.CustomServices
{

    public static partial class ServicesMultiCsv
    {

        [JsltExtensionMethod("loadmcsv", "Load csv with multi header")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("rulePayload", "rule for resolve tree of data")]
        public static JToken LoadMultiCsv(RuntimeContext ctx, string sourcePath, string rulePayload)
        {
            var _file = new FileInfo(sourcePath);
            List<JToken> datas = new List<JToken>((int)(_file.Length / 100));

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

                    System.Text.Json.Nodes.JsonNode json = visitor.Visit(item);
                    var txt = json.ToJsonString();
                    var resultVisitor = txt.ConvertToJson();

                    var info = reader.FileInformations;
                    
                    var metadatas = new JObject(
                        new JProperty("_filename", info.FileInfo.FullName),
                        new JProperty("_encodingFile", info.EncodingByUde.HeaderName),
                        new JProperty("_encodingFileBody", info.EncodingByUde.BodyName)
                      );

                    foreach (var meta in info.Metadatas)
                        metadatas.Add(new JProperty(meta.Key, meta.Value));

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
