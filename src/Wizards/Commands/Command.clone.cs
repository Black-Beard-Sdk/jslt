using Bb.Builds;
using Bb.CommandLines;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Outs.Printings;
using Bb.CommandLines.Validators;
using Bb.Compilers;
using Bb.Wizards;
using LibGit2Sharp;
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


        public CommandLineApplication CommandClone(CommandLine app)
        {

            // The syntax start with template.
            var cmd = app.Command("clone", config =>
            {

                config.Description = "clone git repository";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                // Add argument
                var argRemoteRepository = validator.Argument("<remote git repository>", "pathRepository"
                    , ValidatorExtension.EvaluateRequired
                );


                var argLocalPath = validator.Argument("<local folder>", "pathLocal"
                    , ValidatorExtension.EvaluateRequired
                );

                var argName = validator.Option("-auth", "name of the credential");


                config.OnExecute(() =>
                {

                    var remote = argRemoteRepository.Value;
                    var dir = argLocalPath.Value;

                    var r = remote.Split('/');
                    var dirName = r[r.Length - 1];

                    if (!dir.EndsWith(@"\" + dirName))
                        dir = Path.Combine(dir, dirName);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    var git = new Git(dir)
                    {

                    };

                    if (argName.HasValue())
                    {

                        string name = argName.Value();

                        var credential = Parameters.Instance.Credentials.Where(c => c.Name == name).FirstOrDefault();
                        if (credential == null)
                        {
                            Output.WriteLineError($"credential get '{name}' not found.");
                            app.Result = Errors.MissingAuthentication;
                            git = null;
                        }
                        else
                        {
                            git.User = Parameters.Decrypt(credential.User);
                            git.Token = Parameters.Decrypt(credential.Token);
                        }

                    }

                    if (git != null)
                    {
                        var result = git.Clone(remote);
                    }

                    return app.Result.ToValue();

                });


            });

            return app;

        }

    }

}
