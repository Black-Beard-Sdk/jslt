using Bb.Attributes;
using Bb.JPaths;
using Bb.Jslt.Services;
using Bb.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Jslt.CustomServices
{



    public static partial class CServices
    {

        [JsltExtensionMethod("select")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("sourcePath", "filter")]
        public static JToken ExecuteSelectOne(RuntimeContext ctx, JToken source, JsonPath filter)
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

            if (source != null)
                return new JArray(source.SelectTokens(filter));

            return new JArray();

        }


        [JsltExtensionMethod("selectany", "return true if the filter matches")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("sourcePath", "filter")]
        public static JToken ExecuteSelectAny(RuntimeContext ctx, JToken source, string filter)
        {

            if (source != null)
            {
                var items = source.SelectTokens(filter).Any();
                return new JValue(items);
            }

            return new JValue(false);

        }

        [JsltExtensionMethod("any", "return true if source is not null and contains one or more items")]
        [JsltExtensionMethodParameter("source", "source of data")]
        public static JToken ExecuteAny(RuntimeContext ctx, JToken source)
        {
            var items = source != null && source is JArray a && a.Count > 0;
            return new JValue(items);
        }

        [JsltExtensionMethod("contains", "return true if source contains the specified item")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("toMatch", "source of data")]
        public static JToken ExecuteContains(RuntimeContext ctx, JToken source, JToken toMatch)
        {
            if (source is JArray a)
            {
                foreach (var item in a)
                {
                    var p = (JValue)RuntimeContext.EvaluateBinaryOperator(ctx, item, Parser.OperationEnum.Equal, toMatch);
                    if (object.Equals(p.Value, true))
                        return true;
                }
            }
            else
            {
                LocalDebug.Stop();
            }

            return new JValue(false);
        }

        [JsltExtensionMethod("limit")]
        [JsltExtensionMethodParameter("source", "source of data")]
        [JsltExtensionMethodParameter("max", "max item to result")]
        public static JToken ExecuteLimit(RuntimeContext ctx, JToken source, int max)
        {


            if (source != null && source is JArray a)
            {

                var resultValue = new List<JToken>(max);

                foreach (var item in a.Take(max))
                    resultValue.Add(item);

                return new JArray(resultValue);

            }

            return source;

        }


        [JsltExtensionMethod("distinct")]
        [JsltExtensionMethodParameter("source", "Json array that contains duplicated datas.")]
        [JsltExtensionMethodParameter("sourcePath", "json path that select the unique key")]
        public static JArray ExecuteDistinct(RuntimeContext ctx, JToken source, JsonPath sourcePath)
        {

            List<JToken> resultValue = null;
            HashSet<object> _index = new HashSet<object>();

            if (source != null)
            {
                if (source is JArray a)
                {
                    resultValue = new List<JToken>(a.Count);
                    ExecuteDistinct(a, sourcePath, resultValue, _index);
                }
                else
                {
                    LocalDebug.Stop();
                }
            }

            return new JArray(resultValue);

        }

        private static void ExecuteDistinct(JArray a, JsonPath sourcePath, List<JToken> resultValue, HashSet<object> _index)
        {

            var  pp = a.SelectTokens(sourcePath).ToList();
            foreach (var item in pp)
            {
                switch (item.Type)
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
                        var v2 = item as JValue;
                        if (_index.Add(v2.Value))
                            resultValue.Add(item);

                        break;

                    case JTokenType.Array:
                        var a2 = item as JArray;
                        if (_index.Add(a2.GetHashCode()))
                            resultValue.Add(item);                        
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
