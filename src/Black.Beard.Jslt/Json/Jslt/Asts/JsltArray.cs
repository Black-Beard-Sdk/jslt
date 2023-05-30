using Bb.Asts;
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

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append("[");

            using (writer.Indent())
            {
                
                writer.AppendEndLine();

                writer.ToString(_items[0]);

                if (_items.Count > 0)
                    for (int i = 1; i < _items.Count; i++)
                    {

                        writer.AppendEndLine(",");
                        writer.ToString(_items[i]);
                    }

            }
            writer.AppendEndLine();
            writer.Append("]");

            return true;

        }

        //public JsltJson Item { get; internal set; }
        public List<JsltBase> Items { get => _items; }

        private readonly List<JsltBase> _items;


    }

}
