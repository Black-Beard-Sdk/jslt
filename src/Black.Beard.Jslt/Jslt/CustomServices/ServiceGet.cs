using Bb.Attributes;
using Bb.Contracts;
using Bb.Jslt.Services;
using Oldtonsoft.Json.Linq;
using System.Linq;

namespace Bb.Jslt.CustomServices
{

    /// <summary>
    /// get( "document name", 
    /// </summary>
    [JsltExtensionMethod("get")]
    public class ServiceGet : ITransformJsonService
    {

        [JsltExtensionMethodParameter("sourceName", "source name")]
        [JsltExtensionMethodParameter("jpathFilter", "json path or key if the source is index")]
        public ServiceGet(object sourceName, string jpathFilter)
        {
            this._sourceName = sourceName;
            this.jpathFilter = jpathFilter;
        }


        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            JToken datas = null;


            if (string.IsNullOrEmpty(jpathFilter))
            {                
                ctx.Diagnostics.AddError(ctx.GetCurrentLocation(), "jpathFilter", "jpathFilter is null or empty in the get method");
                return token;
            }

            if (this._sourceName is string s)
            {

                SourceJson src = ctx.SubSources[s];
                if (src == null)
                    ctx.Diagnostics.AddError(ctx.GetCurrentLocation(), "sourceName", "source name is null or empty in the get method");

                datas = src.Datas;

            }
            else if (this._sourceName is JToken t)
            {
                datas = t;
            }

            if (datas != null)
            {

                if (datas is JDictionaryValue dic)
                {

                    if (dic.TryGetValue(this.jpathFilter, out datas))
                        return datas;

                    return JValue.CreateNull();

                }

                var result = datas.SelectTokens(this.jpathFilter).ToList();

                if (result.Count == 1)
                    return result[0];

                if (result.Count == 0)
                    return JValue.CreateNull();

                else
                {
                    var a = new JArray(result);
                    return a;
                }

            }

            return JValue.CreateNull();

        }


        private readonly object _sourceName;
        private readonly string jpathFilter;

    }


}
