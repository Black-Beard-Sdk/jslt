using Antlr4.Runtime;

namespace Bb.Json.Jslt.Parser
{
    public class TokenLocation
    {

        public TokenLocation(Antlr4.Runtime.IToken token)
        {
            this.Line = token.Line;
            this.Column = token.Column;
            this.StartIndex = token.StartIndex;
            this.StopIndex = token.StopIndex;
        }
        int Line { get; }

        int Column { get; }

        int StartIndex { get; }

        int StopIndex { get; }

    }

    public static class TokenLocationExtension
    {

        public static TokenLocation ToLocation(this IToken self)
        {
            return new TokenLocation(self);
        }

    }

}
