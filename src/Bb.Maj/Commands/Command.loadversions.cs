using Bb.CommandLines;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Linq;

namespace Bb.Maj.Commands
{


    /*
    .\Json.exe schema --excelconfig C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\template1.json C:\_perso\Src\Sdk\TransformJsonToJson\Src\DocTests\source1.json | .\Json.exe format
     */

    /// <summary>
    /// 
    /// </summary>
    public static partial class Command
    {


        public static CommandLineApplication CommandVersions(this CommandLineApplication app)
        {

            app.Command("version", config =>
            {

                config.Description = "return the last version";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var packageName = validator.Argument("<github package name>", "github package name");

                config.OnExecute(() =>
                {

                    string name = null;
                    name = packageName.Value.TrimPath();

                    var version = name.ResolveLastVersion();

                    Output.WriteLineStandard($"last version of '{name}' is {version}");

                    return 0;

                });
            });

            app.Command("versions", config =>
            {

                config.Description = "return the last version";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var packageName = validator.Argument("<github package name>", "github package name");

                config.OnExecute(() =>
                {

                    string name = null;
                    name = packageName.Value.TrimPath();

                    var versions = name.GetUrls().ToLookup(c => c.Name);

                    foreach (var item in versions)
                    {

                        Output.WriteLineStandard(item.Key);

                        var i = item.OrderByDescending(c => c.Version);
                        foreach (var item2 in i)
                            Output.WriteLineStandard("  - " + item2.Version.ToString());

                    }

                    return 0;

                });
            });

            app.Command("install", config =>
            {

                config.Description = "return the last version";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);
                var packageNameArgument = validator.Argument("<github package name>", "github package name");
                var artefactNameArgument = validator.Argument("<artefact name>", "specifiy the artifact name");
                var CurrentVersionArgument = validator.Argument("<current version>", "specifiy the current version");
                var targetDirArgument = validator.Argument("<target path>", "specifiy the target directory");

                var processToWaitOpt = validator.Option("--p", "specifiy a process to waiting to end");
                var versionOpt = validator.Option("--v", "specifiy the version to install");
                

                config.OnExecute(() =>
                {

                    System.Diagnostics.Process process = null;
                    if (processToWaitOpt.HasValue())
                        process = System.Diagnostics.Process.GetProcessById(int.Parse(processToWaitOpt.Value()));

                    string name = null;
                    name = packageNameArgument.Value.TrimPath();

                    Output.WriteLineStandard($"Explore http://github/{name}");
                    var versions = name.GetUrls()
                        .Where(c => c.Name == artefactNameArgument.Value.TrimPath())
                        .OrderByDescending(c => c.Version)
                        .ToList();

                    ArtefactItem artefact;
                    if (versionOpt.HasValue())
                    {
                        string version = versionOpt.Value().TrimPath();
                        artefact = versions.FirstOrDefault(c => c.Version.ToString() == version);
                    }
                    else
                        artefact = versions.FirstOrDefault();

                    if (artefact.Version.ToString() == CurrentVersionArgument.Value)
                    {
                        Output.WriteLineStandard($"the current version is uptdate");
                        return 0;
                    }

                    var file = new FileInfo(Path.Combine(Path.GetTempPath(), artefact.Name));
                    if (!file.Directory.Exists)
                        file.Directory.Create();

                    Output.WriteLineStandard($"Download '{artefact.UrlDownload}'");
                    bool success = artefact.UrlDownload.DownloadFile(file);

                    int result;

                    if (success)
                    {

                        var dirToExtract = new DirectoryInfo(Path.GetTempFileName());
                        dirToExtract = new DirectoryInfo(Path.Combine(dirToExtract.Parent.FullName, dirToExtract.Name.Replace(".", "")));

                        if (!dirToExtract.Exists)
                            dirToExtract.Create();

                        Output.WriteLineStandard($"extracting '{file.FullName}'");
                        if (file.Extract(dirToExtract))
                        {

                            Output.WriteLineStandard($"extracted to '{dirToExtract.FullName}'");

                            var dirTarget = new DirectoryInfo(targetDirArgument.Value.TrimPath());

                            if (!dirTarget.Exists)
                            {
                                dirTarget.Create();
                                Output.WriteLineStandard($"install starting");
                            }
                            else
                                Output.WriteLineStandard($"update starting");

                            if (process != null)
                                process.WaitForExit(1000 * 120);

                            result = dirToExtract.MoveTo(dirTarget);

                            if (result == 0)
                                dirToExtract.Delete();

                        }
                        else
                        {
                            Output.WriteLineError($"Failed to extract {file.FullName}");
                            return 2;
                        }

                        file.Delete();

                    }
                    else
                    {
                        Output.WriteLineError($"Failed to download {artefact.UrlDownload}");
                        return 1;
                    }

                    if (result == 0)
                        Output.WriteLineStandard($"succefully updated");
                    else
                        Output.WriteLineError($"file haven't replaced. please ensure all process are close and retry");

                    return 0;

                });
            });

            return app;

        }

    }
}
