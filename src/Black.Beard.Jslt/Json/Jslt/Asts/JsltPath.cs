using Bb.Asts;
using Bb.Contracts;
using Oldtonsoft.Json.Linq;
using System;
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

        public string Value { get; set; }

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
