using System;

namespace Bb.JPaths;

/// <summary>
/// Allows collection expression initialization.
/// </summary>
public static class NodeListBuilder
{
    /// <summary>
    /// Allows collection expression initialization.
    /// </summary>
    public static NodeList Create(ReadOnlySpan<Node> values) => new(values);
}