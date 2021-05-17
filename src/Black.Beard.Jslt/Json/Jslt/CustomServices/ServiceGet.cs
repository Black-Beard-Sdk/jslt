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
              

        public ServiceGet(string sourceName, string keySourceName)
        {
            this._sourceName = sourceName;
            this._keySourceName = keySourceName;
        }


        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            SourceJson src = ctx.SubSources[this._sourceName] 
                ?? throw new SourceNotFoundException("sourceName");

            var datas = src.Datas.SelectToken(this._keySourceName);

            if (datas != null)
                return datas;

            return JValue.CreateNull();

        }


        private readonly string _sourceName;
        private readonly string _keySourceName;
        private readonly string _keyLocalName;

    }


}
