using System;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths.Expressions;

internal interface IValueExpressionParser
{
	bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out ValueExpressionNode? expression, PathParsingOptions options);
}