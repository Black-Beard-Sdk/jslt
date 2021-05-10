using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    /// <summary>
    /// Represents a expression extended JSON
    /// </summary>
    public class JCaseExpression : JExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JExpression" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JCaseExpression(string text, JToken expression, JToken content)
            : base(text)
        {
            this.Expression = expression;
            this.Content = content;
        }

        public JToken Expression { get; }

        public JToken Content { get; }

    }

}
