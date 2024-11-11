using System.Diagnostics.CodeAnalysis;
using System;

namespace Bb.JPaths.Expressions;

internal static class LogicalExpressionParser
{
	public static bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out LogicalExpressionNode? expression, PathParsingOptions options)
	{
		int i = index;

		int Precedence(IBinaryLogicalOperator op) => nestLevel * 10 + op.Precedence;

		if (!source.ConsumeWhitespace(ref i))
		{
			expression = null;
			return false;
		}

		// first get an operand
		if (!LogicalOperandParser.TryParse(source, ref i, nestLevel, out var left, options))
		{
			expression = null;
			return false;
		}

		while (i < source.Length)
		{
			if (!source.ConsumeWhitespace(ref i))
			{
				expression = null;
				return false;
			}

			// parse operator
			if (!BinaryLogicalOperatorParser.TryParse(source, ref i, out var op))
				break; // if we don't get an op, then we're done

			if (!source.ConsumeWhitespace(ref i))
			{
				expression = null;
				return false;
			}

			// parse right
			if (!LogicalOperandParser.TryParse(source, ref i, nestLevel, out var right, options))
			{
				// if we don't get a comparison, then the syntax is wrong
				expression = null;
				return false;
			}

			// assemble
			if (left is BinaryLogicalExpressionNode lBin && lBin.Precedence < Precedence(op))
				lBin.Right = new BinaryLogicalExpressionNode(lBin.Right, op, right, nestLevel);
			else
				left = new BinaryLogicalExpressionNode(left, op, right, nestLevel);
		}

		index = i;
		expression = left;
		return true;
	}
}
