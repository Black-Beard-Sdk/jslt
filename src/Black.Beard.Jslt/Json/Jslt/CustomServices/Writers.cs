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

    public class Writers
    {

        [JsltExtensionMethod("to_file", ForOutput = FunctionKindEnum.Writer)]
        [JsltExtensionMethodParameter("filename", "filename where the datas will be streamed")]
        public static object ExecuteToFile(RuntimeContext ctx, string filename)
        {

            var file = ctx.Configuration.ResolveFile(filename);
            
            if (!file.Directory.Exists)
                file.Directory.Create();

            var result = ctx.Output;

            File.AppendAllText(file.FullName, result.ToString());

            return result;

        }


    }

}
