﻿using Bb;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Wizards
{

        public class TemplateProcess
        {

            public TemplateProcess(string rulePayloadFilename, JObject variables, bool debug, string[] paths = null)
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
                src.Variables.Add(_variables);

                var ctx = _template.Transform(src);
                string result = _template.ApplyOutput(ctx);

                return result;

            }

            private readonly JsltTemplate _template;
            private readonly IDictionary<string, JToken> _variables;

        }

    


}