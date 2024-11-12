using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

using System.Linq;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths;

/// <summary>
/// Useful extensions for <see cref="JToken"/>.
/// </summary>
public static class JTokenExtensions
{

    /// <summary>
    /// Extends <see cref="JValue.TryGetValue{T}(out T)"/> to the <see cref="JToken"/> base class.
    /// </summary>
    /// <typeparam name="T">The type of value desired.</typeparam>
    /// <param name="node">The node that may contain the value.</param>
    /// <param name="value">The value if successful; null otherwise.</param>
    /// <returns>True if successful; false otherwise.</returns>
    public static bool TryGetValue<T>(this JToken? node, [NotNullWhen(true)] out T? value)
    {

        if (node is JValue val)
            if (TryGetValue(val, out T val2))
            {
                value = val2;
                return true;
            }

        value = default;
        return false;

    }

    /// <summary>
    /// Extends <see cref="JValue.TryGetValue{T}(out T)"/> to the <see cref="JToken"/> base class.
    /// </summary>
    /// <typeparam name="T">The type of value desired.</typeparam>
    /// <param name="node">The node that may contain the value.</param>
    /// <param name="value">The value if successful; null otherwise.</param>
    /// <returns>True if successful; false otherwise.</returns>
    public static bool TryGetValue<T>(this JValue? node, [NotNullWhen(true)] out T? value)
    {

        if (node.Value is T val2)
        {
            value = val2;
            return true;
        }

        value = default;
        return false;

    }

