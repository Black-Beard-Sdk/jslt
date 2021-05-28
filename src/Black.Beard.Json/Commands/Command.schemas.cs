using Bb.CommandLines;
using Bb.CommandLines.Validators;
using Bb.Jslt.Services.Excels;
using Microsoft.Extensions.CommandLineUtils;
using NJsonSchema;
using System;
using System.IO;

namespace Bb.Json.Commands
{


    /*
    .\Json.exe schema --excelconfig C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
     */

    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {


        public static CommandLineApplication CommandSchemas(this CommandLineApplication app)
        {

            app.Command("schema", config =>
            {

                config.Description = "generate schema";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var outputdirectory = validator.Option("--out", "output directory path location");
                var schemaexcel = validator.OptionNoValue("--excelconfig", "generate schema for excel loading configuration");

                config.OnExecute(() =>
                {

                    string filename;
                    JsonSchema result = null;
                    string outputPath = Environment.CurrentDirectory;

                    if (outputdirectory.HasValue())
                        outputPath = outputdirectory.Value().TrimPath();

                    if (schemaexcel.HasValue())
                    {

                        filename = Path.Combine(outputPath, "excelConfig.schema.json");
                        result = SchemaHelper.GenerateSchemaForClass(typeof(ExcelReader), "excelConfig");

                        var payload = result.ToJson();

                        if (File.Exists(filename))
                            File.Delete(filename);

                        filename.Save(payload);

                    }



                    return 0;

                });
            });


            return app;

        }

    }
}
