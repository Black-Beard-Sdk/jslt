using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Bb.Maj
{

    public static partial class ContentHelper
    {

        public static bool Extract(this FileInfo file, DirectoryInfo target)
        {
            try
            {
                ZipFile.ExtractToDirectory(file.FullName, target.FullName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DownloadFile(this Uri address, FileInfo file)
        {
            try
            {
                WebClient mywebClient = new WebClient();
                mywebClient.DownloadFile(address, file.FullName);
                file.Refresh();
                return true && file.Exists;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static HttpWebRequest GetRequest(this Uri uri, Dictionary<string, Cookie> cookies = null)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();
            request.Timeout = 15000;

            var headers = request.Headers;
            headers.Clear();

            request.UserAgent = GetUserAgent();
            headers.Add(Constants.Headers.UserAgent, request.UserAgent);

            if (cookies != null)
                foreach (var item in cookies)
                    request.CookieContainer.Add(item.Value);

            return request;

        }

        public static string LoadContentFromUrl(this HttpWebRequest request)
        {

            var call = new CallHttp();
            call.Run(request);

            return call.ResultBodyText.ToString();

            //if (fileContents.StartsWith("ï»¿"))
            //    fileContents = fileContents.Substring(3);

            //if (encoding != System.Text.Encoding.UTF8)
            //{
            //    var datas = System.Text.Encoding.UTF8.GetBytes(fileContents);
            //    fileContents = System.Text.Encoding.UTF8.GetString(datas);
            //}

            //return fileContents;

        }

        private static string GetUserAgent()
        {
            var i = System.Reflection.Assembly.GetEntryAssembly()?.GetName()?.Name;
            return i ?? ".NET client";
        }

    }

}
