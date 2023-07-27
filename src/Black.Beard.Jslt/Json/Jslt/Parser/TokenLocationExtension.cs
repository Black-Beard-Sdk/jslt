using Antlr4.Runtime;
using Bb.Analysis;
using Bb.Compilers;

namespace Bb.Json.Jslt.Parser
{

    public static class TokenLocationExtension
    {

        public static TokenLocation ToLocation(this IToken self)
        {
            return new TokenLocation()
            {
                Line = self.Line,
                Column = self.Column,
                StartIndex = self.StartIndex,
                StopIndex = self.StopIndex,
            };
        }

    }

}
