namespace Bb.Json.Jslt.Asts
{
    public class JsltComment : JsltBase
    {

        public JsltComment()
        {

        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitComment(this);
        }

    }

}
