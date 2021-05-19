
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Sdk.Csv;
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
    public static partial class Command
    {


        public static CommandLineApplication CommandLoadExcel(this CommandLineApplication app)
        {

            var dataCmd = app.Command("xls", config =>
            {
                config.Description = "load excel and convert in json";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optNoHeader = validator.OptionNoValue("--noheader", "specifiy the source have'nt header");
                var optHeaderLine = validator.Option("--header", "specifiy the line of header");
                var argSource = validator.Option("--source", "csv source path that contains data source"
                   , ValidatorExtension.EvaluateFileExist
                   );
                var argSheetname = validator.Option("--sheet", "escel shette name of the source that contains data source"
                );
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


                    string sheetName = argSheetname.HasValue() ? argSheetname.Value() : string.Empty;
                    int headerLine = optHeaderLine.HasValue() ? int.Parse(optHeaderLine.Value()) : -1;
                    if (headerLine > -1)
                        hasHeaders = false;

                    var items = ReadExcel(new FileInfo(file), hasHeaders, headerLine, sheetName, out string resultText, out int resultCode);

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

            return app;

        }

        private static int Getfile(CommandOption argSource, out string file)
        {

            file = null;

            if (argSource.HasValue())
                file = argSource.Value();

            else
                Output.WriteLineError("--source must be specified: ");

            if (!File.Exists(file))
            {
                Output.WriteLineError($"missing source file {file}");
                file = null;
            }

            return file == null ? 1 : 0;

        }

        public static JArray ReadExcel(FileInfo file, bool isFirstRowAsColumnNames, int headerLine, string tablename, out string resultText, out int resultCode)
        {

            JArray array = new JArray();

            using (var stream = file.Open(FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = isFirstRowAsColumnNames,
                    },

                };

                var dataSet = reader.AsDataSet(conf);
                if (!dataSet.Tables.Contains(tablename))
                {
                    resultText = $"missing table {tablename}";
                    resultCode = 2;
                    return null;
                }
                else if (string.IsNullOrEmpty(tablename))
                {
                    if (dataSet.Tables.Count == 1)
                        tablename = dataSet.Tables[0].TableName;
                    else
                    {
                        resultText = $"table name not specified and the document has more of one sheet";
                        resultCode = 3;
                        return null;
                    }
                }


                var table = dataSet.Tables[tablename];
                var names = new List<string>(table.Columns.Count);
                HashSet<string> _h = new HashSet<string>(table.Columns.Count);

                if (headerLine > 0)
                {
                    var row = table.Rows[headerLine];
                    var columns = row.ItemArray;

                    for (int i = 0; i < columns.Length; i++)
                    {

                        object name = columns[i];

                        if (name is string txt)
                        {
                            txt = txt.Trim(' ', '\t', '\r', '\n');
                            if (!string.IsNullOrEmpty(txt))
                                name = GetLabel(txt);

                            else
                                name = "renamed_" + names.Count.ToString();
                        }
                        else if (name != null && name != DBNull.Value)
                            name = "renamed_" + names.Count.ToString();

                        names.Add(name.ToString());

                    }
                }
                else
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        var name = GetLabel(column.ColumnName);
                        if (!_h.Add(name))
                            name += "_renamed_" + names.Count().ToString();

                        names.Add(name);
                    }
                }

                int rowLine = 0;

                foreach (DataRow row in table.Rows)
                {
                    if (headerLine == -1 || rowLine > headerLine)
                    {

                        var items = row.ItemArray;
                        var obj = new JObject();
                        for (int i = 0; i < items.Length; i++)
                        {

                            var name = names[i];
                            var value = items[i];

                            if (value != null && value != DBNull.Value)
                            {
                                if (value is string txt)
                                {
                                    txt = txt.Trim();
                                    if (!string.IsNullOrEmpty(txt))
                                        obj.Add(new JProperty(name, txt));
                                }
                                else
                                    obj.Add(new JProperty(name, value));

                            }

                        }
                        if (obj.Properties().Count() > 0)
                            array.Add(obj);

                    }

                    rowLine++;

                }

            }

            resultText = null;
            resultCode = 0;
            return array;

        }

    }
}


//PrintDataExtensions.ClearBorder();
//        //ConvertToDatatable
//        //    .ConvertList(result.Result.Datas, "applications")
//        //    .Print();