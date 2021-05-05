namespace Bb.Json.Jslt.Asts
{

    public class JsltProperty : JsltJson
    {

        public JsltProperty()
        {
            this.Kind = JsltKind.Property;
        }

        public string Name{ get; set; }

        public JsltJson Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitProperty(this);
        }

    }

}
