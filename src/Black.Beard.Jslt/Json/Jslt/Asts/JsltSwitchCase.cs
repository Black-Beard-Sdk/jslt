using Bb.Asts;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("case {RightExpression}")]
    public class JsltSwitchCase : JsltBase
    {

        public JsltSwitchCase()
        {

        }


        public JsltBase RightExpression { get; set; }

        public JsltBase Block { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitCase(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            RightExpression.ToString(writer, strategy);
            writer.Append(" : ");
            Block.ToString(writer, strategy);

            return true;

        }

    }

}
