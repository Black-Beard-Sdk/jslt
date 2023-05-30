using Bb.Asts;
using Oldtonsoft.Json.Linq;
using System.Security.Principal;
using System.Threading;
using System.Xml;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("jpath {Value}")]
    public class JsltPath : JsltBase
    {

        public JsltPath()
        {
            Kind = JsltKind.Jpath;
        }

        public string Value { get; internal set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitJPath(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            writer.Append(Value);
            return true;
        }

    }


}
