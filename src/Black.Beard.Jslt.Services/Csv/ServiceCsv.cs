using Bb.Jslt.Services.Sql;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Bb.Sdk.Csv;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Jslt.Services.Csv
{


    public static class ServiceCsv
    {

        [JsltExtensionMethod("loadcsv")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("hasHeader", "has header")]
        [JsltExtensionMethodParameter("separator", "separator charset. If null the value is ';'")]
        [JsltExtensionMethodParameter("quote", "quote charset. If null the value is '\"'")]
        [JsltExtensionMethodParameter("escape", "quote charset. If null the value is '\"'")]
        public static JToken ExecuteLoadCsvSource(RuntimeContext ctx, string sourcePath, bool hasHeader, string separator, string quote, string escape)
        {

            if (string.IsNullOrEmpty(separator))
                separator = ";";

            if (string.IsNullOrEmpty(escape))
                escape = "\\";

            var file = ctx.Configuration.ResolveFile(sourcePath);
            if (file.Exists)
            {

                var result = ReadCsv
                (
                    file.FullName,
                    hasHeader,
                    separator,
                    quote,
                    escape
                );

                return result;

            }

            throw new Exception($"missing file {file.FullName}");

        }

        private static JArray ReadCsv(string filename, bool hasHeader, string? charsetSeparator, string? quoteCharset, string escapeCharset)
        {

            JArray result = new JArray();

            var separator = charsetSeparator;
            if (separator.Length == 3)
                separator = separator.Trim(separator[0]);

            char? quote = null;
            if (quoteCharset?.Length > 0)
            {
                quote = quoteCharset[0];
            }

            var escape = escapeCharset;
            if (escape.Length == 3)
                escape = escape.Trim(escape[0]);

            var _file = new FileInfo(filename);

            var text = _file.FullName.LoadFromFile();

            using (var _txt = new StringReader(text))
            using (CsvReader csv = new CsvReader(_txt, hasHeader, separator[0], quote, escape[0], '#', ValueTrimmingOptions.All, (int)_file.Length))
            {

                System.Data.IDataReader reader = csv;
                int line = 0;

                while (reader.Read())
                {

                    line++;

                    try
                    {

                        var o = new JObject();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            var n = reader.GetName(i);
                            string name = hasHeader
                                ? ServicesSql.GetLabel(n)
                                : "Column" + i.ToString();

                            var value = reader.GetValue(i);
                            o.Add(new JProperty(name, value));

                        }

                        result.Add(o);

                    }
                    catch (Exception)
                    {
                        throw;
                    }



                }

            }

            return result;

        }


    }

}
