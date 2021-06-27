using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bb.Maj
{
    
    public static class GitHubVersionHelper
    {

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

      

    }

}
