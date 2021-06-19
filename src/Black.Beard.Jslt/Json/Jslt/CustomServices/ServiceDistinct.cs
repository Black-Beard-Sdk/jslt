using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.Json.Jslt.CustomServices
{

    /// <summary>
    /// return a list of key with no duplicated values
    /// Display name is the key used in the template
    /// </summary>
    [JsltExtensionMethod("distinct")]
    public class ServiceDistinct : ITransformJsonService
    {

        public ServiceDistinct()
        {
            this._true = new JValue(true);
            this._false = new JValue(false);
        }

        public JToken Execute(RuntimeContext ctx, JToken token)
        {

            if (token != null && token is JValue j)
                if (_index.Add(j.Value))
                    return _true;

            return _false;

        }

        private HashSet<object> _index = new HashSet<object>();
        
        private readonly JValue _true;
        private readonly JValue _false;

    }

}
