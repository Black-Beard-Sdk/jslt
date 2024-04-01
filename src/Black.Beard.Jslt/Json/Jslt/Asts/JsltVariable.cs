using Bb.Asts;

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
