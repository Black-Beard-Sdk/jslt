namespace Bb.Json.Jslt.Asts
{
    public class JsltMapProperty : JsltJson
    {

        public JsltMapProperty()
        {
            this.Kind = JsltKind.Property;
        }

        public string Name { get; set; }

        public JsltJson Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitMapProperty(this);
        }

    }

}
