using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{

    /// <summary>
    /// Represents a raw JSON string.
    /// </summary>
    public class JBinaryOperation : JUnaryOperation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Newtonsoft.Json.Linq.JRaw" /> class.
        /// </summary>
        /// <param name="rawJson">The raw json.</param>
        public JBinaryOperation(JToken leftToken, OperationEnum operation, JToken rightToken)
            : base(leftToken, operation)
        {
            this.Right = rightToken;
        }

        public JToken Right { get; }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            this.Left.WriteTo(writer, converters);
            WriteOperator(writer);
            this.Right.WriteTo(writer, converters);
        }

    }

}
