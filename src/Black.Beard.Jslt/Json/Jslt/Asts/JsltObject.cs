using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltObject : JsltBase
    {


        public JsltObject()
        {
            this.Kind = JsltKind.Object;
            this._items = new Dictionary<string, JsltProperty>();
            this._varItems = new Dictionary<string, JsltVariable>();
        }

        internal void Append(JsltProperty property)
        {

            if (property is JsltVariable v)
                _varItems.Add(v.Name, v);
            
            else if (property.Name == TransformJsonConstants.Source)
                this.Source = property.Value;

            else if (property.Name == TransformJsonConstants.Where)
                this.Where = property.Value;

            else if (property.Name == TransformJsonConstants.Type)
                this.Name = property.Value.ToString();

            else
                _items.Add(property.Name, property);
        }

        public IEnumerable<JsltProperty> Properties { get => _items.Values; }

        public IEnumerable<JsltVariable> Variables { get => _varItems.Values; }

        public string Name { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitObject(this);
        }

        private readonly Dictionary<string, JsltProperty> _items;
        private readonly Dictionary<string, JsltVariable> _varItems;

        internal void AddProperty(JsltProperty prop)
        {
            this._items.Add(prop.Name, prop);
        }

    }

}
