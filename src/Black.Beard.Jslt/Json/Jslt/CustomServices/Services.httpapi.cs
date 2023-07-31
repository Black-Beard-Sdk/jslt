using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
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
