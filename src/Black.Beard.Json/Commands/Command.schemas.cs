using Bb.CommandLines;
using Bb.CommandLines.Outs.Printings;
using Bb.CommandLines.Validators;
using Bb.ComponentModel;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Bb.Json.Commands
{


    /*
    .\Json.exe schema --excelconfig C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
     */

    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {


        public CommandLineApplication CommandSchema(CommandLineApplication app)
        {


            var schema = app.Command("schema", config =>
            {
                config.Description = "manage schema";
                config.HelpOption(HelpFlag);
            });


            schema.Command("list", config =>
            {

                config.Description = "generate schema";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var assemblyFilename = validator.OptionMultiValue("--assembly", "output directory path location");

                config.OnExecute(() =>
                {

                    HashSet<string> _list = new HashSet<string>();
                    foreach (var assemblyFile in assemblyFilename.Values)
                    {
                        var ass = new FileInfo(assemblyFile);
                        _list.Add(ass.FullName);
                        TypeDiscovery.Instance.LoadAssembly(ass, null);
                    }

                    var types = TypeDiscovery.Instance.GetTypesWithAttributes(typeof(CategoryAttribute))
                        .Where(c => FilterConfiguration(c))
                        .Where(c => _list.Count == 0 || _list.Contains(c.Assembly.Location))
                        .ToList()
                    ;

                    (app as CommandLine).Result = types;

                    var table = types.ConvertList("", c => c.AssemblyQualifiedName);
                    table.PrintList();

                    string outputPath = Environment.CurrentDirectory;


                    return 0;

                });
            });

            schema.Command("generate", config =>
            {

                config.Description = "generate schema";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var outputdirectory = validator.Argument("<output path>", "output directory path location");
                var assemblyFilename = validator.OptionMultiValue("--assembly", "output directory path location");

                config.OnExecute(() =>
                {

                    HashSet<string> _list = new HashSet<string>();
                    foreach (var assemblyFile in assemblyFilename.Values)
                    {
                        var ass = new FileInfo(assemblyFile);
                        _list.Add(ass.FullName);
                        TypeDiscovery.Instance.LoadAssembly(ass, null);
                    }

                    var types = TypeDiscovery.Instance.GetTypesWithAttributes(typeof(CategoryAttribute))
                        .Where(c => FilterConfiguration(c))
                        .Where(c => _list.Count == 0 || _list.Contains(c.Assembly.Location))
                        .ToList()
                    ;

                    string outputPath = outputdirectory.Value.TrimPath();

                    foreach (var type in types)
                        Generate(type, outputPath, type.Name);

                    return 0;

                });
            });

            return app;

        }

        private bool FilterConfiguration(Type c)
        {

            var attributes = c.GetCustomAttributes(true);
            foreach (var item in attributes)
            {

                if (item is CategoryAttribute category)
                    return category.Category == "Configuration";

            }

            return false;

        }

        private static void Generate(Type type, string path, string name)
        {

            var filename = Path.Combine(path, name + ".schema.json");

            JsonSchema result = type
                // .GetSerializerType()
                .GenerateSchemaForClass(name);

            var payload = JObject.Parse(result.ToJson());

            payload.AddFirst(new JProperty("$type", type.AssemblyQualifiedName));

            if (File.Exists(filename))
                File.Delete(filename);

            filename.Save(payload.ToString(Newtonsoft.Json.Formatting.Indented));

        }


    }
}
