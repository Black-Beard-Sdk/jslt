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

            if (Left != null)
                Left.ToString(writer, strategy);

            switch (Kind)
            {
                case JsltKind.Object:
                    break;
                case JsltKind.Property:
                    break;
                case JsltKind.Array:
                    break;
                case JsltKind.TimeSpan:
                    break;
                case JsltKind.Uri:
                    break;
                case JsltKind.Guid:
                    break;
                case JsltKind.Bytes:
                    break;
                case JsltKind.Date:
                    break;
                case JsltKind.Null:
                    break;
                case JsltKind.Boolean:
                    break;
                case JsltKind.String:
                    break;
                case JsltKind.Float:
                    break;
                case JsltKind.Integer:
                    break;
                case JsltKind.Path:
                    break;
                case JsltKind.Function:
                    break;
                case JsltKind.PathParent:
                    break;
                case JsltKind.PathKey:
                    break;
                case JsltKind.PathCoalesce:
                    break;
                case JsltKind.Jpath:
                    break;
                case JsltKind.PathIndice:
                    break;
                case JsltKind.Type:
                    break;
                case JsltKind.Operator:
                    break;
                case JsltKind.JVariable:
                    break;
                case JsltKind.JTranslateVariable:
                    break;
                default:
                    break;
            }
            writer.Append("");

            //if (Right != null)
            //    Right.ToString(writer, strategy);

            return true;

        }

    }


}

