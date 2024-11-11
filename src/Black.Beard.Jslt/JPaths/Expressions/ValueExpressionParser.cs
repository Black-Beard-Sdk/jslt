﻿using System.Diagnostics.CodeAnalysis;
using System;


namespace Bb.JPaths.Expressions;

internal static class ValueExpressionParser
{
	public static bool TryParse(ReadOnlySpan<char> source
		, ref int index
		, int nestLevel
		, [NotNullWhen(true)] out ValueExpressionNode? expression
		, PathParsingOptions options)
	{
		int i = index;

		int Precedence(IBinaryValueOperator op) => nestLevel * 10 + op.Precedence;

		if (!source.ConsumeWhitespace(ref index))
		{
			expression = null;
			return false;
		}

		// first get an operand
		if (!ValueOperandParser.TryParse(source, ref i, nestLevel, out var left, options))
		{
			expression = null;
			return false;
		}

		if (!options.AllowMathOperations)
		{
			index = i;
			expression = left;
			return true;
		}

		while (i < source.Length)
		{
			if (!source.ConsumeWhitespace(ref index))
			{
				expression = null;
				return false;
			}

			// parse operator
			if (!ValueOperatorParser.TryParse(source, ref i, out var op))
				break; // if we don't get an op, then we're done

			if (!source.ConsumeWhitespace(ref index))
			{
				expression = null;
				return false;
			}

			// parse right
			if (!ValueOperandParser.TryParse(source, ref i, nestLevel, out var right, options))
			{
				expression = null;
				return false;
			}

			// assemble
			if (left is CompositeValueExpressionNode bin && bin.Precedence < Precedence(op))
				bin.Right = new CompositeValueExpressionNode(bin.Right, op, right, nestLevel);
			else
				left = new CompositeValueExpressionNode(left, op, right, nestLevel);
		}

		index = i;
		expression = left;
		return true;
	}
}
