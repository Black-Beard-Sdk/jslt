using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Json.Jslt.Services;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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


        public static CommandLineApplication CommandExecute(this CommandLineApplication app)
        {

            // json template 

            var cmd = app.Command("template", config =>
            {
                config.Description = "template process";
                config.HelpOption(HelpFlag);
            });

            /*
                json template execute -file '' -source
            */
            cmd.Command("execute", config =>
            {

                config.Description = "run template transformation with the specified template";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var argTemplatePath = validator.Argument("<template file>", "template path"
                    , ValidatorExtension.EvaluateFileExist
                    , ValidatorExtension.EvaluateRequired
                );

                var argSource = validator.Option("--source", "json source path that contains data source"
                    , ValidatorExtension.EvaluateFileExist
                );

                var argTarget = validator.Option("--out", "json target path that contains output data"
                );

                var optTemplatePath = validator.OptionNoValue("--m", "the result is merge on the source document");
                var optNoIndent = validator.OptionNoValue("--noIndented", "format stream on one line");
                var optwithDebug = validator.OptionNoValue("--debug", "activate debug mode");

                config.OnExecute(() =>
                {

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;

                    bool withDebug = optwithDebug.HasValue() ? true : false;

                    var configuration = new TranformJsonAstConfiguration();

                    TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);
                    
                    var sb = new StringBuilder(argTemplatePath.Value.TrimPath().LoadContentFromFile());
                    JsltTemplate template = Templateprovider.GetTemplate(sb, withDebug, string.Empty);

                    JToken result;
                    JToken TokenSource = null;
                    Sources payload = null;

                    var inPipe = Input.IsPipedInput;

                    if (argSource.HasValue())
                        payload = new Sources(SourceJson.GetFromFile(argSource.Value().TrimPath()));
                   
                    else if (!inPipe)
                    {
                        payload = new Sources(SourceJson.GetFromText(""));
                        //app.ShowHelp();
                        //return ErrorEnum.MissingSource.Error("no source specified");
                    }
                    else
                        payload = new Sources(SourceJson.GetFromText(Input.ReadInput(Encoding.UTF8)));

                    var resultCtx = template.Transform(payload);

                    result = resultCtx.TokenResult;

                    if (optTemplatePath.HasValue())
                    {

                        if (TokenSource is JObject o)
                            o.Merge(result, new JsonMergeSettings
                            {
                                MergeArrayHandling = MergeArrayHandling.Union,
                            });

                        else if (TokenSource is JArray a)
                            a.Merge(result, new JsonMergeSettings
                            {
                                MergeArrayHandling = MergeArrayHandling.Union,
                            });

                    }

                    var resultPayload = result.ToString(optNoIndent.HasValue() ? Formatting.None : Formatting.Indented);

                    if (argTarget.HasValue())
                    {
                        var @out = argTarget.Value();
                        if (File.Exists(@out))
                            File.Delete(@out);

                        ContentHelper.Save(@out, resultPayload);

                    }
                    else
                        resultPayload.WriteLineStandard();

                    return 0;

                });
            });


            return app;

        }

    }
}
