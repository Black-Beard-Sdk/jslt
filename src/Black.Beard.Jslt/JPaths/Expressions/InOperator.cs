using System.Linq;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class InOperator : IBinaryComparativeOperator
{
	public int Precedence => 10;

	public bool Evaluate(PathValue? left, PathValue? right)
	{
		if (left is null) return right is null;
		if (right is null) return false;

		if (!left.TryGetJson(out var lNode) ||
		    !right.TryGetJson(out var rNode))
			return false;

		var values = rNode switch
		{
			JArray arr => arr,
			JObject obj => obj.Properties().Select(x => x.Value),
			_ => null
		};

		if (values == null) return false;

		return values.Contains(lNode);

	}

	public override string ToString()
	{
		return " in ";
	}
}
