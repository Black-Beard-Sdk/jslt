using Oldtonsoft.Json.Linq;


namespace Bb.JPaths.Expressions;

internal abstract class ValueExpressionNode : ExpressionNode
{
	public abstract PathValue? Evaluate(JToken? globalParameter, JToken? localParameter);
}
