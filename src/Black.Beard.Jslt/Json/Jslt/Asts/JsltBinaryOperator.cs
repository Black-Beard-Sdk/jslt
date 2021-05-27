using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("{Left} {Operator} {Right}")]
    public class JsltBinaryOperator : JsltOperator
    {


        public JsltBinaryOperator(JsltBase left, OperationEnum @operator, JsltBase right)
            : base (left, @operator)
        {

            this.Right = right;
        }


        public JsltBase Right { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitBinaryOperator(this);
        }


    }


}

