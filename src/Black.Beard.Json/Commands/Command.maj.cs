
//using Bb.CommandLines;
//using Bb.CommandLines.Ins;
//using Bb.CommandLines.Outs;
//using Bb.CommandLines.Validators;
////using Bb.Maj;
//using Bb.Sdk.Csv;
//using Microsoft.Extensions.CommandLineUtils;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace Bb.Json.Commands
//{




//    /// <summary>
//    /// 
//    /// </summary>
//    public partial class Command : Command<CommandLine>
//    {


//        public static CommandLineApplication CommandMaj(CommandLine app)
//        {
                      
//            app.Command("update", config =>
//            {

//                config.Description = "update version of json cli";
//                config.HelpOption(HelpFlag);

//                var validator = new GroupArgument(config);

//                config.OnExecute(() =>
//                {

//                    var result = typeof(Command).Assembly.RestartForUpdate();

//                    if (result.HasExited)
//                    {
//                        Output.WriteLineStandard("the update process is anormaly quicker");
//                        return 1;
//                    }

//                    return 0;

//                });

//            });

//            app.Command("install", config =>
//            {

//                config.Description = "return the last version";
//                config.HelpOption(HelpFlag);

//                var validator = new GroupArgument(config);
//                var packageNameArgument = validator.Argument("<github package name>", "github package name");
//                var artefactNameArgument = validator.Argument("<artefact name>", "specifiy the artifact name");
//                var CurrentVersionArgument = validator.Argument("<current version>", "specifiy the current version");
//                var targetDirArgument = validator.Argument("<target path>", "specifiy the target directory");

//                var processToWaitOpt = validator.Option("--p", "specifiy a process to waiting to end");
//                var versionOpt = validator.Option("--v", "specifiy the version to install");

//                config.OnExecute(() =>
//                {

//                    int processId = 0;
//                    if (processToWaitOpt.HasValue())
//                        processId = int.Parse(processToWaitOpt.Value());

//                    string name = null;
//                    name = packageNameArgument.Value.TrimPath();

//                    string version = null;
//                    if (versionOpt.HasValue())
//                        version = versionOpt.Value().TrimPath();

//                    GitHubVersionHelper.WriteLineStandard = (a) => Output.WriteLineStandard(a);
//                    GitHubVersionHelper.WriteLineError = (a) => Output.WriteLineError(a);

//                    var _result = GitHubVersionHelper.RunUpdate(processId, name, version, artefactNameArgument.Value.TrimPath(), CurrentVersionArgument.Value, targetDirArgument.Value.TrimPath());

//                    return _result;

//                });
//            });


//            return app;

//        }

//    }
//}
