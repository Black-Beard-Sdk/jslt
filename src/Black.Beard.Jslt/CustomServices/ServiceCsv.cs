using Bb.Csv;
using Bb.Attributes;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bb.Jslt;

namespace Bb.CustomServices
{


    public static class ServiceCsv
    {

        [JsltExtensionMethod("loadcsv")]
        [JsltExtensionMethodParameter("sourcePath", "source file path")]
        [JsltExtensionMethodParameter("hasHeader", "has header")]
        [JsltExtensionMethodParameter("separator", "separator charset. If null the value is ';'")]
        [JsltExtensionMethodParameter("quote", "quote charset. If null the value is '\"'")]
        [JsltExtensionMethodParameter("escape", $"quote charset. If null the value is '\"'")]
        [JsltExtensionMethodParameter("excludedColumns", "List of column to exclude form reading")]
        [JsltExtensionMethodParameter("excludeNullAndEmpty", "bypass null and empty values")]
        public static JToken ExecuteLoadCsvSource(RuntimeContext ctx, string sourcePath, bool hasHeader, string separator, string quote, string escape, string excludedColumns, bool excludeNullAndEmpty)
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
                    excludedColumns,
                    excludeNullAndEmpty
                );

                return result;

            }

            throw new Exception($"missing file {file.FullName}");

        }

        private static JArray ReadCsv(string filename, bool hasHeader, string charsetSeparator, string quoteCharset, string escapeCharset, string excludedColumns, bool excludeNullAndEmpty)
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

            int cnt = 0;
            for (int i = 0; i < text.Length; i++)
                if (text[i] == '\n')
                    cnt++;

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

                if (hasHeader)
                    line++;

                List<JToken> properties = new List<JToken>(100);
                while (reader.Read())
                {

                    line++;
                    var lastPosition = csv.CurrentPosition;

                    try
                    {

                        for (int i = 0; i < reader.FieldCount; i++)
                        {

                            var n = reader.GetName(i);
                            if (!toExclude.Contains(n))
                            {

                                string name = hasHeader
                                    ? GetLabel(n)
                                    : "Column" + i.ToString();

                                var raw = reader.GetValue(i);
                                var value = GetValue(raw, excludeNullAndEmpty);

                                if (value != null)
                                {
                                    int position = csv.Position[i];
                                    var p = new JProperty(name, value);
                                    p.SetLineInfo(line, position);
                                    properties.Add(p);
                                }

                            }

                        }

                        if (properties.Count > 0)
                        {
                            var o = new JObject(properties);
                            o.SetLineInfo(line, lastPosition);
                            result.Add(o);
                            properties.Clear();
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

                properties.Clear();

            }

            var r = new JArray(result);

            return r;

        }

        private static JValue GetValue(object value, bool excludeNullAndEmpty)
        {

            if (value == null || value == DBNull.Value)
            {
                if (excludeNullAndEmpty)
                    return null;

                else
                    return JValue.CreateNull();
            }

            if (value is string v)
            {

                v = v.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(v))
                {
                    if (excludeNullAndEmpty)
                        return null;
                    else
                        return new JValue(string.Empty);
                }


                if (v == "true")
                    return new JValue(true);

                if (v == "false")
                    return new JValue(false);

                var x = v[0];

                if (x == '-' || char.IsDigit(x))
                {
                    bool isint = false;
                    bool isNegative = false;
                    bool isdecimal = false;

                    for (int i = 0; i < v.Length; i++)
                    {
                        x = v[i];
                        if (i == 0 && x == '-')
                            isNegative = true;

                        if (char.IsDigit(x))
                            isint = true;

                        else if (isint && x == '.')
                            isdecimal = true;

                        else
                            break;
                    }

                    if (isdecimal && decimal.TryParse(v, out decimal d))
                        return new JValue(d);

                    if (isint && long.TryParse(v, out long l))
                    {
                        if (l.ToString() == v)
                        {
                            if (l < int.MaxValue)
                                return new JValue((int)l);

                            return new JValue(l);
                        }
                    }
                }

            }

            return new JValue(value);

        }

        public static string GetLabel(string n)
        {

            var sb = new StringBuilder(n.Length);

            foreach (var c in n)
            {
                var p = (int)c;

                //if (p == 65279) // Bom // { } 
                if (_accepted.TryGetValue(c, out char v))
                    sb.Append(v);

            }

            return sb.ToString()
                 .Replace("___", "_")
                 .Replace("__", "_");

        }

        private static Dictionary<char, char> _accepted = build();

        private static Dictionary<char, char> build()
        {

            var dic = new Dictionary<char, char>();

            Add(dic, 'a', 'z');
            Add(dic, 'A', 'Z');
            Add(dic, '0', '9');

            dic.Add(' ', '_');
            dic.Add('\'', '_');
            dic.Add('"', '_');
            dic.Add('é', 'e');
            dic.Add('è', 'e');
            dic.Add('ë', 'e');
            dic.Add('î', 'i');
            dic.Add('ï', 'i');
            dic.Add('Ï', 'I');
            dic.Add('Ö', 'O');
            dic.Add('Ü', 'U');
            dic.Add('ô', 'o');
            dic.Add('à', 'a');
            dic.Add('ê', 'e');
            dic.Add('ñ', 'n');
            dic.Add('Ñ', 'N');
            dic.Add('¡', 'i');
            dic.Add('á', 'a');
            dic.Add('í', 'i');
            dic.Add('ó', 'o');
            dic.Add('ú', 'u');
            dic.Add('Á', 'A');
            dic.Add('É', 'E');
            dic.Add('Í', 'I');
            dic.Add('Ó', 'O');
            dic.Add('Ú', 'U');
            dic.Add('ä', 'a');
            dic.Add('ö', 'o');
            dic.Add('Ä', 'A');
            dic.Add('Ë', 'E');

            return dic;

        }

        private static void Add(Dictionary<char, char> dic, int s, int e)
        {
            for (int i = s; i <= e; i++)
                dic.Add((char)i, (char)i);
        }

    }

}
