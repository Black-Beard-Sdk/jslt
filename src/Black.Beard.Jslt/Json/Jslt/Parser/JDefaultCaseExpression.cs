using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    /// <summary>
    /// Represents a expression extended JSON
    /// </summary>
    public class JDefaultCaseExpression : JExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JExpression" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JDefaultCaseExpression( JToken content)
            : base()
        {

            this.Content = content;

        }

        public JToken Content { get; }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            base.WriteTo(writer, converters);
        }

    }

}
