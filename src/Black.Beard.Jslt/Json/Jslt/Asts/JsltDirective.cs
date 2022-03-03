namespace Bb.Json.Jslt.Asts
{
    public class JsltDirective : JsltProperty
    {

        public JsltDirective()
        {
            this.Kind = JsltKind.Property;
        }
       

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitDirective(this);
        }

    }

}
