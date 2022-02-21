using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bb.Maj
{

    public class GitHubVersionHelper
    {
        private readonly string _name;

        public GitHubVersionHelper(string name)
        {
            this._name = name;
        }


        public Action<string> WriteLineStandard { get; set; } = a => { };

        public Action<string> WriteLineError { get; set; } = a => { };

        public async Task<int> Download(ArtefactItem artefact, string targetDir, bool deleteDownloadToEnd)
        {

            var file = new FileInfo(Path.Combine(Path.GetTempPath(), artefact.Filename));
            if (!file.Directory.Exists)
                file.Directory.Create();

            bool success = false;
            if (!file.Exists)
            {
                WriteLineStandard($"Download '{artefact.UrlDownload}'");
                success = await artefact.UrlDownload.DownloadFile(file);
            }
            else
                success = true;

            int result;

            if (success)
            {

                var dirToExtract = new DirectoryInfo(Path.GetTempFileName());
                dirToExtract = new DirectoryInfo(Path.Combine(dirToExtract.Parent.FullName, dirToExtract.Name.Replace(".", "")));

                if (!dirToExtract.Exists)
                    dirToExtract.Create();

                WriteLineStandard($"extracting '{file.FullName}'");
                if (await file.Extract(dirToExtract))
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

                    result = dirToExtract.MoveTo(dirTarget);

                    if (result == 0)
                        dirToExtract.Delete();

                }
                else
                {
                    WriteLineError($"Failed to extract {file.FullName}");
                    return 2;
                }

                if (deleteDownloadToEnd)
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

        public async Task<int> RunUpdate(int processId, string targetVersion, string artefactName, string CurrentVersion, string targetDir)
        {

            System.Diagnostics.Process process = null;

            if (processId > 0)
                process = System.Diagnostics.Process.GetProcessById(processId);

            WriteLineStandard($"Explore http://github/{this._name}");

            var urls = await GetUrls();

            var versions = urls.Where(c => c.Name == artefactName)
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
                    WriteLineStandard($"the current version is up to date. please specify the version");
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
            bool success = await artefact.UrlDownload.DownloadFile(file);

            int result;

            if (success)
            {

                var dirToExtract = new DirectoryInfo(Path.GetTempFileName());
                dirToExtract = new DirectoryInfo(Path.Combine(dirToExtract.Parent.FullName, dirToExtract.Name.Replace(".", "")));

                if (!dirToExtract.Exists)
                    dirToExtract.Create();

                WriteLineStandard($"extracting '{file.FullName}'");
                if (await file.Extract(dirToExtract))
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

        public async Task<List<ArtefactItem>> GetUrls()
        {

            List<ArtefactItem> result = new List<ArtefactItem>();

            string pattern = $"href=\\\"\\/{this._name.Replace("/", "\\/")}\\/releases\\/download\\/\\d+\\.\\d\\.\\d+\\/[^\\\"]+";
            var root = $"https://github.com/{this._name}/releases";

            var contentTask = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;

            var content = await contentTask;

            var reg = new Regex(pattern);
            var m = reg.Match(content);
            var _h = new HashSet<string>();
            while (m.Success)
            {
                var ver = Map(m.Value);
                if (_h.Add(ver.UrlDownload.AbsoluteUri))
                    result.Add(ver);

                m = m.NextMatch();

            }

            return result;

        }

        public async Task<List<ArtefactItem>> GetUrls(Version version)
        {

            List<ArtefactItem> result = new List<ArtefactItem>();

            string pattern = $"href=\\\"\\/{this._name.Replace("/", "\\/")}\\/releases\\/download\\/\\d+\\.\\d\\.\\d+\\/[^\\\"]+";
            var root = $"https://github.com/{this._name}/releases/tag/{version}";

            var contentTask = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;

            var content = await contentTask;

            var reg = new Regex(pattern);
            var m = reg.Match(content);
            var _h = new HashSet<string>();
            while (m.Success)
            {
                var ver = Map(m.Value);
                if (_h.Add(ver.UrlDownload.AbsoluteUri))
                    result.Add(ver);
                m = m.NextMatch();
            }

            return result;

        }

        public ArtefactItem Map(string value)
        {

            var u1 = value.Substring(7);

            var nameLivrable = u1.Substring(u1.LastIndexOf('/') + 1);
            var version = u1.Substring(this._name.Length + 19);
            version = version.Substring(0, version.LastIndexOf('/'));

            var result = new ArtefactItem()
            {
                Name = nameLivrable,
                Version = new Version(version),
                UrlDownload = new Uri("https://github.com/" + u1)
            };

            return result;

        }

        public async Task<Version> ResolveLastVersion()
        {

            string pattern = $"href=\\\"\\/{this._name.Replace("/", "\\/")}\\/releases\\/tag\\/\\d+\\.\\d\\.\\d+\\\"";
            var root = $"https://github.com/{this._name}/releases/latest";

            var contentTask = new Uri(root)
                .GetRequest()
                .LoadContentFromUrl()
                ;

            var content = await contentTask;

            var reg = new Regex(pattern);
            var m = reg.Match(content);
            if (m.Success)
            {
                var url = m.Value.Substring(this._name.Length + 21).Trim('"');
                return new Version(url);
            }

            return null;

        }

        //public static Process RestartForUpdate(this Assembly callingAssembly)
        //{

        //    var targetDirPath = PrepareMaj(callingAssembly, new FileInfo(callingAssembly.Location).Directory);

        //    var attributes = callingAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().ToDictionary(c => c.Key);
        //    string packageNameArgument = attributes["githubName"].Value;
        //    string artefactNameArgument = attributes["githubartefact"].Value;
        //    var version = callingAssembly.GetName().Version;
        //    string targetDirArgument = new FileInfo(callingAssembly.Location).Directory.FullName;

        //    var file = new FileInfo(callingAssembly.Location);
        //    file = new FileInfo(Path.Combine(targetDirPath, Path.GetFileNameWithoutExtension(file.Name) + ".exe"));

        //    var process = Process.GetCurrentProcess();

        //    var info = new ProcessStartInfo()
        //    {
        //        FileName = file.FullName,
        //        Arguments = $"install \"{packageNameArgument}\" \"{artefactNameArgument}\" \"{version.ToString()}\" \"{targetDirArgument}\" --p {process.Id}"
        //    };

        //    var process1 = Process.Start(info);

        //    return process1;

        //}

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
