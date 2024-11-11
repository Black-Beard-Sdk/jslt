using System.Diagnostics.CodeAnalysis;
using System;
using Oldtonsoft.Json.Linq;
using System.Text;

namespace Bb.JPaths.Expressions;

internal class LiteralValueExpressionNode : LeafValueExpressionNode
{


    private readonly JToken? _value;

    public LiteralValueExpressionNode(JToken? value)
    {
        _value = value;
    }

    public override PathValue? Evaluate(JToken? globalParameter, JToken? localParameter)
    {
        return _value;
    }

    public override void BuildString(StringBuilder builder)
    {
        builder.Append(_value.AsJsonString(Oldtonsoft.Json.Formatting.Indented));
    }

    public override string ToString()
    {
        return _value.AsJsonString(Oldtonsoft.Json.Formatting.Indented);
    }
}

internal class LiteralValueExpressionParser : IValueExpressionParser
{
    public bool TryParse(ReadOnlySpan<char> source, ref int index, int nestLevel, [NotNullWhen(true)] out ValueExpressionNode? expression, PathParsingOptions options)
    {
        if (!source.TryParseJson(ref index, out var node))
        {
            expression = null;
            return false;
        }

        if (node is not (null or JValue) && !options.AllowJsonConstructs)
        {
            expression = null;
            return false;
        }

        expression = new LiteralValueExpressionNode(node);
        return true;
    }
}