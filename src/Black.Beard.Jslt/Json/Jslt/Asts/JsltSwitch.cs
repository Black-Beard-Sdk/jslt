using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{
    public class JsltSwitch : JsltBase
    {

        public JsltSwitch()
        {
            this.Cases = new List<JsltCase>();
        }

        public JsltBase Expression { get; set; }

        public List<JsltCase> Cases { get; }

        public JsltBase Default { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitSwitch(this);
        }

        public override string ToString()
        {
            return "switch " + Expression.ToString();
        }

    }

}
