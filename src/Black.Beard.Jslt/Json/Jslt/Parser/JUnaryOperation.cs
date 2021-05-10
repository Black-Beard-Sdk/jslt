using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    public class JUnaryOperation : JExpression
    {


        public JUnaryOperation(string text, JToken leftToken, OperationEnum operation)
            : base(text)
        {
            this.Left = leftToken;
            this.Operator = operation;
        }

        public JToken Left { get; }

        public OperationEnum Operator { get; }

        public override void WriteTo(JsonWriter writer, params JsonConverter[] converters)
        {
            WriteOperator(writer);
            this.Left.WriteTo(writer, converters);
        }

        protected void WriteOperator(JsonWriter writer)
        {
            switch (Operator)
            {
                case OperationEnum.Equal:
                    writer.WriteRaw("==");
                    break;
                case OperationEnum.GreaterThanOrEqual:
                    writer.WriteRaw(" >= ");
                    break;
                case OperationEnum.GreaterThan:
                    writer.WriteRaw(" > ");
                    break;
                case OperationEnum.LessThanOrEqual:
                    writer.WriteRaw(" <= ");
                    break;
                case OperationEnum.LessThan:
                    writer.WriteRaw(" < ");
                    break;
                case OperationEnum.NotEqual:
                    writer.WriteRaw(" != ");
                    break;
                case OperationEnum.Add:
                    writer.WriteRaw(" + ");
                    break;
                case OperationEnum.Subtract:
                    writer.WriteRaw(" - ");
                    break;
                case OperationEnum.Divide:
                    writer.WriteRaw(" / ");
                    break;
                case OperationEnum.Modulo:
                    writer.WriteRaw(" % ");
                    break;
                case OperationEnum.Multiply:
                    writer.WriteRaw(" * ");
                    break;
                case OperationEnum.Power:
                    writer.WriteRaw(" ^ ");
                    break;
                case OperationEnum.Chain:
                    writer.WriteRaw(" => ");
                    break;

                case OperationEnum.And:
                    writer.WriteRaw(" & ");
                    break;
                case OperationEnum.Or:
                    writer.WriteRaw(" | ");
                    break;
                case OperationEnum.AndExclusive:
                    writer.WriteRaw(" && ");
                    break;
                case OperationEnum.OrExclusive:
                    writer.WriteRaw(" || ");
                    break;
                case OperationEnum.Not:
                    writer.WriteRaw("!");
                    break;
            }
        }
    }


}
