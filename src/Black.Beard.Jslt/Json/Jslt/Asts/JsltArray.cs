using Bb.Asts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    /// <summary>
    /// Represents an array in a Jslt.
    /// </summary>
    public class JsltArray : JsltBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltArray"/> class.
        /// </summary>
        public JsltArray()
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltArray"/> class.
        /// </summary>
        /// <param name="count"></param>
        public JsltArray(int count)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>(count);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltArray"/> class.
        /// </summary>
        /// <param name="items"></param>
        public JsltArray(IEnumerable<JsltBase> items)
        {
            this.Kind = JsltKind.Array;
            _items = new List<JsltBase>(items);
        }

        /// <summary>
        /// Append an item to the array
        /// </summary>
        /// <param name="item">item to add in the array</param>
        /// <returns></returns>
        public JsltArray Append(JsltBase item)
        {
            _items.Add(item);
            return this;
        }

        /// <summary>
        /// Append an item to the array
        /// </summary>
        /// <param name="items">List of item to add in the array</param>
        /// <returns></returns>
        public JsltArray Append(params JsltBase[] items)
        {
            _items.AddRange(items);
            return this;
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitArray(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append("[");
            writer.AddIndent();
            writer.AppendEndLine();
   
            writer.ToString(_items[0]);

            if (_items.Count > 0)
                for (int i = 1; i < _items.Count; i++)
                {
                    writer.AppendEndLine(", ");
                    writer.ToString(_items[i]);
                }

            writer.DelIndent();
            writer.AppendEndLine();
            writer.Append("]");

            return true;

        }

        public JsltBase this[int index] => _items[index];

        public List<JsltBase> Items { get => _items; }

        public int Count { get => _items.Count; }

        private readonly List<JsltBase> _items;


    }

}
