using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace Bb.Jslt.Builds
{
    internal static class Packages
    {

        static Packages()
        {

            var version = RuntimeInformation.FrameworkDescription
                .Split('-')[0]
                .Substring(1)
                .Replace(" ", "")
                .ToLower();

            var versions = version.Split('.');
            version = versions[0] + "." + versions[1];

            Packages.CurrentRuntime = version;

        }

        public static string CurrentRuntime { get; }


        internal static DirectoryInfo EnsurePackageIsLoaded(string rootUrl, string packageName, string outputPath)
        {
            var p = Path.Combine(outputPath, packageName);
            var outpath = new DirectoryInfo(p);
            outpath.Refresh();
            if (!outpath.Exists)
            {
                var file = DownloadPackage(rootUrl, packageName);
                //var file = new FileInfo(@"C:\Users\g.beard\Downloads\newtonsoft.json.13.0.1.nupkg");
                file.Uncompress(outpath);
            }

            var libFolder = ResolveFolder(outpath);

            return new DirectoryInfo(libFolder);

        }

        /// <summary>
        /// Return the folder that contains all lib.
        /// </summary>
        /// <param name="outpath"></param>
        /// <returns></returns>
        private static string ResolveFolder(DirectoryInfo outpath)
        {

            DirectoryInfo netstandard10 = null;
            DirectoryInfo netstandard13 = null;
            DirectoryInfo netstandard20 = null;
            DirectoryInfo finalLib = null;

            var folderLib = new DirectoryInfo(Path.Combine(outpath.FullName, "lib"));
            var directories = folderLib.GetDirectories();
            foreach (var item in directories)
            {

                var name = item.Name;

                switch (name)
                {
                    case "netstandard1.0":
                        netstandard10 = item;
                        break;

                    case "netstandard1.3":
                        netstandard13 = item;
                        break;
                    case "netstandard2.0":
                        netstandard20 = item;
                        break;

                    default:
                        if (Packages.CurrentRuntime == name)
                            finalLib = item;
                        break;
                }

            }

            if (finalLib == null)
            {

                if (netstandard20 != null)
                    finalLib = netstandard20;

                else if (netstandard13 != null)
                    finalLib = netstandard13;

                else if (netstandard10 != null)
                    finalLib = netstandard10;

            }

            return finalLib?.FullName ?? String.Empty;

        }

        private static FileInfo DownloadPackage(string rootUrl, string packageName)
        {

            Uri rootPath = new Uri(rootUrl + packageName);
            FileInfo file = new FileInfo(Path.Combine(Path.GetTempPath(), packageName + ".nupkg"));

            file.Refresh();

            if (file.Exists)
                file.Delete();

            ContentHelper.Download(rootPath, file, c => { });

            return file;

        }

    }



}
