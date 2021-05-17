using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return a sub part of the initial Text from the 'start' position and from length 'Lenght'
    /// </summary>
    [JsltExtensionMethod("substr")]
    public class ServiceSubStr : ITransformJsonService
    {

        public ServiceSubStr()
        {

        }

        public string Text { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {
            return new JValue( Text.Substring(Start, Length) );
        }

    }

}
