using Bb.Json.Linq;
using System.Text;

namespace Bb.JPaths;

/// <summary>
/// Exposes the filter expression.
/// </summary>
public interface IFilterExpression
{
    /// <summary>
    /// Evaluates the selector.
    /// </summary>
    /// <param name="globalParameter">The root node of the data, represented by `$`.</param>
    /// <param name="localParameter">The current node in the filter, represented by `@`.</param>
    /// <returns>
    /// true if the node should be selected; false otherwise.
    /// </returns>
    bool Evaluate(JToken? globalParameter, JToken? localParameter);
    /// <summary>
    /// Builds a string using a string builder.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    void BuildString(StringBuilder builder);
}