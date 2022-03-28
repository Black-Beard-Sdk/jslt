using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Jslt.Services.Excels
{


    public static partial class ServicesXls
    {


        [JsltExtensionMethod("loadxls")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("configPath", "configuration path")]
        public static JToken ExecuteLoadExcelSource(RuntimeContext ctx, string sourcePath, string configPath)
        {

            ExcelReader reader = null;
            var fileconfig = ctx.Configuration.ResolveFile(configPath);
            if (fileconfig.Exists)
                reader = fileconfig.FullName.LoadFromFile().Deserialize<ExcelReader>();
            
            else
                throw new Exception($"missing configuration file {fileconfig.FullName}");

            var file = ctx.Configuration.ResolveFile(sourcePath);
            if (file.Exists)
            {
                var result = reader.Read(file, out string resultText, out int resultCode);
                if (resultCode > 0)
                    throw new Exception(resultText);

                return result;
            }

            throw new Exception($"missing file {file.FullName}");

        }

        [JsltExtensionMethod("loadxlssheet")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("configPath", "configuration path")]
        public static JToken ExecuteLoadExcelSheetSource(RuntimeContext ctx, string sourcePath, JObject config)
        {

            ExcelReader reader = Bb.ContentHelper.Deserialize<ExcelReader>(config.ToString());

            var file = ctx.Configuration.ResolveFile(sourcePath);
            if (file.Exists)
            {
                var result = reader.Read(file, out string resultText, out int resultCode);
                if (resultCode > 0)
                    throw new Exception(resultText);

                return result;
            }

            throw new Exception($"missing file {file.FullName}");

        }


    }

}
