using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Threading;
using System.Xml;

namespace Bb.Json.Jslt.Asts
{

    public class JsltPath : JsltConstant
    {

        public JsltPath()
        {
            Kind = JsltKind.Jpath;
        }

        public new string Value { get; internal set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitJPath(this);
        }

    }


}
