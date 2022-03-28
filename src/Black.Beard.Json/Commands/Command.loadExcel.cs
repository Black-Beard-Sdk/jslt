
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Sdk.Csv;
using Bb.Jslt.Services.Excels;
using ExcelDataReader;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Json.Commands
{




    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {


        public static CommandLineApplication CommandLoadExcel(CommandLine app)
        {

            var dataCmd1 = app.Command("xls", config =>
            {
                config.Description = "load excel and convert in json";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optNoHeader = validator.OptionNoValue("--noheader", "specifiy the source have'nt header");
                var optHeaderLine = validator.Option("--header", "specifiy the line of header");
                var argSource = validator.Option("--source", "excel source path that contains data source"
                   , ValidatorExtension.EvaluateFileExist
                   );
                var argSheetname = validator.Option("--sheet", "excel sheet name of the source that contains data source"
                );

                var optconfig = validator.Option("--config", "specifiy the config document source");

                var argTarget = validator.Option("--out", "json file target path"
                   );

                var optNoIndent = validator.OptionNoValue("--noIndented", "format stream on one line");


                config.OnExecute(() =>
                {

                    bool hasHeaders = !optNoHeader.HasValue();

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;

                    if (Getfile(argSource, out string file) == 1)
                        return 1;

                    ExcelReader reader = null;

                    if (optconfig.HasValue())
                    {

                        if (Getfile(optconfig, out string fileConfig) == 1)
                            return 1;

                        reader = fileConfig.LoadFromFile().Deserialize<ExcelReader>();

                    }
                    else
                    {
                        string sheetName = argSheetname.HasValue() ? argSheetname.Value() : string.Empty;
                        int headerLine = optHeaderLine.HasValue() ? int.Parse(optHeaderLine.Value()) : -1;
                        if (headerLine > -1)
                            hasHeaders = false;

                        reader = new ExcelReader()
                        {
                            FirstRowHasColumnName = hasHeaders,
                            HeaderLine = headerLine,
                            Tablename = sheetName,
                        };

                    }

                    var items = reader.Read(new FileInfo(file), out string resultText, out int resultCode);

                    if (items == null)
                    {
                        Output.WriteLineError(resultText);
                        return resultCode;
                    }

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

            var dataCmd3 = app.Command("xlsconfig", config =>
            {
                config.Description = "generate excel config";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optNoHeader = validator.OptionNoValue("--noheader", "specifiy the source have'nt header");
                var optHeaderLine = validator.Option("--header", "specifiy the line of header");
                var argSource = validator.Option("--source", "excel source path that contains data source"
                   , ValidatorExtension.EvaluateFileExist
                   );
                var argSheetname = validator.Option("--sheet", "excel sheet name of the source that contains data source"
                );

                var argTarget = validator.Option("--out", "json file target path"
                   );

                var optNoIndent = validator.OptionNoValue("--noIndented", "format stream on one line");


                config.OnExecute(() =>
                {

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;
                    
                    var outputPath = argTarget.Value().TrimPath();

                    if (Getfile(argSource, out string file) == 1)
                        return 1;

                    bool hasHeaders = !optNoHeader.HasValue();
                    string sheetName = argSheetname.HasValue() ? argSheetname.Value() : string.Empty;
                    int headerLine = optHeaderLine.HasValue() ? int.Parse(optHeaderLine.Value()) : -1;
                    if (headerLine > -1)
                        hasHeaders = false;

                    var reader = new ExcelReader()
                    {
                        FirstRowHasColumnName = hasHeaders,
                        HeaderLine = headerLine,
                        Tablename = sheetName,
                    };

                    var items = reader.Read(new FileInfo(file), out string resultText, out int resultCode);

                    outputPath.Save(reader.Serialize());

                    return 0;

                });

            });
            return app;

        }

        private static int Getfile(CommandOption argSource, out string file)
        {

            file = null;

            if (argSource.HasValue())
                file = argSource.Value().TrimPath();

            else
                Output.WriteLineError("--source must be specified: ");

            if (!File.Exists(file))
            {
                Output.WriteLineError($"missing source file {file}");
                file = null;
            }

            return file == null ? 1 : 0;

        }

    }
}


//PrintDataExtensions.ClearBorder();
//        //ConvertToDatatable
//        //    .ConvertList(result.Result.Datas, "applications")
//        //    .Print();