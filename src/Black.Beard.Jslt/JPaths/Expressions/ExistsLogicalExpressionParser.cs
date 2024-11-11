using System;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths.Expressions;

internal class ExistsLogicalExpressionParser : ILogicalExpressionParser
{
	public bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out LogicalExpressionNode? expression, PathParsingOptions options)
	{
		if (!PathParser.TryParse(source, ref index, out var path, options))
		{
			expression = null;
			return false;
		}

		expression = new ExistsLogicalExpressionNode(path);
		return true;
	}
}