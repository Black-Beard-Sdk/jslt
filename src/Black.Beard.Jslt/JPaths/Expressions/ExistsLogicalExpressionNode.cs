using System.Text;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class ExistsLogicalExpressionNode : LeafLogicalExpressionNode
{
	public JsonPath Path { get; }

	public ExistsLogicalExpressionNode(JsonPath path)
	{
		Path = path;
	}

	public override void BuildString(StringBuilder builder)
	{
		Path.BuildString(builder);
	}

	public override bool Evaluate(JToken? globalParameter, JToken? localParameter)
	{
		var parameter = Path.Scope == PathScope.Global
			? globalParameter
			: localParameter;

		var result = Path.Evaluate(parameter);

		return result.Matches.Count != 0;
	}
}
