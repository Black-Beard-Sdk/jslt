using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Bb.Maj
{
    public class CallHttp
    {

        public CallHttp()
        {
            this.Headers = new Dictionary<string, string>();
            this.Cookies = new Dictionary<string, Cookie>();
        }

        public void Run(HttpWebRequest request)
        {

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                this.Result = response.StatusCode;
                this.CharacterSet = response.CharacterSet;
                this.ContentEncoding = response.ContentEncoding;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader readStream = null;

                        if (String.IsNullOrWhiteSpace(response.CharacterSet))
                            readStream = new StreamReader(receiveStream);

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
                            Cookies.Add(c.Name, c);
                        }

                        response.Close();
                        readStream.Close();
                    }
                }
            }

        }

        public StringBuilder ResultBodyText { get; private set; }

        public HttpStatusCode Result { get; private set; }

        public string CharacterSet { get; private set; }

        public string ContentEncoding { get; private set; }

        public Dictionary<string, string> Headers { get; }

        public Dictionary<string, Cookie> Cookies { get; }

    }

}
