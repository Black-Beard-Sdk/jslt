using Bb.Asts;
using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{
    [System.Diagnostics.DebuggerDisplay("{Operator} {Operator}")]
    public class JsltOperator : JsltBase
    {


        public JsltOperator(JsltBase left, OperationEnum @operator)
        {
            this.Left = left;
            this.Kind = JsltKind.Operator;
            this.Operator = @operator;
        }

        public OperationEnum Operator { get; }

        public JsltBase Left { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitUnaryOperator(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            WriteOperator(writer);

            if (Left != null)
                Left.ToString(writer, strategy);

            return true;

        }

        protected void WriteOperator(Writer writer)
        {

            switch (Operator)
            {
                case OperationEnum.Undefined:
                    break;
                case OperationEnum.GreaterThan:
                    writer.Append(">");
                    break;
                case OperationEnum.GreaterThanOrEqual:
                    writer.Append(">=");
                    break;
                case OperationEnum.Equal:
                    writer.Append("==");
                    break;
                case OperationEnum.LessThanOrEqual:
                    writer.Append("<=");
                    break;
                case OperationEnum.LessThan:
                    writer.Append("<");
                    break;
                case OperationEnum.NotEqual:
                    writer.Append("!=");
                    break;
                case OperationEnum.Add:
                    writer.Append("+");
                    break;
                case OperationEnum.Subtract:
                    writer.Append("-");
                    break;
                case OperationEnum.Divide:
                    writer.Append("/");
                    break;
                case OperationEnum.Modulo:
                    writer.Append("%");
                    break;
                case OperationEnum.Multiply:
                    writer.Append("*");
                    break;
                case OperationEnum.Power:
                    writer.Append(" ");
                    break;
                case OperationEnum.Chain:
                    writer.Append("->");
                    break;
                case OperationEnum.And:
                    writer.Append("&");
                    break;
                case OperationEnum.AndExclusive:
                    writer.Append("&&");
                    break;
                case OperationEnum.Or:
                    writer.Append("|");
                    break;
                case OperationEnum.OrExclusive:
                    writer.Append("||");
                    break;
                case OperationEnum.Coalesce:
                    writer.Append("??");
                    break;
                case OperationEnum.Not:
                    writer.Append("!");
                    break;
                default:
                    break;
            }

            writer.Append(" ");

        }

    }


}

