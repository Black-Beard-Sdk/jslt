using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.ConvertToDatables;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Bb.Json.Commands
{


    /*
    .\Json.exe template execute C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json
    */


    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {

        public static CommandLineApplication CommandExport(this CommandLineApplication app)
        {

            // json template 

            var cmd = app.Command("export", config =>
            {

                config.Description = "export process";
                config.HelpOption(HelpFlag);

            });

            /*
                json export csv <template> <target folder> --source 'source file' --name 'nameRoot' --h --s ';' --q '"'
            */
            cmd.Command("csv", config =>
            {

                config.Description = "run template transformation with the specified template";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var argTemplatePath = validator.Argument("<template file>", "template path"
                    , ValidatorExtension.EvaluateFileExist
                    , ValidatorExtension.EvaluateRequired
                    );

                var argtarget = validator.Argument("<target folder>", "json source path that contains data source"
                     , ValidatorExtension.EvaluateRequired
                     );

                var argSource = validator.Option("--source", "json source file path that contains data source. if option is missing source is readed from stdin stream");
                var argTargetName = validator.Option("--name", "name of the output csv files. if the value is missing a randomized name is generated");
                var optWriteHeader = validator.OptionNoValue("--h", "Write header");
                var optSeparator = validator.Option("--s", "specify the charset separator. by default the value is ';'");
                var optQuote = validator.Option("--q", "specify the charset quote. by default the value is '\"'");

                config.OnExecute(() =>
                {

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;

                    var targetDir = new DirectoryInfo(argtarget.Value.TrimPath());
                    char separator = GetSeparator(optSeparator);
                    char quote = GetQuote(optQuote);

                    string targetName = string.Empty;
                    JToken source = null;

                    Parser parser = GenerateParser(argTemplatePath);
                    var result = ReadSource(app, argSource, argTargetName);

                    if (result.Item1 > 0)
                        return result.Item1;

                    source = result.Item3;
                    targetName = result.Item2;

                    Func<Context, DataTable, bool> flush = (ctx, table) =>
                    {
                        try
                        {
                            var file = new FileInfo(Path.Combine(targetDir.FullName, targetName.Trim('_') + "_" + table.TableName + ".csv"));
                            table.WriteToCsv(file, Encoding.UTF8, optWriteHeader.HasValue(), separator, quote);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            ctx.Exception = ex;
                            return false;
                        }

                    };

                    using (var ctx = parser.Open(flush, 500000))
                    {

                        parser.Load(source, ctx);


                    }

                    //parser.Schema.DataSet.WriteToCsv(
                    //       targetDir
                    //     , targetName
                    //     , Encoding.UTF8
                    //     , optWriteHeader.HasValue()
                    //     , separator
                    //     , quote
                    //     );

                    return 0;

                });
            });


            return app;

        }

        private static char GetSeparator(CommandOption optSeparator)
        {
            char separator = ';';

            if (optSeparator.HasValue())
            {
                string se = optSeparator.Value();
                if (se.Length > 1)
                    se = se.Trim(se[0]);
                separator = se[0];
            }

            return separator;

        }

        private static char GetQuote(CommandOption optQuote)
        {

            char quote = '"';

            if (optQuote.HasValue())
            {
                string se = optQuote.Value();
                if (se.Length > 1)
                    se = se.Trim(se[0]);
                quote = se[0];
            }

            return quote;

        }

        private static (int, string, JToken) ReadSource(CommandLineApplication app, CommandOption argSource, CommandOption argTargetName)
        {
            string targetName = string.Empty;
            JToken source = null;

            var inPipe = Input.IsPipedInput;

            if (argSource.HasValue())
            {

                var s = argSource.Value();
                source = s.TrimPath()
                         .LoadContentFromFile()
                         .ConvertToJson();

                targetName = Path.GetFileNameWithoutExtension(s);

            }
            else
            {

                if (!inPipe)
                {
                    app.ShowHelp();
                    return (ErrorEnum.MissingSource.Error("no source specified"), string.Empty, null);
                }

                source = Input.ReadInput(Encoding.UTF8)
                    .ConvertToJson();

                if (argTargetName.HasValue())
                    targetName = Path.GetFileNameWithoutExtension(argTargetName.Value().TrimPath());
                else
                    targetName = Guid.NewGuid().ToString()
                        .Replace("-", "")
                        .Trim(' ', '{', '}')
                        ;

            }

            return (0, targetName, source);

        }

        private static Parser GenerateParser(CommandArgument argTemplatePath)
        {
            var builder = new BuildSchema();

            var template = argTemplatePath.Value.TrimPath()
                .LoadContentFromFile()
                .ConvertToJson();

            var parser = builder.ParseTemplate(template);
            return parser;
        }
    }
}
