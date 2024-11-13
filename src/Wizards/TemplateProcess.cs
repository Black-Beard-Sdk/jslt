using Bb;
using Bb.Jslt.Services;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wizards
{

        public class TemplateProcess
        {

            public TemplateProcess(string rulePayloadFilename, JObject variables, bool debug, string[] paths)
            {

                var file = ResolveFile(rulePayloadFilename, paths);
                file.Refresh();
                if (!file.Exists)
                    throw new Exception($"the path '{file}' can't be resolved.");

                _template = file.LoadTemplate(debug, paths);

                _variables = variables.ExtractVariables();

            }

        public static FileInfo ResolveFile(string filename, string[] paths)
        {

            var file = new FileInfo(filename);

            if (!file.Exists)
                foreach (var path in paths)
                    if (!string.IsNullOrEmpty(path))
                    {
                        file = new FileInfo(Path.Combine(path, filename));
                        if (file.Exists)
                            return file;
                    }
              
            return file;

        }

        public object Run()
            {

                var src = new Sources(SourceJson.GetFromText(String.Empty));
                foreach (var item in _variables)
                    src.Variables.Add(item.Key, item.Value);

                var ctx = _template.Transform(src);
                StringBuilder result = _template.ApplyOutput(ctx);

                return result;

            }

            private readonly JsltTemplate _template;
            private readonly IDictionary<string, JToken> _variables;

        }

    


}
