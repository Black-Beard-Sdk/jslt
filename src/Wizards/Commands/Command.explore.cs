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
    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {

        /*
            Syntax
            .exe explore "C:\Users\g.beard\Desktop\Docs\TesWizard"
        */

        public CommandLineApplication CommandExplore(CommandLine app)
        {

            // The syntax start with template.
            var cmd = app.Command("explore", config =>
            {
                config.Description = "explore list of wizard";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                // Add argument
                var argTemplatePath = validator.Argument("<wizard folder>", "path"
                    , ValidatorExtension.EvaluateDirectoryPathIsValid
                    , ValidatorExtension.EvaluateRequired
                );
           
                config.OnExecute(() =>
                {

               
                    var fileInfo = new DirectoryInfo(argTemplatePath.Value);

                    var main = new MainWindow(fileInfo);

                    var result =main.ShowDialog();

                    return app.Result.ToValue();

                });


            });

            return app;

        }  


    }

}
