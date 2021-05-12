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


        private readonly List<JsltBase> _items;


    }

}
