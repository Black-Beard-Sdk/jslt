using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{
    public class JsltOperator : JsltBase
    {


        public JsltOperator(JsltBase left, OperationEnum @operator)
        {
            this.Left = left;
            this.Kind = JsltKind.Operator;
            this.Operator = @operator;
        }

        public OperationEnum Operator { get; }

        public JsltBase Left { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitUnaryOperator(this);
        }

    }


}

