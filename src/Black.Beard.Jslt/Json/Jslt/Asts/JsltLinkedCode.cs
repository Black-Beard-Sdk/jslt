using Bb.Asts;
using Bb.Json.Jslt.Parser;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltLinkedCode : JsltBase
    {

        public JsltLinkedCode()
        {
            this.Kind = JsltKind.Array;
            this._items = new List<JsltBase>(10);
        }

        public void Append(JsltBase item)
        {
            this._items.Add(item);
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitLinkedCode(this);
        }

        public IEnumerable<JsltBase> Items { get => _items; }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            throw new System.NotImplementedException();
        }

        private readonly List<JsltBase> _items;


    }

}
