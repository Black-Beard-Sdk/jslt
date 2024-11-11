using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;


internal abstract class LogicalExpressionNode : ExpressionNode, IFilterExpression
{
	public abstract bool Evaluate(JToken? globalParameter, JToken? localParameter);
}

internal abstract class CompositeLogicalExpressionNode : LogicalExpressionNode
{


}

internal abstract class LeafLogicalExpressionNode : LogicalExpressionNode
{


}
