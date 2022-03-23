using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {

        [JsltExtensionMethod("select")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("sourcePath", "filter")]
        public static JToken ExecuteSelectOne(RuntimeContext ctx, JToken source, string filter)
        {

            if (source != null)
                return source.SelectToken(filter);

            return JValue.CreateNull();

        }

        [JsltExtensionMethod("selectmany")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("sourcePath", "filter")]
        public static JToken ExecuteSelectMany(RuntimeContext ctx, JToken source, string filter)
        {

            var resultValue = new JArray();

            if (source != null)
            {
                var items = source.SelectTokens(filter);
                foreach (var item in items)
                    resultValue.Add(item);
            }

            return resultValue;

        }

        [JsltExtensionMethod("limit")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("max", "max item to result")]
        public static JToken ExecuteLimit(RuntimeContext ctx, JToken source, int max)
        {

            var resultValue = new JArray();

            if (source != null && source is JArray a)
            {
                foreach (var item in a.Take(max))
                    resultValue.Add(item);

                return resultValue;

            }

            return source;

        }



        [JsltExtensionMethod("distinct")]
        [JsltExtensionMethodParameter("source", "Json array that contains duplicate datas.")]
        [JsltExtensionMethodParameter("sourcePath", "json path that select the unique key")]
        public static JToken Executedistinct(RuntimeContext ctx, JToken source, string sourcePath)
        {

            var resultValue = new JArray();
            HashSet<object> _index = new HashSet<object>();

            if (source != null)
            {
                if (source is JArray a)
                {
                    ExecuteDistinct(a, sourcePath, resultValue, _index);
                }
                else
                {

                }
            }

            return resultValue;

        }

        private static void ExecuteDistinct(JArray a, string sourcePath, JArray resultValue, HashSet<object> _index)
        {
            foreach (var item in a)
            {
                JToken result = item.SelectToken(sourcePath);
                if (result != null)
                {

                    switch (result.Type)
                    {

                        case JTokenType.TimeSpan:
                        case JTokenType.Guid:
                        case JTokenType.Uri:
                        case JTokenType.Boolean:
                        case JTokenType.Integer:
                        case JTokenType.Float:
                        case JTokenType.Date:
                        case JTokenType.String:
                        case JTokenType.Bytes:
                            var v2 = result as JValue;
                            if (_index.Add(v2.Value))
                            {
                                resultValue.Add(item);
                            }
                            break;

                        case JTokenType.Array:
                            var a2 = result as JArray;
                            ExecuteDistinct(a2, sourcePath, resultValue, _index);
                            break;

                        case JTokenType.Object:
                            break;

                        case JTokenType.Null:
                        case JTokenType.None:
                            break;

                        case JTokenType.Constructor:
                        case JTokenType.Property:
                        case JTokenType.Comment:
                            break;

                        case JTokenType.Raw:
                            break;

                        case JTokenType.Undefined:
                        default:
                            break;

                    }

                }
            }
        }

    }

}
