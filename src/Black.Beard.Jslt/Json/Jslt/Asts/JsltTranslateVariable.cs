using Bb.Json.Jslt.Services;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public class JsltTranslateVariable : JsltBase
    {

        public JsltTranslateVariable(JsltConstant value)
        {
            Kind = JsltKind.JTranslateVariable;
            this.Value = value;
            this.Start = value.Start;
            this.Stop = value.Stop;
            this.VariableNames = new List<string>();

            var matchs = VariableManagerExtension.Match(value.Value.ToString());
            while (matchs.Success)
            {
                this.VariableNames.Add(matchs.Value);
                matchs = matchs.NextMatch();
            }

        }

        public JsltConstant Value { get; }

        public List<string> VariableNames { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitTranslateVariable(this);
        }

    }


}
