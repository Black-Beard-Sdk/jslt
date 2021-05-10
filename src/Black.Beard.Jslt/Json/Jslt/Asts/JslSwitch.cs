using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{
    public class JslSwitch : JsltJson
    {

        public JslSwitch()
        {
            this.Cases = new List<JsltCase>();
        }

        public JsltJson Expression { get; set; }

        public List<JsltCase> Cases { get; }

        public JsltJson Default { get; set; }

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
