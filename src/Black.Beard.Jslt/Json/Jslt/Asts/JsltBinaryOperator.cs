using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{
    public class JsltBinaryOperator : JsltOperator
    {


        public JsltBinaryOperator(JsltJson left, OperationEnum @operator, JsltJson right)
            : base (left, @operator)
        {

            this.Right = right;
        }


        public JsltJson Right { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitBinaryOperator(this);
        }


    }


}

