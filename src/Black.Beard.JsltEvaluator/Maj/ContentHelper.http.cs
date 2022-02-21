using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bb.Maj
{

    public static partial class ContentHelper
    {

        public static async Task<bool> Extract(this FileInfo file, DirectoryInfo target)
        {

            return await Task.Run<bool>(() =>
            {

                var dte = DateTime.Now.AddMinutes(1);

                while (dte > DateTime.Now)
                {
                    try
                    {
                        ZipFile.ExtractToDirectory(file.FullName, target.FullName);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.TraceError(ex.Message);
                        Thread.Sleep(500);
                    }

                }

                return false;

            });

        }

        public static async Task<bool> DownloadFile(this Uri address, FileInfo file)
        {

            return await Task.Run<bool>(() =>
            {

                try
                {
                    WebClient mywebClient = new WebClient();
                    mywebClient.DownloadFileAsync(address, file.FullName);
                    file.Refresh();
                    return true && file.Exists;
                }
                catch (Exception)
                {
                    return false;
                }

            });

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

        public static async Task<string> LoadContentFromUrl(this HttpWebRequest request)
        {

            return await Task.Run<string>(() =>
            {
               var call = new CallHttp();
               call.Run(request);

               return call.ResultBodyText.ToString();

            });
        }

        private static string GetUserAgent()
        {
            var i = System.Reflection.Assembly.GetEntryAssembly()?.GetName()?.Name;
            return i ?? ".NET client";
        }

    }

}
