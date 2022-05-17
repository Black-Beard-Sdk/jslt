using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using HtmlAgilityPack;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Jslt.Services.Html
{

    public static class ServiceHtml
    {


        [JsltExtensionMethod("loadhtml", "load and convert html in json.")]
        [JsltExtensionMethodParameter("path", "path to load and parse. the path can be file or an url")]
        public static JToken LoadHtml(RuntimeContext ctx, string path)
        {

            Uri uri = new Uri(path);

            var converter = new HtmlToJson();

            if (uri.IsFile)
            {

                var file = ctx.Configuration.ResolveFile(path);
                if (file.Exists)
                    return converter.ConvertFromFile(path);

                else
                    throw new Exception($"html source not found {file.FullName}");

            }

            return converter.ConvertFromUrl(path);

        }

    }


    public class HtmlToJson
    {

        public HtmlToJson()
        {

        }

        /// <summary>
        /// Download web page and convert html in <see cref="JToken"/>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JToken ConvertFromUrl(string url)
        {
            // From Web
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return Convert(doc.DocumentNode);
        }

        /// <summary>
        /// load web page form file and convert html in <see cref="JToken"/>
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JToken ConvertFromFile(string filePath)
        {
            // From File
            var doc = new HtmlDocument();
            doc.Load(filePath);
            return Convert(doc.DocumentNode);
        }

        /// <summary>
        /// Convert html in <see cref="JToken"/>
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public JToken ConvertFromText(string payload)
        {
            // From String
            var doc = new HtmlDocument();
            doc.LoadHtml(payload);
            return Convert(doc.DocumentNode);
        }

        private JToken? Convert(HtmlNode node)
        {

            switch (node.Name)
            {

                case "#text":
                    var txt = (node as HtmlTextNode).Text;
                    if (!string.IsNullOrEmpty(txt) && !string.IsNullOrWhiteSpace(txt))
                        return new JValue(node.Name + ": " + txt);
                    return null;

                case "#comment":
                    var comment = (node as HtmlCommentNode).Comment;
                    if (!string.IsNullOrEmpty(comment) && !string.IsNullOrWhiteSpace(comment))
                        return new JValue(node.Name + ": " + comment);
                    return null;

                default:
                    return ParseNode(node);
            }


        }

        private JToken? ParseNode(HtmlNode node)
        {

            var result = new JObject();

            if (!string.IsNullOrEmpty(node.OriginalName))
                result.Add(new JProperty("#id", node.OriginalName));

            foreach (var item in node.Attributes)
                if (!result.ContainsKey(item.OriginalName))
                    result.Add(new JProperty(item.OriginalName, item.Value));

                else
                {

                }

            var subItems = new List<JToken>(node.ChildNodes.Count);
            foreach (var item in node.ChildNodes)
            {
                var child = Convert(item);
                if (child != null)
                    subItems.Add(child);
            }

            if (subItems.Count == 1)
                result.Add(new JProperty("content", subItems[0]));

            else if (subItems.Count > 1)
                result.Add(new JProperty("content", new JArray(subItems)));

            return result;

        }

    }


}


