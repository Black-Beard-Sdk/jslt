using System;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths;

internal class WildcardSelectorParser : ISelectorParser
{
    public bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out ISelector? selector, PathParsingOptions options)
    {
        if (source[index] != '*')
        {
            selector = null;
            return false;
        }

        selector = new WildcardSelector();
        index++;
        return true;
    }
}