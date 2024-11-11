using System.Globalization;
using Oldtonsoft.Json.Linq;

namespace Bb.JPaths;

/// <summary>
/// Implements the `length()` function to get:
/// - the length of a string
/// - the count of values in an array
/// - the count of values in an object
/// </summary>
public class LengthFunction : ValueFunctionDefinition
{
    /// <summary>
    /// Gets the function name.
    /// </summary>
    public override string Name => "length";

    /// <summary>
    /// Evaluates the function.
    /// </summary>
    /// <param name="value">An object, array, or string</param>
    /// <returns>If an object or array, the number of items it contains; if a string, the length.</returns>
    public JToken? Evaluate(JToken? value)
    {
        return value switch
        {
            JObject obj => (JValue)obj.Count,
            JArray arr => (JValue)arr.Count,
            JValue val when val.TryGetValue(out string? s) => (JValue)new StringInfo(s).LengthInTextElements,
            _ => Nothing
        };
    }
}