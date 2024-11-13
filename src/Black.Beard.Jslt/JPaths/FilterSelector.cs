using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Bb.Json.Linq;
using Bb.JPaths.Expressions;
using Bb.Json;

namespace Bb.JPaths;

/// <summary>
/// Represents a filter expression selector.
/// </summary>
public class FilterSelector : ISelector
{
    /// <summary>
    /// Gets the expression.
    /// </summary>
    public IFilterExpression Expression { get; }

    internal FilterSelector(LogicalExpressionNode expression)
    {
        Expression = expression;
    }

    /// <summary>
    /// Evaluates the selector.
    /// </summary>
    /// <param name="match">The node to evaluate.</param>
    /// <param name="rootNode">The root node (typically used by filter selectors, e.g. `$[?@foo &lt; $.bar]`)</param>
    /// <returns>
    /// A collection of nodes.
    ///
    /// Semantically, this is a nodelist, but leaving as IEnumerable&lt;Node&gt; allows for deferred execution.
    /// </returns>
    public IEnumerable<Node> Evaluate(Node match, JToken? rootNode)
    {
        var node = match.Value;
        if (node is JObject obj)
        {
            foreach (var member in obj)
            {
                if (Expression.Evaluate(rootNode, member.Value))
                    yield return new Node(member.Value, match.Location!.Append(member.Key));
            }
        }
        else if (node is JArray arr)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                var member = arr[i];
                if (Expression.Evaluate(rootNode, member))
                    yield return new Node(member, match.Location!.Append(i));
            }
        }
    }

    /// <summary>
    /// Builds a string using a string builder.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    public void BuildString(StringBuilder builder)
    {
        builder.Append('?');
        Expression.BuildString(builder);
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"?{Expression}";
    }

    public IEnumerable<Node> Evaluate(Node match, JsonTextReader? rootNode)
    {
        throw new NotImplementedException();
    }

    public bool TryToMatch(ISelector selector)
    {
        throw new NotImplementedException();
    }

}

internal class FilterSelectorParser : ISelectorParser
{
    public bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out ISelector? selector, PathParsingOptions options)
    {
        if (source[index] != '?')
        {
            selector = null;
            return false;
        }

        int i = index;
        i++; // consume ?
        if (!ExpressionParser.TryParse(source, ref i, out var expression, options))
        {
            selector = null;
            return false;
        }

        index = i;
        selector = new FilterSelector(expression);
        return true;
    }
}