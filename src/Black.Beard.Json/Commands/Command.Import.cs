
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


    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {


        public static CommandLineApplication CommandImport(this CommandLineApplication app)
        {

            var dataCmd = app.Command("data", config =>
            {
                config.Description = "operation on datas";
                config.HelpOption(HelpFlag);
            });

            var importCmd = dataCmd.Command("import", config =>
            {

                config.Description = "Import data in sorted index";
                config.HelpOption(HelpFlag);

            });

            importCmd.Command("localsystem", config =>
            {

                config.Description = "Import data source in localFile";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                var argIndexName = validator.Argument("index", "index name of the local data source"
                    , ValidatorExtension.EvaluateName
                    , ValidatorExtension.EvaluateRequired
                    );

                var argoutput = validator.Argument("out", "directory output path"
                    , ValidatorExtension.EvaluateRequired
                    );

                var argSource = validator.Argument("<source file>", "json source path that contains data source"
                   , ValidatorExtension.EvaluateFileExist
                   );

                config.OnExecute(() =>
                {

                    if (!validator.Evaluate(out int errorNum))
                        return errorNum;

                    //var configuration = new TransformJson.TranformJsonAstConfiguration();
                    //var provider = new TransformJson.TemplateTransformProvider(configuration);

                    JToken result;

                    var output = new OutputDatasourceFile()
                    {
                        IndexName = argIndexName.Value,
                        DirectoryPath = argoutput.Value.TrimPath(),
                    };
                    output.Initialize();

                    var inPipe = Input.IsPipedInput;

                    if (!string.IsNullOrEmpty(argSource.Value))
                    {
                        var payload = argSource.Value.TrimPath().LoadContentFromFile();
                        result = output.Execute(payload.ToString());
                    }
                    else
                    {
                        if (!inPipe)
                        {
                            app.ShowHelp();
                            return ErrorEnum.MissingSource.Error("no source is specified");
                        }

                        var payload = Input.ReadInput(Encoding.UTF8);
                        result = output.Execute(payload.ToString());

                    }

                    return 0;

                });
            });

            return app;

        }





    }
}


//PrintDataExtensions.ClearBorder();
//        //ConvertToDatatable
//        //    .ConvertList(result.Result.Datas, "applications")
//        //    .Print();