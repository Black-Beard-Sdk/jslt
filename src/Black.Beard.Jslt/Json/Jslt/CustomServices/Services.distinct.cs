﻿using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {


        [JsltExtensionMethod("distinct")]
        [JsltExtensionMethodParameter("sourcePath", "directory source path")]
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