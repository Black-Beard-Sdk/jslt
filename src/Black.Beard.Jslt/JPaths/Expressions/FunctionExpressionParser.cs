﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths.Expressions;

internal static class FunctionExpressionParser
{
	public static bool TryParseFunction(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out List<ExpressionNode>? arguments, [NotNullWhen(true)] out IPathFunctionDefinition? function, PathParsingOptions options)
	{
		int i = index;

		if (!source.ConsumeWhitespace(ref i))
		{
			arguments = null;
			function = null;
			return false;
		}

		// parse function name
		if (!source.TryParseName(ref i, out var name, options))
		{
			arguments = null;
			function = null;
			return false;
		}

		if (!FunctionRepository.TryGet(name, out function))
		{
			arguments = null;
			function = null;
			return false;
		}

		if (options.TolerateExtraWhitespace && !source.ConsumeWhitespace(ref i) || i == source.Length)
		{
			arguments = null;
			function = null;
			return false;
		}

		// consume (
		if (source[i] != '(')
		{
			arguments = null;
			function = null;
			return false;
		}

		i++;

		// parse list of arguments - all expressions
		arguments = new List<ExpressionNode>();
		var done = false;

		var parameterTypeList = ((IReflectiveFunctionDefinition)function).Evaluator.ArgTypes;
		var parameterIndex = 0;

		while (i < source.Length && !done)
		{
			if (!source.ConsumeWhitespace(ref i))
			{
				arguments = null;
				function = null;
				return false;
			}

			if (parameterIndex >= parameterTypeList.Length)
			{
				arguments = null;
				function = null;
				return false;
			}

			if (parameterTypeList[parameterIndex] == FunctionType.Value)
			{
				if (!ValueExpressionParser.TryParse(source, ref i, 0, out var expr, options) ||
				    expr is PathValueExpressionNode { Path.IsSingular: false })
				{
					arguments = null;
					function = null;
					return false;
				}

				arguments.Add(expr);
			}
			else if (parameterTypeList[parameterIndex] == FunctionType.Logical)
			{

				if (!LogicalExpressionParser.TryParse(source, ref i, 0, out var expr, options))
				{
					arguments = null;
					function = null;
					return false;
				}
				arguments.Add(expr);
			}
			else
			{
				// this must return a path or function that returns nodelist
				if (!ValueExpressionParser.TryParse(source, ref i, 0, out var expr, options))
				{
					arguments = null;
					function = null;
					return false;
				}

				switch (expr)
				{
					case PathValueExpressionNode:
						arguments.Add(expr);
						break;
					case FunctionValueExpressionNode { Function: not NodelistFunctionDefinition }:
						arguments = null;
						function = null;
						return false;
					case FunctionValueExpressionNode:
						arguments.Add(expr);
						break;
					default:
						arguments = null;
						function = null;
						return false;
				}
			}

			if (!source.ConsumeWhitespace(ref i))
			{
				arguments = null;
				function = null;
				return false;
			}

			switch (source[i])
			{
				case ')':
					done = true;
					break;
				case ',':
					break;
				default:
					arguments = null;
					function = null;
					return false;
			}

			i++;
			parameterIndex++;
		}

		if (parameterIndex != parameterTypeList.Length)
		{
			arguments = null;
			function = null;
			return false;
		}

		index = i;
		return true;
	}
}