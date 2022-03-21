using Bb.Builds;
using Bb.CommandLines;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Outs.Printings;
using Bb.CommandLines.Validators;
using Bb.Compilers;
using Bb.Wizards;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Wizards.Commands
{

    // play "C:\Users\g.beard\Desktop\Docs\TesWizard\Locker team\Avisages\Resent codes.cs" --debug

    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {

        /*
            Syntax
            .exe template execute "<template file>" --source:"value source" --debug
        */

        public CommandLineApplication CommandPlay(CommandLine app)
        {

            // The syntax start with template.
            var cmd = app.Command("play", config =>
            {
                config.Description = "play specified wizard";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                // Add argument
                var argTemplatePath = validator.Argument("<wizard file>", "path"
                    , ValidatorExtension.EvaluateFileExist
                    , ValidatorExtension.EvaluateRequired
                );

                // Add option
                var optwithDebug = validator.OptionNoValue("--debug", "activate debug mode");

                config.OnExecute(() =>
                {

                    bool debug = Debugger.IsAttached;
                    if (optwithDebug.HasValue())
                        debug = true;


                    var fileInfo = new FileInfo(argTemplatePath.Value);

                    AssemblyResult assembly = GetCsharpBuilder(fileInfo.FullName);

                    if (!assembly.Success)
                    {

                        // compilation error
                        app.Result = Errors.CompilationError;

                        assembly.Disgnostics
                        .ConvertList("", c => c.Id, c => c.Message)
                        .PrintList("Id", "Message");
                        ;

                        if (!assembly.Success && Debugger.IsAttached)
                            Debugger.Break();

                    }
                    else
                    {

                        Type type = GetTypeToExecute(assembly);
                        var model = Activator.CreateInstance(type) as Model;
                        model.ModelFile = fileInfo.FullName;
                        model.ModelDir = fileInfo.Directory.FullName;
                        model.Paths.Add(fileInfo.Directory.FullName);
                        model.Debug = debug;

                        model.Execute();

                    }


                    return app.Result.ToValue();

                });


            });

            return app;

        }


        private static Type GetTypeToExecute(Bb.Compilers.AssemblyResult assembly)
        {
            // Resolve the name of objects
            List<CodeObject> _items = new List<CodeObject>();
            foreach (Microsoft.CodeAnalysis.SyntaxTree item in assembly.Codes)
                _items.AddRange(ObjectResolverVisitor.GetObjects(item)
                   .Where(c => c.EvaluateInherit("Model")));

            var ass = assembly.LoadAssembly();
            List<Type> types = new List<Type>();

            foreach (var item in ass.GetTypes())
                if (_items.Any(c => c.Evaluate(item)))
                    types.Add(item);

            var type = types[0];
            return type;
        }

        private static Bb.Compilers.AssemblyResult GetCsharpBuilder(string filepathCode)
        {

            var fileInfo = new FileInfo(filepathCode);

            // Build assembly

            Action<CSharpCompilationOptions> action = (r) =>
            {

            };

            BuildCSharp builder = new BuildCSharp()
            {
                ResolveAssembliesInCode = true,
                Debug = true,
                LanguageVersion = Microsoft.CodeAnalysis.CSharp.LanguageVersion.CSharp7,
            }
            .AddSource(fileInfo)
            .Suppress("CS1702", "CS1998")
            ;

            // System.Collections
            builder.References.AddRange(
                typeof(Model),
                typeof(WizardModel),
                typeof(JObject),
                typeof(ExcelDataReader.ExcelReaderFactory),
                typeof(System.Windows.Forms.Control),
                typeof(DataSet),
                typeof(ProcessStartInfo),
                typeof(Bb.Expressions.LocalMethodCompiler)
            );

            builder.References.AddAssemblyFile(typeof(DataSet).Assembly.Location);
            builder.References.Add(Assembly.LoadWithPartialName("System.Collections"));

            var assembly = builder.Build();
            return assembly;

        }

    }

}
