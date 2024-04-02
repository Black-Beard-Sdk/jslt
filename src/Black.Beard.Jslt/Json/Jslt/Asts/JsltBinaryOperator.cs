using Bb.Asts;
using Bb.Contracts;
using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{

    /// <summary>
    /// Represents a binary operator in a Jslt.
    ///     GreaterThan         >
    ///     GreaterThanOrEqual  >=
    ///     Equal               ==
    ///     LessThanOrEqual     <=
    ///     LessThan            <
    ///     NotEqual            !=
    ///     Add                 +
    ///     Subtract            -
    ///     Divide              /
    ///     Modulo              %
    ///     Multiply            *
    ///     Power               ^ 
    ///     Chain               ->
    ///     And                 &
    ///     AndExclusive        &&
    ///     Or                  |
    ///     OrExclusive         ||
    ///     Coalesce            ??
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Left} {Operator} {Right}")]
    public class JsltBinaryOperator : JsltOperator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltBinaryOperator"/> class.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="operator"></param>
        /// <param name="right"></param>
        public JsltBinaryOperator(JsltBase left, OperationEnum @operator, JsltBase right)
            : base (left, @operator)
        {
            this.Right = right;
        }


        /// <summary>
        /// Gets the right operand.
        /// </summary>
        public JsltBase Right { get; }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitBinaryOperator(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {

            if (Left != null)
                Left.ToString(writer, strategy);

            writer.Append(" ");
            WriteOperator(writer);

            if (Right != null)
                Right.ToString(writer, strategy);

            return true;

        }

    }

}




