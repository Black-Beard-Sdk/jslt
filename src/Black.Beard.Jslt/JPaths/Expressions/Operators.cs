﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths.Expressions;

internal static class Operators
{
	public static readonly IBinaryValueOperator Add = new AddOperator();
	public static readonly IBinaryValueOperator Subtract = new SubtractOperator();
	public static readonly IBinaryValueOperator Multiply = new MultiplyOperator();
	public static readonly IBinaryValueOperator Divide = new DivideOperator();

	public static readonly IBinaryComparativeOperator EqualTo = new EqualToOperator();
	public static readonly IBinaryComparativeOperator NotEqualTo = new NotEqualToOperator();
	public static readonly IBinaryComparativeOperator LessThan = new LessThanOperator();
	public static readonly IBinaryComparativeOperator LessThanOrEqualTo = new LessThanOrEqualToOperator();
	public static readonly IBinaryComparativeOperator GreaterThan = new GreaterThanOperator();
	public static readonly IBinaryComparativeOperator GreaterThanOrEqualTo = new GreaterThanOrEqualToOperator();
	public static readonly IBinaryComparativeOperator In = new InOperator();

	public static readonly IUnaryComparativeOperator Exists = new ExistsOperator();

	public static readonly IBinaryLogicalOperator And = new AndOperator();
	public static readonly IBinaryLogicalOperator Or = new OrOperator();

	public static readonly IUnaryLogicalOperator Not = new NotOperator();
	public static readonly IUnaryLogicalOperator NoOp = new NoOpOperator();
}

internal static class ValueOperatorParser
{
	public static bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out IBinaryValueOperator? op)
	{
		if (!source.ConsumeWhitespace(ref index))
		{
			op = null;
			return false;
		}

		switch (source[index])
		{
			case '+':
				op = Operators.Add;
				index++;
				break;
			case '-':
				op = Operators.Subtract;
				index++;
				break;
			case '*':
				op = Operators.Multiply;
				index++;
				break;
			case '/':
				op = Operators.Divide;
				index++;
				break;
			default:
				op = null;
				break;
		}

		return op != null;
	}
}

internal static class ComparativeOperatorParser
{
	// .ToCharArray() used because netstandard 2.0 doesn't define implicit string -> span<char>
	private static readonly char[] _equalTo = "==".ToCharArray();
	private static readonly char[] _notEqualTo = "!=".ToCharArray();
	private static readonly char[] _lessThanOrEqualTo = "<=".ToCharArray();
	private static readonly char[] _greaterThanOrEqualTo = ">=".ToCharArray();
	private const char _lessThan = '<';
	private const char _greaterThan = '>';
	private static readonly char[] _in = "in".ToCharArray();

	public static bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out IBinaryComparativeOperator? op)
	{
		if (!source.ConsumeWhitespace(ref index))
		{
			op = null;
			return false;
		}

		if (index > source.Length - 2)
		{
			// no need to check for < or > because there would be no room for an operand
			op = null;
			return false;
		}

		var portion = source[index..(index + 2)];

		if (portion.Equals(_equalTo, StringComparison.Ordinal))
		{
			op = Operators.EqualTo;
			index += 2;
		}
		else if (portion.Equals(_notEqualTo, StringComparison.Ordinal))
		{
			op = Operators.NotEqualTo;
			index += 2;
		}
		else if (portion.Equals(_lessThanOrEqualTo, StringComparison.Ordinal))
		{
			op = Operators.LessThanOrEqualTo;
			index += 2;
		}
		else if (portion.Equals(_greaterThanOrEqualTo, StringComparison.Ordinal))
		{
			op = Operators.GreaterThanOrEqualTo;
			index += 2;
		}
		else if (source[index] == _lessThan)
		{
			op = Operators.LessThan;
			index++;
		}
		else if (source[index] == _greaterThan)
		{
			op = Operators.GreaterThan;
			index++;
		}
		else if (portion.Equals(_in, StringComparison.Ordinal))
		{
			op = Operators.In;
			index += 2;
		}
		else
		{
			op = null;
			return false;
		}

		return true;
	}
}

internal static class BinaryLogicalOperatorParser
{
	public static bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out IBinaryLogicalOperator? op)
	{
		if (!source.ConsumeWhitespace(ref index))
		{
			op = null;
			return false;
		}

		if (index > source.Length - 2)
		{
			op = null;
			return false;
		}

		var portion = source[index..(index + 2)];

		if (portion.Equals("&&".AsSpan(), StringComparison.Ordinal))
		{
			op = Operators.And;
			index += 2;
		}
		else if (portion.Equals("||".AsSpan(), StringComparison.Ordinal))
		{
			op = Operators.Or;
			index += 2;
		}
		else
		{
			op = null;
			return false;
		}

		return true;
	}
}

internal static class UnaryLogicalOperatorParser
{
	public static bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out IUnaryLogicalOperator? op)
	{
		if (!source.ConsumeWhitespace(ref index))
		{
			op = null;
			return false;
		}

		if (source[index] == '!')
		{
			op = Operators.Not;
			index++;
			return true;
		}

		op = null;
		return false;
	}
}