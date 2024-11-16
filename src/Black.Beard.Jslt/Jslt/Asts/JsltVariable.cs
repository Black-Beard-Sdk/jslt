using Bb.Asts;
using Bb.Contracts;
using System;

namespace Bb.Jslt.Asts
{

    /// <summary>
    /// Represents a variable in a Jslt.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("variable {Name} : {Value}")]
    public class JsltVariable : JsltProperty
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltVariable"/> class.
        /// </summary>
        /// <param name="name">name of the variable</param>
        public JsltVariable(string name)
        {
            Kind = JsltKind.JVariable;
            this.Name = name;
            if (this.Name.EndsWith(":"))
                this.Name = this.Name.Substring(0, this.Name.Length - 1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltVariable"/> class.
        /// </summary>
        public JsltVariable()
        {
            Kind = JsltKind.JVariable;
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitJVariable(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {


            if (Value != null)
            {
                writer.Append($"\"{Name}:\"");
                writer.Append(" : ");
                writer.ToString(Value);
            }
            else
               writer.Append(Name + ":");

            return true;
        }

        public bool ToDestruct { get; set; }
        
        public Type TargetType { get; set; }

    }

}
