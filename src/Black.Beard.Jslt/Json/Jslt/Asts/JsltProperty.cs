using Bb.Asts;
using Oldtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("property {Name} : {Value}")]
    public class JsltProperty : JsltBase
    {

        public JsltProperty()
        {
            this.Kind = JsltKind.Property;
            _metadatas = new Dictionary<string, JsltMetadata>();
        }

        public string Name { get; set; }

        public virtual JsltBase Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitProperty(this);
        }

        public IEnumerable<JsltMetadata> Metadatas { get => _metadatas.Values; }

        public bool GetMetadata(string metadataName, out JsltMetadata metadataValue)
        {
            return _metadatas.TryGetValue(metadataName, out metadataValue);
        }

        public bool AddMetadata(string metadataName, JsltMetadata metadataValue)
        {

            if (_metadatas.ContainsKey(metadataName))
                return false;
            
            _metadatas.Add(metadataName, metadataValue);

            return true;

        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {


            strategy.ApplyReturnLineBeforeStarting(writer);
            writer.Append($"{Quote}{Name}{Quote} : ");
            strategy.ApplyReturnLineAfterStarting(writer);


            if (Value != null)
            {

                if (Value is JsltObject)
                    writer.AppendEndLine();

                else if (Value is JsltArray)
                    writer.AppendEndLine();

                writer.ToString(Value);

            }
            else
                writer.Append("null");

            return true;

        }

        private Dictionary<string, JsltMetadata> _metadatas { get; set; }


    }

}
