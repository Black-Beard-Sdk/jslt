using System.Diagnostics.CodeAnalysis;
using System;
using System.Text;
using Bb.Json.Linq;

namespace Bb.JPaths.Expressions;

internal class PathValueExpressionNode : LeafValueExpressionNode
{
	public JsonPath Path { get; }

	public PathValueExpressionNode(JsonPath path)
	{
		Path = path;
	}

	public override PathValue? Evaluate(JToken? globalParameter, JToken? localParameter)
	{
		var parameter = Path.Scope == PathScope.Global
			? globalParameter
			: localParameter;

		var result = Path.Evaluate(parameter);

		return result.Matches;
	}

	public override void BuildString(StringBuilder builder)
	{
		Path.BuildString(builder);
	}

	public static implicit operator PathValueExpressionNode(JsonPath value)
	{
		return new PathValueExpressionNode(value);
	}

	public override string ToString()
	{
		return Path.ToString();
	}
}

internal class PathValueExpressionParser : IValueExpressionParser
{
	public bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out ValueExpressionNode? expression, PathParsingOptions options)
	{
		if (!PathParser.TryParse(source, ref index, out var path, options))
		{
			expression = null;
			return false;
		}

		expression = new PathValueExpressionNode(path);
		return true;
	}
}
