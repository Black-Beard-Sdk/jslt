using Bb.Exceptions;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Linq;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// get( "document name", 
    /// </summary>
    [JsltExtensionMethod("get")]
    public class ServiceGet : ITransformJsonService
    {

        [JsltExtensionMethodParameter("sourceName", "source name")]
        [JsltExtensionMethodParameter("jpathFilter", "json path")]
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
                ctx.Diagnostics.AddError(string.Empty, null, "jpathFilter", "jpathFilter is null or empty in the get method");
                return token;
            }

            if (this._sourceName is string s)
            {

                SourceJson src = ctx.SubSources[s];
                if (src == null)
                    ctx.Diagnostics.AddError(string.Empty, null, "sourceName", "source name is null or empty in the get method");

                datas = src.Datas;

            }
            else if (this._sourceName is JToken t)
                datas = t;

            if (datas != null)
            {
                try
                {

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
                catch (System.Exception ex)
                {
                    ctx.Diagnostics.AddError(string.Empty, null, this.jpathFilter, "json path is invalid filter in the method 'get'. " + ex.Message);
                    ctx.Break();
                }

            }

            return JValue.CreateNull();

        }


        private readonly object _sourceName;
        private readonly string jpathFilter;

    }


}
