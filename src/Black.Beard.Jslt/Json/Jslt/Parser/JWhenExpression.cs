using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Parser
{
    /// <summary>
    /// Represents a expression extended JSON
    /// </summary>
    public class JWhenExpression : JExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JExpression" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JWhenExpression(JToken expression, IEnumerable<JCaseExpression> cases, JDefaultCaseExpression defaultCase)
            : base()
        {

            this.Expression = expression;
            this.Cases = new List<JCaseExpression>(cases);
        }

        public JToken Expression { get; }
        
        public List<JCaseExpression> Cases { get; }

        public List<JDefaultCaseExpression> DefaultCase { get; }

    }

}