    /// <summary>
    /// Ensures a <see cref="JToken"/> only represents a single value.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value"></param>
    /// <returns>
    /// Within the context of this library, a <see cref="NodeList"/>
    /// may be stored inside a <see cref="JToken"/>.  Some operations, such as
    /// expression addition, require that a single value is provided.
    /// 
    /// This method checks to see if the underlying value of a `JToken`
    /// is a `NodeList`.  If not, it simply sets <paramref name="value"/> to the JToken
    /// and returns true.  If the underlying value is a `NodeList` _and_ it only
    /// contains a single value, it sets <paramref name="value"/> to that JToken and
    /// return true.  Otherwise, it returns false.
    /// </returns>
    /// <remarks>
    /// Though a bit complex, this method can be very important for functions
    /// that require single values as inputs rather than nodelists since function
    /// composition is possible (e.g. `min(max(@,0),10)`) and functions return nodelists.
    /// </remarks>
    public static bool TryGetSingleValue(this JToken node, out JToken? value)
    {
        if (!node.TryGetValue<NodeList>(out var nodeList))
        {
            value = node;
            return true;
        }

        if (nodeList.Count == 1)
        {
            value = nodeList[0].Value;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Ensures a <see cref="NodeList"/> only represents a single value.
    /// </summary>
    /// <param name="nodeList"></param>
    /// <param name="value"></param>
    /// <returns>
    /// Within the context of this library, a <see cref="NodeList"/>
    /// may be stored inside a <see cref="JToken"/>.  Some operations, such as
    /// expression addition, require that a single value is provided.
    /// 
    /// This method checks to see if the underlying value of a `JToken`
    /// is a `NodeList`.  If not, it simply sets <paramref name="value"/> to the JToken
    /// and returns true.  If the underlying value is a `NodeList` _and_ it only
    /// contains a single value, it sets <paramref name="value"/> to that JToken and
    /// return true.  Otherwise, it returns false.
    /// </returns>
    /// <remarks>
    /// Though a bit complex, this method can be very important for functions
    /// that require single values as inputs rather than nodelists since function
    /// composition is possible (e.g. `min(max(@,0),10)`) and functions return nodelists.
    /// </remarks>
    public static bool TryGetSingleValue(this NodeList nodeList, out JToken? value)
    {

        if (nodeList.Count == 1)
        {
            value = nodeList[0].Value;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Determines JSON-compatible equivalence.
    /// </summary>
    /// <param name="a">The first element.</param>
    /// <param name="b">The second element.</param>
    /// <returns>`true` if the element are equivalent; `false` otherwise.</returns>
    /// <remarks>
    /// <see cref="JToken.DeepEquals(JToken,JToken)"/> has trouble testing numeric
    /// equality when `decimal` is involved.  As such, it is still advised to use this
    /// method instead.  See https://github.com/dotnet/runtime/issues/97490.
    /// </remarks>
    public static bool IsEquivalentTo(this JToken? a, JToken? b)
    {
        switch (a, b)
        {
            case (null, null):
                return true;

            case (JObject objA, JObject objB):
                if (objA.Count != objB.Count) return false;
                var grouped = objA.Properties().Concat(objB.Properties())
                    .GroupBy(p => p.Name)
                    .Select(g => g.ToList())
                    .ToList();
                return grouped.All(g => g.Count == 2 && g[0].Value.IsEquivalentTo(g[1].Value));

            case (JArray arrayA, JArray arrayB):
                if (arrayA.Count != arrayB.Count) return false;
                var zipped = arrayA.Zip(arrayB, (ae, be) => (ae, be));
                return zipped.All(p => p.ae.IsEquivalentTo(p.be));

            case (JValue aValue, JValue bValue):
                var aNumber = aValue.GetNumber();
                var bNumber = bValue.GetNumber();
                if (aNumber != null) return aNumber == bNumber;

                var aString = aValue.GetString();
                var bString = bValue.GetString();
                if (aString != null) return aString == bString;

                var aBool = aValue.GetBool();
                var bBool = bValue.GetBool();
                if (aBool.HasValue) return aBool == bBool;

                var aObj = aValue.Value;
                var bObj = bValue.Value;

                if (aObj == null && bObj == null) return true;
                if (aObj == null | bObj == null) return false;

                return aObj.Equals(bObj);

            default:
                return false;
        }
    }

    // source: https://stackoverflow.com/a/60592310/878701, modified for netstandard2.0
    // license: https://creativecommons.org/licenses/by-sa/4.0/
    /// <summary>
    /// Generate a consistent JSON-value-based hash code for the element.
    /// </summary>
    /// <param name="node">The element.</param>
    /// <param name="maxHashDepth">Maximum depth to calculate.  Default is -1 which utilizes the entire structure without limitation.</param>
    /// <returns>The hash code.</returns>
    /// <remarks>
    /// See the following for discussion on why the default implementation is insufficient:
    ///
    /// - https://github.com/json-everything/json-everything/issues/76
    /// - https://github.com/dotnet/runtime/issues/33388
    /// </remarks>
    public static int GetEquivalenceHashCode(this JToken node, int maxHashDepth = -1)
    {
        static void Add(ref int current, object? newValue)
        {
            unchecked
            {
                current = current * 397 ^ (newValue?.GetHashCode() ?? 0);
            }
        }

        void ComputeHashCode(JToken? target, ref int current, int depth)
        {
            if (target == null) return;

            Add(ref current, target.GetType());

            switch (target)
            {
                case JArray array:
                    if (depth != maxHashDepth)
                        foreach (var item in array)
                            ComputeHashCode(item, ref current, depth + 1);
                    else
                        Add(ref current, array.Count);
                    break;

                case JObject obj:
                    foreach (var property in obj.Properties().OrderBy(p => p.Name, StringComparer.Ordinal))
                    {
                        Add(ref current, property.Name);
                        if (depth != maxHashDepth)
                            ComputeHashCode(property.Value, ref current, depth + 1);
                    }
                    break;
                default:
                    var value = target as JValue;
                    if (value != null && value.TryGetValue<bool>(out var boolA))
                        Add(ref current, boolA);
                    else
                    {
                        var number = value.GetNumber();
                        if (number != null)
                            Add(ref current, number);
                        else if (value.TryGetValue<string>(out var stringA))
                            Add(ref current, stringA);
                    }

                    break;
            }
        }

        var hash = 0;
        ComputeHashCode(node, ref hash, 0);
        return hash;
    }

    /// <summary>
    /// Gets JSON string representation for <see cref="JToken"/>, including null support.
    /// </summary>
    /// <param name="node">A node.</param>
    /// <param name="options">Serializer options</param>
    /// <returns>JSON string representation.</returns>
    public static string AsJsonString(this JToken? node, Oldtonsoft.Json.Formatting? format)
    {
        return node?.ToString(format ?? Oldtonsoft.Json.Formatting.None) ?? "null";
    }

    /// <summary>
    /// Gets a node's underlying numeric value.
    /// </summary>
    /// <param name="value">A JSON value.</param>
    /// <returns>Gets the underlying numeric value, or null if the node represented a non-numeric value.</returns>
    public static decimal? GetNumber(this JValue value)
    {

        if (value.TryGetValue(out decimal e))
            return e;

        if (value.TryGetValue(out int i))
            return i;

        if (value.TryGetValue(out long l))
            return l;

        if (value.TryGetValue(out float f)) 
            return (decimal)f;

        if (value.TryGetValue(out double d))
            return (decimal)d;

        return null;

    }

    /// <summary>
    /// Gets a node's underlying numeric value if it's an integer.
    /// </summary>
    /// <param name="value">A JSON value.</param>
    /// <returns>Gets the underlying numeric value if it's an integer, or null if the node represented a non-integer value.</returns>
    public static long? GetInteger(this JValue value)
    {
        if (value.TryGetValue(out decimal e))
        {
            if (e == Math.Floor(e)) return (long)e;
            return null;
        }
        if (value.TryGetValue(out byte b)) return b;
        if (value.TryGetValue(out sbyte sb)) return sb;
        if (value.TryGetValue(out short s)) return s;
        if (value.TryGetValue(out ushort us)) return us;
        if (value.TryGetValue(out int i)) return i;
        if (value.TryGetValue(out uint ui)) return ui;
        if (value.TryGetValue(out long l)) return l;
        // this doesn't feel right... throw?
        if (value.TryGetValue<ulong>(out _))
            throw new NotSupportedException("Unsigned longs cannot be supported with this method.  A separate check will need to be used.");

        return null;
    }

    /// <summary>
    /// Gets a node's underlying string value.
    /// </summary>
    /// <param name="value">A JSON value.</param>
    /// <returns>Gets the underlying string value, or null.</returns>
    /// <remarks>
    /// JToken may use a <see cref="JsonElement"/> under the hood which subsequently contains a string.
    /// This means that `JToken.GetValue&lt;string&gt;()` will not work as expected.
    /// </remarks>
    public static string? GetString(this JValue value)
    {

        if (value.TryGetValue(out string e))
            return e;

        if (value.TryGetValue(out string? s)) return s;
        if (value.TryGetValue(out char c)) return c.ToString();

        return null;
    }

    /// <summary>
    /// Gets a node's underlying boolean value.
    /// </summary>
    /// <param name="value">A JSON value.</param>
    /// <returns>Gets the underlying boolean value, or null.</returns>
    /// <remarks>
    /// JToken may use a <see cref="JsonElement"/> under the hood which subsequently contains a boolean.
    /// This means that `JToken.GetValue&lt;bool&gt;()` will not work as expected.
    /// </remarks>
    public static bool? GetBool(this JValue value)
    {

        if (value.TryGetValue(out bool e))
            return e;

        if (value.TryGetValue(out bool b)) return b;

        return null;
    }

    /// <summary>
    /// Convenience method that wraps <see cref="JObject.TryGetValue(string, out JToken?)"/>
    /// and catches argument exceptions.
    /// </summary>
    /// <param name="obj">The JSON object.</param>
    /// <param name="propertyName">The property name</param>
    /// <param name="node">The node under the property name if it exists and is singular; null otherwise.</param>
    /// <param name="e">An exception if one was thrown during the access attempt.</param>
    /// <returns>true if the property exists and is singular within the JSON data.</returns>
    /// <remarks>
    /// <see cref="JObject.TryGetValue(string, out JToken?)"/> throws an
    /// <see cref="ArgumentException"/> if the node was parsed from data that has duplicate
    /// keys.  Please see https://github.com/dotnet/runtime/issues/70604 for more information.
    /// </remarks>
    public static bool TryGetValue(this JObject obj, string propertyName, out JToken? node, out Exception? e)
    {
        e = null;
        try
        {
            return obj.TryGetValue(propertyName, out node);
        }
        catch (ArgumentException ae)
        {
            e = ae;
            node = null;
            return false;
        }
    }

    /// <summary>
    /// Creates a new <see cref="JArray"/> by copying from an enumerable of nodes.
    /// </summary>
    /// <param name="nodes">The nodes.</param>
    /// <returns>A JSON array.</returns>
    /// <remarks>
    ///	`JToken` may only be part of a single JSON tree, i.e. have a single parent.
    /// Copying a node allows its value to be saved to another JSON tree.
    /// </remarks>
    public static JArray ToJArray(this IEnumerable<JToken?> nodes)
    {
        return new JArray(nodes.Select(x => x?.DeepClone()).ToArray());
    }

    ///  <summary>
    ///  Gets a JSON Path string that indicates the node's location within
    ///  its JSON structure.
    ///  </summary>
    ///  <param name="node">The node to find.</param>
    ///  <param name="useShorthand">Determines whether shorthand syntax is used when possible, e.g. `$.foo`.</param>
    ///  <exception cref="ArgumentNullException">Null nodes cannot be located as the parent cannot be determined.</exception>
    ///  <returns>
    /// 	A string containing a JSON Path.
    ///  </returns>
    public static string GetPathFromRoot(this JToken node, bool useShorthand = false)
    {
        var current = node ?? throw new ArgumentNullException(nameof(node), "null nodes cannot be located");

        var segments = GetSegments(current);

        var sb = new StringBuilder();
        sb.Append('$');
        segments.Pop();  // first is always null - the root
        while (segments.Count != 0)
        {
            var segment = segments.Pop();
            var index = segment?.GetNumber();
            sb.Append(index != null ? $"[{index}]" : GetNamedSegmentForPath(segment!, useShorthand));
        }

        return sb.ToString();
    }

    private static Stack<JValue?> GetSegments(JToken? current)
    {
        var segments = new Stack<JValue?>();
        while (current != null)
        {
            var segment = current.Parent switch
            {
                null => null,
                JObject obj => GetKey(obj, current),
                JArray arr => GetIndex(arr, current),
#pragma warning disable CA2208
                _ => throw new ArgumentOutOfRangeException("parent", "this shouldn't happen")
#pragma warning restore CA2208
            };
            segments.Push(segment);
            current = current.Parent;
        }

        return segments;
    }

    private static JValue GetKey(JObject obj, JToken current)
    {
        return new JValue(obj.Properties().First(x => ReferenceEquals(x.Value, current)).Name)!;
    }

    private static JValue GetIndex(JArray arr, JToken current)
    {
        return new JValue(arr.IndexOf(current));
    }

    private static readonly Regex _pathSegmentTestPattern = new("^[a-z][a-z_]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static string GetNamedSegmentForPath(JValue segment, bool useShorthand)
    {

        if (segment.TryGetValue(out string value))
        {

            if (useShorthand && _pathSegmentTestPattern.IsMatch(value)) return $".{value}";

        }

        return $"['{PrepForJsonPath(segment.AsJsonString(Oldtonsoft.Json.Formatting.None))}']";

    }

    public static T GetValue<T>(this JToken self)
    {
        return self.ToObject<T>();
    }

    // pass JSON string because it will handle char escaping inside the string.
    // just need to replace the quotes.
    private static string PrepForJsonPath(string jsonString)
    {
        var content = jsonString[1..^1];
        var escaped = content.Replace("\\\"", "\"")
            .Replace("'", "\\'");
        return escaped;
    }

    ///  <summary>
    ///  Gets a JSON Pointer string that indicates the node's location within
    ///  its JSON structure.
    ///  </summary>
    ///  <param name="node">The node to find.</param>
    ///  <exception cref="ArgumentNullException">Null nodes cannot be located as the parent cannot be determined.</exception>
    ///  <returns>
    /// 	A string containing a JSON Pointer.
    ///  </returns>
    public static string GetPointerFromRoot(this JToken node)
    {
        var current = node ?? throw new ArgumentNullException(nameof(node), "null nodes cannot be located");

        var segments = GetSegments(current);

        var sb = new StringBuilder();
        segments.Pop();  // first is always null - the root
        while (segments.Count != 0)
        {
            var segment = segments.Pop();
            var index = segment?.GetNumber();
            sb.Append(index != null ? $"/{index}" : $"/{PrepForJsonPointer(segment!.GetValue<string>())}");
        }

        return sb.ToString();
    }

    private static string PrepForJsonPointer(string s)
    {
        var escaped = s.Replace("~", "~0")
            .Replace("/", "~1");
        return escaped;
    }

}