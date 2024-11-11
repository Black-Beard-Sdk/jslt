using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class DivideOperator : IBinaryValueOperator
{
	public int Precedence => 2;

	public PathValue? Evaluate(PathValue? left, PathValue? right)
	{
		if (left is null || right is null) return null;

		if (!left.TryGetJson(out var lNode) || lNode is not JValue lValue ||
		    !right.TryGetJson(out var rNode) || rNode is not JValue rValue)
			return null;

		var rNumber = rValue.GetNumber();

		return rNumber is null or 0
			? null
			: (JToken?)(lValue.GetNumber() / rNumber);
	}

	public override string ToString()
	{
		return "/";
	}
}