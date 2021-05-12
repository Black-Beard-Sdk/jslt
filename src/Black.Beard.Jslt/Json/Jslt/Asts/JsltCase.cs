namespace Bb.Json.Jslt.Asts
{
    public class JsltCase : JsltBase
    {

        public JsltCase()
        {

        }


        public JsltBase RightExpression { get; set; }

        public JsltBase Block { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitCase(this);
        }

        public override string ToString()
        {
            return "Case " + RightExpression.ToString();
        }

    }

}
