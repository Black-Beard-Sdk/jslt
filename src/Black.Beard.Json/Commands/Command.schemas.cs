//using Bb.CommandLines;
//using Bb.CommandLines.Outs.Printings;
//using Bb.CommandLines.Validators;
//using Bb.ComponentModel;
//using Microsoft.Extensions.CommandLineUtils;
//using Oldtonsoft.Json.Linq;
//using NJsonSchema;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.IO;
//using System.Linq;

//namespace Bb.Json.Commands
//{


//    /*
//    .\Json.exe schema --excelconfig C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
//     */

//    /// <summary>
//    /// 
//    /// </summary>
//    public partial class Command : Command<CommandLine>
//    {


//        public CommandLineApplication CommandSchema(CommandLine app)
//        {


//            var schema = app.Command("schema", config =>
//            {
//                config.Description = "manage schema";
//                config.HelpOption(HelpFlag);
//            });


//            schema.Command("list", config =>
//            {

//                config.Description = "generate schema";
//                config.HelpOption(HelpFlag);

//                var validator = new GroupArgument(config);
//                var assemblyFilename = validator.OptionMultiValue("--assembly", "output directory path location");

//                config.OnExecute(() =>
//                {
                   
//                    List<Type> types = LoadFiles(assemblyFilename);

//                    (app as CommandLine).Result = types;

//                    if (types.Count > 0)
//                    {
//                        var table = types.ConvertList("Types", c => c.FullName);
//                        table.PrintList();
//                    }
//                    else
//                        app.Error.WriteLine("no types found");

//                    string outputPath = Environment.CurrentDirectory;

//                    return 0;

//                });
//            });

//            schema.Command("generate", config =>
//            {

//                config.Description = "generate schema";
//                config.HelpOption(HelpFlag);

//                var validator = new GroupArgument(config);
//                var outputdirectory = validator.Argument("<output path>", "output directory path location");
//                var assemblyFilename = validator.OptionMultiValue("--assembly", "output directory path location");

//                config.OnExecute(() =>
//                {

//                    List<Type> types = LoadFiles(assemblyFilename);
//                    string outputPath = outputdirectory.Value.TrimPath();

//                    foreach (var type in types)
//                        Generate(type, outputPath, type.Name);

//                    return 0;

//                });
//            });

//            return app;

//        }

//        private List<Type> LoadFiles(CommandOption assemblyFilename)
//        {

//            List<Type> types = new List<Type>();
//            HashSet<string> _list = new HashSet<string>();

//            foreach (var assemblyFile in assemblyFilename.Values)
//            {
//                if (!LoadLibrary(assemblyFile))
//                {
//                    if (!LoadLibrary(assemblyFile + ".dll"))
//                    {
//                        if (!LoadLibrary(assemblyFile + ".exe"))
//                        {

//                        }
//                        else
//                            _list.Add(assemblyFile + ".exe");
//                    }
//                    else
//                        _list.Add(assemblyFile + ".dll");

//                }
//                else
//                    _list.Add(assemblyFile);
//            }

//            types = TypeDiscovery.Instance.GetTypesWithAttributes(typeof(CategoryAttribute))
//                .Where(c => FilterConfiguration(c))
//                .ToList();


//            types = types
//               .Where(c => _list.Count == 0 || _list.Contains(Path.GetFileName(c.Assembly.ManifestModule.ScopeName)))
//               .ToList()
//           ;

//            return types;
//        }

//        private static bool LoadLibrary(string filename)
//        {
//            var ass = new FileInfo(filename);
//            if (ass.Exists)
//            {
//                TypeDiscovery.Instance.LoadAssembly(ass, null);
//                return true;
//            }

//            return false;

//        }

//        private bool FilterConfiguration(Type c)
//        {

//            var attributes = c.GetCustomAttributes(true);
//            foreach (var item in attributes)
//            {

//                if (item is CategoryAttribute category)
//                    return category.Category == "Configuration";

//            }

//            return false;

//        }

//        private static void Generate(Type type, string path, string name)
//        {

//            var filename = Path.Combine(path, name + ".schema.json");

//            JsonSchema result = type
//                // .GetSerializerType()
//                .GenerateSchemaForClass(name);

//            var payload = JObject.Parse(result.ToJson());

//            payload.AddFirst(new JProperty("$type", type.AssemblyQualifiedName));

//            if (File.Exists(filename))
//                File.Delete(filename);

//            filename.Save(payload.ToString(Oldtonsoft.Json.Formatting.Indented));

//        }


//    }
//}
