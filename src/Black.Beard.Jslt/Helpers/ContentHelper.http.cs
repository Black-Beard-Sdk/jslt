using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bb
{


    /*
      using (var fs = new FileStream(
                HostingEnvironment.MapPath(string.Format("~/Downloads/{0}.pdf", pdfGuid)),
                FileMode.CreateNew))
            {
                await response.Content.CopyToAsync(fs);
            }


     */

    public static partial class ContentHelper
    {


        public static void Download(this Uri url, FileInfo fileOutput)
        {

            fileOutput.Refresh();
            if (fileOutput.Exists)
                throw new FileLoadException("local file allready exists");

            //var uriBuilder = new UriBuilder();
            //uriBuilder.Scheme = url.Scheme;
            //uriBuilder.Host = url.Host;
            //_httpClient.BaseAddress = new Uri(uriBuilder.ToString());

            //client.DefaultRequestHeaders.Accept.Clear();
            ////client.DefaultRequestHeaders.Add("authorization", access_token); //if any
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {

                System.Net.Http.HttpContent content = response.Content;

                using (var fs = new FileStream(fileOutput.FullName, FileMode.CreateNew))
                    content.CopyToAsync(fs);

            }
            else
                throw new FileNotFoundException();

        }


        private static HttpClient _httpClient = new HttpClient();

    }


}
