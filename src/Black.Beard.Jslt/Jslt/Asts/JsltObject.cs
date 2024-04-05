using Bb.Asts;
using Bb.Contracts;
using Bb.Jslt.Services;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Jslt.Asts
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
            
            if (name.StartsWith("@"))
                Append(new JsltVariable()
                {
                    Name = name,
                    Value = value
                });

            else
                Append(new JsltProperty()
                {
                    Name = name,
                    Value = value
                });

            return this;

        }

        /// <summary>
        /// add a new property to the object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public JsltObject Append(JsltDirectives value)
        {
            _items.Add(value.Name, value);
            return this;
        }

        /// <summary>
        /// add a new variable to the object
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public JsltObject Append(JsltVariable variable)
        {
            _varItems.Add(variable.Name, variable);
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

        /// <summary>
        /// List of properties
        /// </summary>
        public IEnumerable<JsltProperty> Properties { get => _items.Values; }

        /// <summary>
        /// List of variables
        /// </summary>
        public IEnumerable<JsltVariable> Variables { get => _varItems.Values; }

        /// <summary>
        /// Name of the object
        /// </summary>
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

            var properties = this.Properties.ToList();

            bool AddComma = false;

            writer.Append("{");
            writer.AddIndent();
            writer.AppendEndLine();

            AddComma = WriteDirectives(writer, properties, AddComma);
            AddComma = WriteSource(writer, strategy, AddComma);
            AddComma = WriteWhere(writer, strategy, AddComma);
            AddComma = WriteVariables(writer, AddComma);
            AddComma = WriteProperties(writer, properties, AddComma);

            writer.DelIndent();
            writer.AppendEndLine();
            writer.Append("}");

            return true;

        }

        private bool WriteProperties(Writer writer, List<JsltProperty> properties, bool AddComma)
        {
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

            return AddComma;
        }

        private bool WriteVariables(Writer writer, bool AddComma)
        {
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

                AddComma = true;

            }

            return AddComma;
        }

        private bool WriteWhere(Writer writer, StrategySerializationItem strategy, bool AddComma)
        {
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

            return AddComma;
        }

        private bool WriteSource(Writer writer, StrategySerializationItem strategy, bool AddComma)
        {
            var s = this.Source;
            if (this.Source != null)
            {
                writer.Append($"{Quote}$source{Quote} : ");
                this.Source.ToString(writer, strategy);
                AddComma = true;
            }

            return AddComma;
        }

        private static bool WriteDirectives(Writer writer, List<JsltProperty> properties, bool AddComma)
        {
            if (properties.Count > 0)
            {
                var directive = properties.FirstOrDefault(c => c.Name == JsltDirectives.Key);
                if (directive != null)
                {
                    writer.ToString(directive);
                    properties.Remove(directive);
                    AddComma = true;
                }
            }

            return AddComma;
        }
    }

}
