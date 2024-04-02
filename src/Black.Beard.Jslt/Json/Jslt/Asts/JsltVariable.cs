using Bb.Asts;
using Bb.Contracts;

namespace Bb.Json.Jslt.Asts
{

    /// <summary>
    /// Represents a variable in a Jslt.
    /// </summary>
    public class JsltVariable : JsltProperty
    {

        public JsltVariable(string name)
        {
            Kind = JsltKind.JVariable;
            this.Name = name;
            if (this.Name.StartsWith("@"))
                this.Name = this.Name.Substring(1);
        }

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
            writer.Append($"@{Name}");
            return true;
        }

        public bool ToDestruct { get; set; }

    }

}
