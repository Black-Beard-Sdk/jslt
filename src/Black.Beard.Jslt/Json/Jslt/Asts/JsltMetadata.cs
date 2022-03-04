namespace Bb.Json.Jslt.Asts
{
    public class JsltMetadata : JsltConstant
    {

        public JsltMetadata()
        {

        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitMetadata(this);
        }


    }

}
