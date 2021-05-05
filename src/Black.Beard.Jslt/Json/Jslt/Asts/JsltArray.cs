using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltArray : JsltJson
    {

        public JsltArray(int count)
        {
            this.Kind = JsltKind.Array;
        }


        internal JsltJson Append(JsltJson item)
        {
            _items.Add(item);
            return item;
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitArray(this);
        }

        public JsltJson Item { get; internal set; }

        private readonly List<JsltJson> _items;

    }

}
