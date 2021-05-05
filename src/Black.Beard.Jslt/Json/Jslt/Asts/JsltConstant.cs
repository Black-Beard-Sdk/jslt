using System;

namespace Bb.Json.Jslt.Asts
{

    public class JsltConstant : JsltJson
    {

        public JsltConstant()
        {

        }

        public object Value { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitConstant(this);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }

}
