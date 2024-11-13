using System;
using System.Collections.Generic;
using System.Text;
using Bb.Json.Linq;

namespace Bb.JPaths;

/// <summary>
/// Represents a name selector.
/// </summary>
public class NameSelector : ISelector, IHaveShorthand
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    internal NameSelector(string name)
    {
        Name = name;
    }

    string IHaveShorthand.ToShorthandString()
    {
        return $".{Name}";
    }

    void IHaveShorthand.AppendShorthandString(StringBuilder builder)
    {
        builder.Append('.');
        builder.Append(Name);
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"'{Name}'"; // TODO escape this
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
        if (node is not JObject obj) yield break;

        if (obj.TryGetValue(Name, out var value))
            yield return new Node(value, match.Location!.Append(Name));

    }

    /// <summary>
    /// Builds a string using a string builder.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    public void BuildString(StringBuilder builder)
    {
        builder.Append('\'');
        builder.Append(Name); // TODO escape this
        builder.Append('\'');
    }

    public bool TryToMatch(ISelector selector)
    {

        if (selector is NameSelector n)
           return n.Name.Equals(Name);

        throw new NotImplementedException();
    }

}
