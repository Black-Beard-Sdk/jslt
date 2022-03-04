using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("property {Name} : {Value}")]
    public class JsltProperty : JsltBase
    {

        public JsltProperty()
        {
            this.Kind = JsltKind.Property;
            _metadatas = new Dictionary<string, JToken>();
        }

        public string Name { get; set; }

        public JsltBase Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitProperty(this);
        }

        public bool GetMetadata(string metadataName, out JToken metadataValue)
        {
            return _metadatas.TryGetValue(metadataName, out metadataValue);
        }

        public bool AddMetadata(string metadataName, JToken metadataValue)
        {

            if (_metadatas.ContainsKey(metadataName))
                return false;
            
            _metadatas.Add(metadataName, metadataValue);

            return true;

        }

        private Dictionary<string, JToken> _metadatas { get; set; }

    }

}
