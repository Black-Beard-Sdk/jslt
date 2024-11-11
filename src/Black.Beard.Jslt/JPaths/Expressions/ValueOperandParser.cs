using System.Diagnostics.CodeAnalysis;
using System;


namespace Bb.JPaths.Expressions;

internal class ValueOperandParser
{
	private static readonly IValueExpressionParser[] _parsers =
	{
		new FunctionValueExpressionParser(),
		new LiteralValueExpressionParser(),
		new PathValueExpressionParser()
	};

	public static bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out ValueExpressionNode? expression, PathParsingOptions options)
	{
		if (source[index] == '(')
		{
			int i = index + 1;
			if (ValueExpressionParser.TryParse(source, ref i, nestLevel + 1, out var local, options))
			{
				if (!source.ConsumeWhitespace(ref i))
				{
					expression = null;
					return false;
				}

				if (source[i] == ')')
				{
					index = i + 1;
					expression = local;
					return true;
				}
			}
		}

		foreach (var parser in _parsers)
		{
			if (parser.TryParse(source, ref index, nestLevel, out expression, options)) return true;
		}

		expression = null;
		return false;
	}
}