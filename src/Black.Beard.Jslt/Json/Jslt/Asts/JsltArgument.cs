using Bb.Asts;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("arg {Name}={Value}")]
    public class JsltArgument : JsltBase
    {

        public JsltArgument()
        {
            this.Kind = JsltKind.Property;
        }

        public string Name { get; set; }

        public JsltBase Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitArgument(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            return writer.ToString(Value);
        }

    }

}
