using Bb.Jslt.Services.Sql;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Bb.Sdk.Csv;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
        [JsltExtensionMethodParameter("excludedColumns", "List of column to exclude form reading")]
        public static JToken ExecuteLoadCsvSource(RuntimeContext ctx, string sourcePath, bool hasHeader, string separator, string quote, string escape, string excludedColumns)
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
                    escape,
                    excludedColumns
                );

                return result;

            }

            throw new Exception($"missing file {file.FullName}");

        }

        private static JArray ReadCsv(string filename, bool hasHeader, string? charsetSeparator, string? quoteCharset, string escapeCharset, string excludedColumns)
        {

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

            var cnt = (int)( text.Count(c => c == '\r' ));

            List<JObject> result = new List<JObject>(cnt);

            var toExclude = new HashSet<string>();
            if (!string.IsNullOrEmpty(excludedColumns))
            {
                var e = excludedColumns.Split(separator[0]);
                foreach (var item in e)
                    toExclude.Add(item);
            }

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
                        bool t = false;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            var n = reader.GetName(i);
                            if (!toExclude.Contains(n))
                            {
                                t = true;
                                string name = hasHeader
                                    ? ServicesSql.GetLabel(n)
                                    : "Column" + i.ToString();

                                var raw = reader.GetValue(i);
                                
                                var value = raw == null || raw == System.DBNull.Value
                                    ? JValue.CreateNull() 
                                    : new JValue(raw);

                                o.Add(new JProperty(name, value));

                            }

                        }

                        if (t)
                            result.Add(o);

                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

            }

            var r = new JArray(result);

            result.Clear();

            return r;

        }


    }

}
