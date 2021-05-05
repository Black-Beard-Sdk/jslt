using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Threading;
using System.Xml;

namespace Bb.Json.Jslt.Asts
{

    public class JsltPath : JsltJson
    {

        public JsltPath()
        {
            Kind = JsltKind.Jpath;
        }

        //public XsltJson Child { get; internal set; }

        public string Value { get; internal set; }

        public JsltJson Child { get; internal set; }

        public string Type { get; internal set; }

        public JsltObject TypeObject { get; internal set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitJPath(this);
        }

    }

}
