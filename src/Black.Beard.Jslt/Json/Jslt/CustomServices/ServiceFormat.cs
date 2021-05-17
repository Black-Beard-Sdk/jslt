using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return a formated value
    /// </summary>
    [JsltExtensionMethod("format")]
    public class ServiceFormat : ITransformJsonService
    {

        public ServiceFormat()
        {

        }

        public string Mask { get; set; }

        public string Culture { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {
            
            if (token is JValue v)
            {

                CultureInfo culture = CultureInfo.InvariantCulture;
                if (!string.IsNullOrEmpty(Culture))
                    culture = CultureInfo.GetCultureInfo(Culture);

                if (v.Type == JTokenType.Integer)
                {
                    var i = v.Value<int>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Float)
                {
                    var i = v.Value<double>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Date)
                {
                    var i = v.Value<DateTime>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.TimeSpan)
                {
                    var i = v.Value<TimeSpan>();
                    return new JValue(i.ToString(Mask, culture));
                }
                if (v.Type == JTokenType.Guid)
                {
                    var i = v.Value<Guid>();
                    return new JValue(i.ToString(Mask, culture));
                }

                return new JValue(v.Value.ToString());

            }

            return new JValue(token.ToString());
        }

    }

}
