using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Bb.Maj
{

    public class SessionHttp
    {

        public SessionHttp(Uri uriRoot)
        {

            var i = Assembly.GetEntryAssembly()?.GetName()?.Name;

            this.UserAgent = i ?? ".NET client";
            this.BaseAddress = uriRoot;
            this.Cookies = new Dictionary<string, Cookie>();
        }            

        public CallHttp Get(Uri uri)
        {
            HttpWebRequest request = BuildRequest(uri);
            var c = new CallHttp();
            c.Run(this, request);
            return c;
        }

        private HttpWebRequest BuildRequest(Uri uri)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();
            request.Timeout = this.Timeout;

            var headers = request.Headers;
            headers.Clear();

            request.UserAgent = this.UserAgent;

            //headers.Add(Constants.Headers.UserAgent, this.UserAgent);

            foreach (var item in this.Cookies)
                request.CookieContainer.Add(item.Value);

            return request;

        }

        public Uri BaseAddress { get; }

        public string UserAgent { get; private set; }

        public int Timeout { get; private set; } = 15000;

        public Dictionary<string, Cookie> Cookies { get; }      

    }

    public class CallHttp
    {

        public CallHttp()
        {
            this.Headers = new Dictionary<string, string>();
        }

        public void Run(HttpWebRequest request)
        {
                 

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {

                throw;
            }



            this.Result = response.StatusCode;
            this.CharacterSet = response.CharacterSet;
            this.ContentEncoding = response.ContentEncoding;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                this.ResultBodyText = new StringBuilder(readStream.ReadToEnd());

                foreach (string headerKey in response.Headers.AllKeys)
                    this.Headers.Add(headerKey, response.Headers[headerKey]);

                foreach (Cookie cookie in response.Cookies)
                {
                    var c = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain)
                    {
                        Comment = cookie.Comment,
                        CommentUri = cookie.CommentUri,
                        Discard = cookie.Discard,
                        Expired = cookie.Expired,
                        HttpOnly = cookie.HttpOnly,
                        Expires = cookie.Expires,
                        Port = cookie.Port,
                        Secure = cookie.Secure,
                    };
                    if (context.Cookies.ContainsKey(c.Name))
                        context.Cookies[c.Name] = c;
                    else
                        context.Cookies.Add(c.Name, c);
                }

                response.Close();
                readStream.Close();

            }
        }

        public StringBuilder ResultBodyText { get; private set; }

        public HttpStatusCode Result { get; private set; }

        public string CharacterSet { get; private set; }

        public string ContentEncoding { get; private set; }

        public Dictionary<string, string> Headers { get; private set; }

    }

}
