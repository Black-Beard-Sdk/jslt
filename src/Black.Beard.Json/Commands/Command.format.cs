using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Microsoft.Extensions.CommandLineUtils;
using Bb.Json;
using Bb.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Json.Commands
{


    /*
    .\Json.exe template execute C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
     */

    /// <summary>
    /// 
    /// </summary>
    public partial class CommandLines : Command<CommandLine>
    {


        public CommandLineApplication CommandFormat(CommandLine app)
        {

            /*
                json format --indented
            */
            app.Command("format", config =>
            {

                config.Description = "format input stream";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optSource = validator.Option("--source", "json source");

                var optTarget = validator.Option("--out", "output file");

                var optIndent = validator.OptionNoValue("--indented", "indent the stream input");
                var optNoIndent = validator.OptionNoValue("--noIndented", "format stream on one line");
                var optText = validator.OptionNoValue("--flatText", "format stream on one line");

                var optFilter = validator.Option("--filter", "json path filter");

                config.OnExecute(() =>
                {

                    JToken token;

                    var inPipe = Input.IsPipedInput;

                    if (!inPipe)
                    {

                        if (optSource.HasValue())
                            token = optSource.Value().TrimPath().LoadFromFile().ConvertToJson();

                        else
                        {
                            app.ShowHelp();
                            return ErrorEnum.MissingSource.Error("no source is specified");
                        }
                    }
                    else
                    {
                        var datas = Input.ReadInput(Encoding.UTF8);
                        token = JToken.Parse(datas.ToString());
                    }

                    if (optFilter.HasValue())
                    {

                        var items = token.SelectTokens(optFilter.Value());

                        if (items.Count() == 0)
                            return 1;

                        if (items.Count() == 1)
                            token = items.FirstOrDefault();

                        else
                            token = new JArray(items);

                    }

                    StringBuilder sb = new StringBuilder();

                    if (optNoIndent.HasValue())
                        sb.Append(token.ToString(Formatting.None));

                    else if (optIndent.HasValue())
                        sb.Append(token.ToString(Formatting.Indented));

                    else if (optText.HasValue())
                    {
                        if (token is JObject o)
                            sb.AppendLine(o.ToString(Formatting.None));

                        else if (token is JArray a)
                        {
                            foreach (var item in a)
                                sb.AppendLine(item.ToString(Formatting.None));
                        }
                        else
                        {

                        }
                    }

                    if (optTarget.HasValue())
                    {
                        
                        FileInfo file = new FileInfo(optTarget.Value().TrimPath());
                        
                        if (file.Exists)
                            file.Delete();

                        file.FullName.Save(sb.ToString());

                    }
                    else
                    {

                    }

                    return 0;

                });
            });


            return app;

        }

    }
}
