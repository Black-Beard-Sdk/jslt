using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Maj
{

    public static class GitHubVersionHelper
    {

        public static Action<string> WriteLineStandard { get; set; } = a => { };

        public static Action<string> WriteLineError { get; set; } = a => { };

        public static int RunUpdate(int processId, string name, string targetVersion, string artefactName, string CurrentVersion, string targetDir)
        {

            System.Diagnostics.Process process = null;

            if (processId > 0)
                process = System.Diagnostics.Process.GetProcessById(processId);

            WriteLineStandard($"Explore http://github/{name}");
            var versions = name.GetUrls()
                .Where(c => c.Name == artefactName)
                .OrderByDescending(c => c.Version)
                .ToList();

            ArtefactItem artefact;
            if (!string.IsNullOrEmpty(targetVersion))
                artefact = versions.FirstOrDefault(c => c.Version.ToString() == targetVersion);
            else
            {
                artefact = versions.FirstOrDefault();

                var v1 = new Version(CurrentVersion);

                if (v1 < artefact.Version)
                {
                    WriteLineStandard($"the current version is in a version greater. please specify the version");
                    return 0;
                }

            }

            if (artefact.Version.ToString() == CurrentVersion)
            {
                WriteLineStandard($"the current version is uptdate");
                return 0;
            }

            var file = new FileInfo(Path.Combine(Path.GetTempPath(), artefact.Name));
            if (!file.Directory.Exists)
                file.Directory.Create();

            WriteLineStandard($"Download '{artefact.UrlDownload}'");
            bool success = artefact.UrlDownload.DownloadFile(file);

            int result;

            if (success)
            {

                var dirToExtract = new DirectoryInfo(Path.GetTempFileName());
                dirToExtract = new DirectoryInfo(Path.Combine(dirToExtract.Parent.FullName, dirToExtract.Name.Replace(".", "")));

                if (!dirToExtract.Exists)
                    dirToExtract.Create();

                WriteLineStandard($"extracting '{file.FullName}'");
                if (file.Extract(dirToExtract))
                {

                    WriteLineStandard($"extracted to '{dirToExtract.FullName}'");

                    var dirTarget = new DirectoryInfo(targetDir);

                    if (!dirTarget.Exists)
                    {
                        dirTarget.Create();
                        WriteLineStandard($"install starting");
                    }
                    else
                        WriteLineStandard($"update starting");

                    if (process != null)
                        process.WaitForExit(1000 * 120);

                    result = dirToExtract.MoveTo(dirTarget);

                    if (result == 0)
                        dirToExtract.Delete();

                }
                else
                {
                    WriteLineError($"Failed to extract {file.FullName}");
                    return 2;
                }

                file.Delete();

            }
            else
            {
                WriteLineError($"Failed to download {artefact.UrlDownload}");
                return 1;
            }

            if (result == 0)
                WriteLineStandard($"succefully updated");
            else
                WriteLineError($"file haven't replaced. please ensure all process are close and retry");

            return 0;

        }

        public static List<ArtefactItem> GetUrls(this string name)
        {
            List<ArtefactItem> result = new List<ArtefactItem>();

            string pattern = $"href=\\\"\\/{name.Replace("/", "\\/")}\\/releases\\/download\\/\\d+\\.\\d\\.\\d+\\/[^\\\"]+";
            var root = $"https://github.com/{name}/releases";

            var content = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;


            var reg = new Regex(pattern);
            var m = reg.Match(content);
            var _h = new HashSet<string>();
            while (m.Success)
            {
                var ver = Map(name, m.Value);
                if (_h.Add(ver.UrlDownload.AbsoluteUri))
                    result.Add(ver);

                m = m.NextMatch();

            }

            return result;

        }

        public static List<ArtefactItem> GetUrls(this string name, Version version)
        {
            List<ArtefactItem> result = new List<ArtefactItem>();

            string pattern = $"href=\\\"\\/{name.Replace("/", "\\/")}\\/releases\\/download\\/\\d+\\.\\d\\.\\d+\\/[^\\\"]+";
            var root = $"https://github.com/{name}/releases/tag/{version}";

            var content = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;


            var reg = new Regex(pattern);
            var m = reg.Match(content);
            var _h = new HashSet<string>();
            while (m.Success)
            {
                var ver = Map(name, m.Value);
                if (_h.Add(ver.UrlDownload.AbsoluteUri))
                    result.Add(ver);
                m = m.NextMatch();
            }

            return result;

        }

        public static ArtefactItem Map(this string name, string value)
        {

            var u1 = value.Substring(7);

            var nameLivrable = u1.Substring(u1.LastIndexOf('/') + 1);
            var version = u1.Substring(name.Length + 19);
            version = version.Substring(0, version.LastIndexOf('/'));

            var result = new ArtefactItem()
            {
                Name = nameLivrable,
                Version = new Version(version),
                UrlDownload = new Uri("https://github.com/" + u1)
            };

            return result;

        }

        public static Version ResolveLastVersion(this string name)
        {

            string pattern = $"href=\\\"\\/{name.Replace("/", "\\/")}\\/releases\\/tag\\/\\d+\\.\\d\\.\\d+\\\"";
            var root = $"https://github.com/{name}";

            var content = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;

            var reg = new Regex(pattern);
            var m = reg.Match(content);
            if (m.Success)
            {
                var url = m.Value.Substring(name.Length + 21).Trim('"');
                return new Version(url);
            }

            return null;

        }

        public static Process RestartForUpdate(this Assembly callingAssembly)
        {

            var targetDirPath = PrepareMaj(callingAssembly, new FileInfo(callingAssembly.Location).Directory);

            var attributes = callingAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().ToDictionary(c => c.Key);
            string packageNameArgument = attributes["githubName"].Value;
            string artefactNameArgument = attributes["githubartefact"].Value;
            var version = callingAssembly.GetName().Version;
            string targetDirArgument = new FileInfo(callingAssembly.Location).Directory.FullName;

            var file = new FileInfo(callingAssembly.Location);
            file = new FileInfo(Path.Combine(targetDirPath, Path.GetFileNameWithoutExtension(file.Name) + ".exe"));

            var process = Process.GetCurrentProcess();

            var info = new ProcessStartInfo()
            {
                FileName = file.FullName,
                Arguments = $"install \"{packageNameArgument}\" \"{artefactNameArgument}\" \"{version.ToString()}\" \"{targetDirArgument}\" --p {process.Id}"
            };

            var process1 = Process.Start(info);

            return process1;

        }

        private static string PrepareMaj(Assembly assembly, DirectoryInfo source)
        {

            var files = GetListOfFiles(assembly, source);
            var target = Path.Combine(source.FullName, "_majRun");

            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);

            foreach (var item in files)
            {

                var fileTarget = new FileInfo(Path.Combine(target, Path.GetFileName(item)));

                if (File.Exists(fileTarget.FullName))
                    File.Delete(fileTarget.FullName);

                File.Copy(item, fileTarget.FullName);

            }

            return target;

        }

        private static HashSet<string> GetListOfFiles(Assembly assembly, DirectoryInfo source)
        {

            HashSet<string> files = new HashSet<string>();

            var file = new FileInfo(assembly.Location);
            files.Add(file.FullName);
            file = new FileInfo(Path.Combine(source.FullName, Path.GetFileNameWithoutExtension(file.Name) + ".exe"));
            files.Add(file.FullName);

            var list = assembly.GetReferencedAssemblies();
            foreach (var item in list)
            {
                var ass = Assembly.Load(item);
                files.Add(ass.Location);
            }

            foreach (var item in source.GetFiles("api-ms-win-core*.dll"))
                files.Add(item.FullName);

            return files;

        }

    }

}
