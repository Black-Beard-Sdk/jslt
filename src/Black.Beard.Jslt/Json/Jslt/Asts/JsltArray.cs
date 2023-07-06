using Bb.Asts;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{


    public class JsltArray : JsltBase
    {

        public JsltArray(int count)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>(count);
        }

        public JsltArray(IEnumerable<JsltBase> items)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>(items);
        }

        public JsltBase Append(JsltBase item)
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

            var newLine = _items.Count > 1;
            strategy.ApplyReturnLineBeforeStarting(writer);
            writer.Append("[");
            strategy.ApplyReturnLineAfterStarting(writer);

            using (writer.Indent(strategy))
            {

                writer.AppendEndLine();

                strategy.ApplyReturnLineBeforeItems(writer);
                writer.ToString(_items[0]);

                if (_items.Count > 0)
                    for (int i = 1; i < _items.Count; i++)
                    {

                        writer.Append(", ");

                        if (newLine)
                            writer.AppendEndLine();
                        else
                            strategy.ApplyReturnLineAfterItems(writer);


                        writer.ToString(_items[i]);

                        if (i < _items.Count)
                            strategy.ApplyReturnLineAfterItems(writer);

                    }

            }
            writer.AppendEndLine();

            strategy.ApplyReturnLineBeforeEnding(writer);
            writer.Append("]");
            strategy.ApplyReturnLineAfterEnding(writer);

            return true;

        }

        public List<JsltBase> Items { get => _items; }

        private readonly List<JsltBase> _items;


    }

}
