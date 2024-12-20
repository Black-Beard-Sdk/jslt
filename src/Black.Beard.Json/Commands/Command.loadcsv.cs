﻿
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Csv;
using Bb.Jslt.Services.Sql;
using Microsoft.Extensions.CommandLineUtils;
using Bb.Json;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bb.CustomServices;

namespace Bb.Json.Commands
{




    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {

        public static CommandLineApplication CommandLoadCsv(CommandLine app)
        {

            var dataCmd = app.Command("csv", config =>
            {
                config.Description = "load csv and convert in json";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optHeader = validator.OptionNoValue("--noheader", "specify the cav source haven't no header");
                var optSeparator = validator.Option("--separator", "specify the separator character. by default the value is ';'");
                var optQuote = validator.Option("--quote", "specify the quote character. by default the value is '\"'");
                var optEscape = validator.Option("--escape", "specify the escape character. by default the value is '\'");

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

                        string o = argTarget.Value().TrimPath();
                        if (File.Exists(o))
                            File.Delete(o);

                        ContentHelperFiles.Save(o, result);

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
            var result = new List<JToken>((int)(_file.Length / 100));
            var text = _file.FullName.LoadFromFile();

            using (var _txt = new StringReader(text))
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
                                ? ServiceCsv.GetLabel(n)
                                : "Column" + i.ToString();

                            var value = reader.GetValue(i);

                            o.Add(new JProperty(name, value));

                        }

                        result.Add(o);

                    }

                }
                catch (Exception)
                {
                    Output.WriteLineError($"Failed to read after {result.LastOrDefault()?.ToString(Formatting.Indented)}");
                    throw;
                }

            }



            return new JArray(result);

        }


    }
}


//PrintDataExtensions.ClearBorder();
//        //ConvertToDatatable
//        //    .ConvertList(result.Result.Datas, "applications")
//        //    .Print();