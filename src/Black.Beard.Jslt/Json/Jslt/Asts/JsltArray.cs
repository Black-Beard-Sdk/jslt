using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltArray : JsltBase
    {

        public JsltArray(int count)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>();
        }


        internal JsltBase Append(JsltBase item)
        {
            _items.Add(item);
            return item;
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitArray(this);
        }

        //public JsltJson Item { get; internal set; }
        public List<JsltBase> Items { get => _items; }

        private readonly List<JsltBase> _items;


    }

}
