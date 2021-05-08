using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltArray : JsltJson
    {

        public JsltArray(int count)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltJson>();
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

        //public JsltJson Item { get; internal set; }
        public List<JsltJson> Items { get => _items; }

        private readonly List<JsltJson> _items;


    }

    public class JsltLinkedCode : JsltJson
    {

        public JsltLinkedCode()
        {
            this.Kind = JsltKind.Array;
            this._items = new List<JsltJson>(10);
        }

        public void Append(JsltJson item)
        {
            this._items.Add(item);
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitLinkedCode(this);
        }

        public IEnumerable<JsltJson> Items { get => _items; }


        private readonly List<JsltJson> _items;


    }

}
