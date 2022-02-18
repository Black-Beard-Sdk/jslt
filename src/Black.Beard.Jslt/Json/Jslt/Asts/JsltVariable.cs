namespace Bb.Json.Jslt.Asts
{
    public class JsltVariable : JsltProperty
    {

        public JsltVariable()
        {
            Kind = JsltKind.JVariable;
        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitJVariable(this);
        }

        public bool ToDesctruct { get; set; }

    }

}
