﻿using Bb.Json.Attributes;
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


    public static partial class Services
    {

        [JsltExtensionMethod("loadxls")]
        public static JToken ExecuteLoadSource(RuntimeContext ctx, string sourcePath, string configPath)
        {

            ExcelReader reader = null;
            var fileconfig = ctx.Configuration.ResolveFile(configPath);
            if (fileconfig.Exists)
                reader = fileconfig.FullName.LoadContentFromFile().Deserialize<ExcelReader>();
            
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

    }

}