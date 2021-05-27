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


        public ServiceGet(object sourceName, string keySourceName)
        {
            this._sourceName = sourceName;
            this._keySourceName = keySourceName;
        }


        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            JToken datas = null;

            if (this._sourceName is string s)
            {
                SourceJson src = ctx.SubSources[s]
                ?? throw new SourceNotFoundException("sourceName");
                datas = src.Datas.SelectToken(this._keySourceName);
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
                var result = datas.SelectToken(this._keySourceName);
                return result;
            }

            return JValue.CreateNull();

        }


        private readonly object _sourceName;
        private readonly string _keySourceName;

    }


}
