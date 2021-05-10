namespace Bb.Json.Jslt.Asts
{
    public class JsltCase : JsltJson
    {

        public JsltCase()
        {

        }


        public JsltJson RightExpression { get; set; }

        public JsltJson Block { get; set; }

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
