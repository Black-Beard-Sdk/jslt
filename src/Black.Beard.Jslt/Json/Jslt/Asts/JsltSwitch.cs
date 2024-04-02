using Antlr4.Runtime.Misc;
using Bb.Asts;
using Bb.Contracts;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    [System.Diagnostics.DebuggerDisplay("switch {Expression}")]
    public class JsltSwitch : JsltBase
    {

        public JsltSwitch()
        {
            this.Cases = new List<JsltSwitchCase>();
        }

        public JsltBase Expression { get; set; }

        public List<JsltSwitchCase> Cases { get; }

        public JsltBase Default { get; set; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitSwitch(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            Expression.ToString(writer, strategy);

            if (Cases.Count > 0)
            {
                Cases[0].ToString(writer, strategy);
                for (int i = 1; i < Cases.Count; i++)
                {
                    writer.AppendEndLine(",");
                    Cases[i].ToString(writer, strategy);
                }
            }

            if (Default != null)
            {
                if (Cases.Count > 0)
                    writer.AppendEndLine(",");
                writer.Append("default");
                Default.ToString(writer, strategy);
            }
            return true;


        }

    }

}
