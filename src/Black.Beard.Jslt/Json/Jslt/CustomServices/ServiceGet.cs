using Bb.Exceptions;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;


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

            if (this._sourceName is string s)
            {
                SourceJson src = ctx.SubSources[s]
                ?? throw new SourceNotFoundException("sourceName");
                datas = src.Datas.SelectToken(this.jpathFilter);
            }
            else if (this._sourceName is JToken t)
            {
                datas = t;
            }
            else
            {

            }

            if (datas != null)
            {
                var result = datas.SelectToken(this.jpathFilter);
                return result;
            }

            return JValue.CreateNull();

        }


        private readonly object _sourceName;
        private readonly string jpathFilter;

    }


}
