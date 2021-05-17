using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;

namespace Bb.Json.Jslt.CustomServices
{


    /// <summary>
    /// return the crc32 of the value
    /// if one of the term is not a number
    /// </summary>
    [JsltExtensionMethod("convert")]
    public class ServiceConvert : ITransformJsonService
    {

        public ServiceConvert(object data,  Type type)
        {
            this.Data = data;
            this.TargetType = type;
        }

        public object Data { get; }
        public Type TargetType { get; }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {
            if (Data is JValue v)
                return new JValue(Convert.ChangeType(v.Value, this.TargetType));
            return token;
        }

    }

}
