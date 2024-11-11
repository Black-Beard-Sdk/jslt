using System;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class GreaterThanOperator : IBinaryComparativeOperator
{
	public int Precedence => 10;

	public bool Evaluate(PathValue? left, PathValue? right)
	{
		if (left is null) return right is null;
		if (right is null) return false;

		if (!left.TryGetJson(out var lNode) ||
		    !right.TryGetJson(out var rNode))
			return false;

		if (lNode is not JValue lValue ||
		    rNode is not JValue rValue)
			return false;

		if (lValue.TryGetValue(out string? leftString) &&
		    rValue.TryGetValue(out string? rightString))
			return string.Compare(leftString, rightString, StringComparison.Ordinal) > 0;

		return lValue.GetNumber() > rValue.GetNumber();
	}

	public override string ToString()
	{
		return ">";
	}
}