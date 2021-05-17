
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Sdk.Csv;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Json.Commands
{




    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {

        private static Dictionary<char, char> _accepted = build();


        public static CommandLineApplication CommandLoadCsv(this CommandLineApplication app)
        {

            var dataCmd = app.Command("csv", config =>
            {
                config.Description = "load csv and convert in json";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optHeader = validator.OptionNoValue("--noheader", "specifiy the cav source have'nt no header");
                var optSeparator = validator.Option("--separator", "specifiy the sperator charset. by default the value is ';'");
                var optQuote = validator.Option("--quote", "specifiy the quote charset. by default the value is '\"'");
                var optEscape = validator.Option("--escape", "specifiy the escape charset. by default the value is '\'");

                var argSource = validator.Option("--source", "csv source path that contains data source"
                   , ValidatorExtension.EvaluateFileExist
                   );

                var argTarget = validator.Option("--out", "json file target path"
                   );

                var optNoIndent = validator.OptionNoValue("--noIndented", "format stream on one line");


                config.OnExecute(() =>
                {

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;

                    var items = ReadCsv(
                        argSource.Value(),
                        !optHeader.HasValue(),
                        optSeparator.HasValue()
                            ? optSeparator.Value()
                            : ";",
                        optQuote.HasValue()
                            ? optQuote.Value()
                            : "\"",
                        optEscape.HasValue()
                            ? optEscape.Value()
                            : "\\"
                        );

                    var result = items.ToString(optNoIndent.HasValue() ? Formatting.None : Formatting.Indented);

                    if (argTarget.HasValue())
                    {

                        string o = argTarget.Value();
                        if (File.Exists(o))
                            File.Delete(o);

                        ContentHelper.Save(o, result);

                    }
                    else
                        result.WriteLineStandard();

                    return 0;

                });

            });

            return app;

        }

        private static JArray ReadCsv(string filename, bool hasHeader, string charsetSeparator, string quoteCharset, string escapeCharset)
        {
            JArray result = new JArray();

            var separator = charsetSeparator;
            if (separator.Length == 3)
                separator = separator.Trim(separator[0]);

            var quote = quoteCharset;
            if (quote.Length == 3)
                quote = quote.Trim(quote[0]);

            var escape = escapeCharset;
            if (escape.Length == 3)
                escape = escape.Trim(escape[0]);

            var _file = new FileInfo(filename);

            var text = _file.FullName.LoadContentFromFile();

            using (var _txt = new StringReader(text))
            {

                using (CsvReader csv = new CsvReader(_txt, hasHeader, separator[0], quote[0], escape[0], '#', ValueTrimmingOptions.All, (int)_file.Length))
                {

                    System.Data.IDataReader reader = csv;
                    int line = 0;
                    try
                    {

                        while (reader.Read())
                        {

                            line++;

                            var o = new JObject();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                var n = reader.GetName(i);
                                string name = hasHeader
                                    ? GetLabel(n)
                                    : "Column" + i.ToString();

                                var value = reader.GetValue(i);

                                o.Add(new JProperty(name, value));

                            }

                            result.Add(o);

                        }

                    }
                    catch (Exception)
                    {
                        Output.WriteLineError($"Failed to read after {result.Last.ToString(Formatting.Indented)}");
                        throw;
                    }

                }

            }
            return result;

        }

        private static string GetLabel(string n)
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

        private static Dictionary<char, char> build()
        {

            var dic = new Dictionary<char, char>();
            
            Add(dic, (int)'a', (int)'z');
            Add(dic, (int)'A', (int)'Z');
            Add(dic, (int)'0', (int)'9');

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
            for (int i = s; i < e; i++)
                dic.Add((char)i, (char)i);
        }

    }
}


//PrintDataExtensions.ClearBorder();
//        //ConvertToDatatable
//        //    .ConvertList(result.Result.Datas, "applications")
//        //    .Print();