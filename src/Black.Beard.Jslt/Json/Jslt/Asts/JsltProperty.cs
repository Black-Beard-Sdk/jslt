namespace Bb.Json.Jslt.Asts
{

    public class JsltProperty : JsltBase
    {

        public JsltProperty()
        {
            this.Kind = JsltKind.Property;
        }

        public string Name{ get; set; }

        public JsltBase Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitProperty(this);
        }

    }

}
