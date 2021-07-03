using Bb.CommandLines;
using Bb.CommandLines.Validators;
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

                var schemaExcel = validator.OptionNoValue("--excel", "generate schema for excel loading configuration");
                var schemaElastic = validator.OptionNoValue("--elastic", "generate schema for elastic configuration");

                config.OnExecute(() =>
                {

                    string outputPath = Environment.CurrentDirectory;

                    if (outputdirectory.HasValue())
                        outputPath = outputdirectory.Value().TrimPath();

                    if (schemaExcel.HasValue())
                        Generate(typeof(Bb.Jslt.Services.Excels.ExcelReader), outputPath, Path.Combine(outputPath, "excelConfig"));

                    if (schemaElastic.HasValue())
                        Generate(typeof(Elasticsearch.Configurations.ElasticConfigurations), outputPath, Path.Combine(outputPath, "elasticConfig"));

                    return 0;

                });
            });


            return app;

        }

        private static void Generate(Type type, string path, string name)
        {

            var filename = Path.Combine(path, name + ".schema.json");

            JsonSchema result = SchemaHelper.GenerateSchemaForClass(type, name);

            var payload = result.ToJson();

            if (File.Exists(filename))
                File.Delete(filename);

            filename.Save(payload);

        }


    }
}
