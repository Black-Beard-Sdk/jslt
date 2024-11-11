using System.Diagnostics;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths;

/// <summary>
/// Represents a single match.
/// </summary>
[DebuggerDisplay("{Value} - {Location}")]
public class Node
{
    /// <summary>
    /// The value at the matching location.
    /// </summary>
    public JToken? Value { get; internal set; }

    /// <summary>
    /// The location where the value was found.
    /// </summary>
    public JsonPath? Location { get; }

    internal Node(in JToken? value, in JsonPath? location)
    {
        Value = value;
        Location = location;
    }

}