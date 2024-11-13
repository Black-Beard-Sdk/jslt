using Bb.Attributes;
using Bb.Jslt.Services;
using Bb.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Bb.Jslt.Parser;

namespace Bb.Jslt.CustomServices
{

    public static partial class CServices
    {

        [JsltExtensionMethod("loadhttpgetJson")]
        [JsltExtensionMethodParameter("rootPath", "root path")]
        [JsltExtensionMethodParameter("methodName", "method name")]
        public static JToken ExecutehttpGetJson(RuntimeContext ctx, string rootPath, string methodName)
        {

            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(rootPath) })
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var i = client.GetAsync(methodName, HttpCompletionOption.ResponseContentRead);
                i.Wait();
                var result = i.Result;

                if (result.IsSuccessStatusCode)
                {

                    var taskResulString = result.Content.ReadAsStringAsync();
                    taskResulString.Wait();

                    try
                    {
                        return JToken.Parse(taskResulString.Result);
                    }
                    catch (Exception)
                    {
                        ctx.Diagnostics.AddWarning(string.Empty, null, "", "The result value of the web api can't be converted in json object");
                    }

                }
                else
                {
                    ctx.Diagnostics.AddWarning(string.Empty, null, result.StatusCode.ToString(), $"the api call has return failed result code '{result.StatusCode}'");
                }

                return JValue.CreateNull();

            }

        }

    }

}
