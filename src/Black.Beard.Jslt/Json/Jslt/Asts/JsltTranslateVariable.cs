using Bb.Analysis.DiagTraces;
using Bb.Asts;
using Bb.Contracts;
using Bb.Json.Jslt.Services;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    /// <summary>
    /// Represents a variable to translate.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("variables : {VariableNames}")]
    public class JsltTranslateVariable : JsltBase
    {

        public JsltTranslateVariable(JsltBase token)
        {
            Kind = JsltKind.JTranslateVariable;
            this.Value = token;
            this.Location = token.Location.Copy();
            this.VariableNames = new List<string>();

            string _value = null;

            if (token is JsltConstant c)
                _value = c.Value?.ToString();

            else if (token is JsltPath p)
                _value = p.Value?.ToString();

            var matchs = VariableManagerExtension.Match(_value);
            while (matchs.Success)
            {
                this.VariableNames.Add(matchs.Value);
                matchs = matchs.NextMatch();
            }

        }

        public JsltBase Value { get; }

        public List<string> VariableNames { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitTranslateVariable(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            throw new System.NotImplementedException();
        }

    }


}
