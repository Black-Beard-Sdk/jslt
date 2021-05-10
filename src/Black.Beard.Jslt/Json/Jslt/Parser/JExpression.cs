using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    /// <summary>
    /// Represents a expression extended JSON
    /// </summary>
    public class JExpression : JRaw
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JExpression" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JExpression(string text)
            : base(text)
        {

        }

    }

}
