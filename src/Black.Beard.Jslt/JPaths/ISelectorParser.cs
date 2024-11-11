﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Bb.JPaths;

internal interface ISelectorParser
{
    bool TryParse(ReadOnlySpan<char> source, ref int index, [NotNullWhen(true)] out ISelector? selector, PathParsingOptions options);
}