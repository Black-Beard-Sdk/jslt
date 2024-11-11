using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class AddOperator : IBinaryValueOperator
{
	public int Precedence => 1;

	public PathValue? Evaluate(PathValue? left, PathValue? right)
	{
		if (left is null || right is null) return null;

		if (!left.TryGetJson(out var lNode) || lNode is not JValue lValue ||
		    !right.TryGetJson(out var rNode) || rNode is not JValue rValue)
			return null;

		if (lValue.TryGetValue(out string? leftString) &&
		    rValue.TryGetValue(out string? rightString))
			return (JToken?)(leftString + rightString);

		return (JToken?)(lValue.GetNumber() + rValue.GetNumber());
	}

	public override string ToString()
	{
		return "+";
	}
}