using Bb.Asts;
using Bb.Contracts;
using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// add a new property to the object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public JsltObject Append(string name, JsltBase value)
        {
            Append(new JsltProperty()
            {
                Name = name,
                Value = value
            });

            return this;

        }

        /// <summary>
        /// ad a new property to the object
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public JsltObject Append(JsltProperty property)
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

            return this;

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

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            bool AddComma = false;

            writer.Append("{");
            writer.AddIndent();
            writer.AppendEndLine();

            var s = this.Source;                   
        
            if (this.Source != null)
            {
                writer.Append($"{Quote}$source{Quote} : ");
                this.Source.ToString(writer, strategy);
                AddComma = true;
            }

            if (this.Where != null)
            {
                if (AddComma)
                {
                    writer.AppendEndLine(",");
                    AddComma = false;
                }
                writer.Append($"{Quote}$where{Quote} : ");
                this.Where.ToString(writer, strategy);
                AddComma = true;
            }

            var variables = this.Variables.ToList();

            if (variables.Count > 0)
            {

                if (AddComma)
                {
                    writer.AppendEndLine(",");
                    AddComma = false;
                }
                writer.ToString(variables[0]);
                
                if (_items.Count > 1)
                    for (int i = 1; i < variables.Count; i++)
                    {
                        writer.AppendEndLine(",");
                        writer.ToString(variables[i]);
                    }
            }

            var properties = this.Properties.ToList();
            if (properties.Count > 0)
            {
                if (AddComma)
                {
                    writer.AppendEndLine(",");
                    AddComma = false;
                }

                writer.ToString(properties[0]);

                if (_items.Count > 1)
                    for (int i = 1; i < properties.Count; i++)
                    {
                        writer.AppendEndLine(",");
                        writer.ToString(properties[i]);
                    }
            }

            writer.DelIndent();
            writer.AppendEndLine();
            writer.Append("}");

            return true;

        }


    }

}
