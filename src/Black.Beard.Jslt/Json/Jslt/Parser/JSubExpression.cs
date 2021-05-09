using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{

    public class JSubExpression : JExpression
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JExpression" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JSubExpression(JToken token)
            : base()
        {

            this.Sub = token;

        }

        public JToken Sub { get; }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            writer.WriteRaw("(");
            this.Sub.WriteTo(writer, converters);
            writer.WriteRaw(")");

        }

    }

}
