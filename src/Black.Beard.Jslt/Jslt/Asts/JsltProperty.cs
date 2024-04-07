using Bb.Asts;
using Bb.Contracts;
using System.Collections.Generic;

namespace Bb.Jslt.Asts
{

    public static class JsltPropertyExtension
    {

        /// <summary>
        /// Set the value.
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="self">instance to set</param>
        /// <param name="value">value to push in the property</param>
        /// <returns></returns>
        public static T SetValue<T>(this T self, JsltBase value)
            where T : JsltProperty
        {
            self.Value = value;
            return self;
        }


    }



    [System.Diagnostics.DebuggerDisplay("property {Name} : {Value}")]
    public class JsltProperty : JsltBase
    {


        public JsltProperty(string name) : this()
        {
            this.Name = name;
        }

        public JsltProperty()
        {
            this.Kind = JsltKind.Property;
            _metadatas = new Dictionary<string, JsltMetadata>();
        }

        /// <summary>
        /// Name of the property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the property
        /// </summary>
        public virtual JsltBase Value { get; set; }
                 
        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitProperty(this);
        }

        public IEnumerable<JsltMetadata> Metadatas { get => _metadatas.Values; }

        public bool GetMetadata(string metadataName, out JsltMetadata metadataValue)
        {
            return _metadatas.TryGetValue(metadataName, out metadataValue);
        }

        public bool AddMetadata(string metadataName, JsltMetadata metadataValue)
        {

            if (_metadatas.ContainsKey(metadataName))
                return false;
            
            _metadatas.Add(metadataName, metadataValue);

            return true;

        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            writer.Append($"{Quote}{Name}{Quote} : ");
            
            if (Value != null)
            {

                if (Value is JsltObject)
                    writer.AppendEndLine();

                else if (Value is JsltArray)
                    writer.AppendEndLine();

                writer.ToString(Value);

            }
            else
                writer.Append("null");

            strategy.ApplyIndentLineAfterStarting(writer);
            strategy.ApplyReturnLineAfterStarting(writer);

            strategy.ApplyIndentLineBeforeEnding(writer);
            strategy.ApplyReturnLineBeforeEnding(writer);
            
            return true;

        }

        private Dictionary<string, JsltMetadata> _metadatas { get; set; }


    }

}
