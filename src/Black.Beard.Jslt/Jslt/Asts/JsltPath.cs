using Bb.Asts;
using Bb.Contracts;
using System;

namespace Bb.Jslt.Asts
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
