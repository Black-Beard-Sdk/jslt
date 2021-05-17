using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json.Commands
{


    /*
    .\Json.exe template execute C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
     */

    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {


        public static CommandLineApplication CommandFormat(this CommandLineApplication app)
        {


            /*
                json format --indented
            */
            app.Command("format", config =>
            {

                config.Description = "format input stream";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var optIndent = validator.Option("--indented", "indent the stream input");
                var optNoIndent = validator.Option("--noIndented", "format stream on one line");

                config.OnExecute(() =>
                {

                    var inPipe = Input.IsPipedInput;

                    if (!inPipe)
                    {
                        app.ShowHelp();
                        return ErrorEnum.MissingSource.Error("no source is specified");
                    }

                    var datas = Input.ReadInput(Encoding.UTF8);

                    var jobject = JObject.Parse(datas.ToString());

                    if (optNoIndent.HasValue())
                        jobject
                            .ToString(Formatting.None)
                            .WriteLineStandard()
                        ;

                    else
                        jobject
                            .ToString(Formatting.Indented)
                            .WriteLineStandard()
                        ;

                    return 0;

                });
            });


            return app;

        }

    }
}
