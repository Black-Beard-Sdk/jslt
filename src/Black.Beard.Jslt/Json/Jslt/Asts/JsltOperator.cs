using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{
    public class JsltOperator : JsltJson
    {


        public JsltOperator(JsltJson left, OperationEnum @operator)
        {
            this.Left = left;
            this.Kind = JsltKind.Operator;
            this.Operator = @operator;
        }

        public OperationEnum Operator { get; }

        public JsltJson Left { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitUnaryOperator(this);
        }

    }


}

