using Antlr4.Runtime;
using Bb.Compilers;

namespace Bb.Json.Jslt.Parser
{

    [System.Diagnostics.DebuggerDisplay("{StartIndex}, {StopIndex} : ({Line},{Column})")]
    public class TokenLocation
    {

        public TokenLocation()
        {

        }

        public TokenLocation(int start, int end)
        {
            this.StartIndex = start;
            this.StopIndex = end;
        }

        public TokenLocation(int start, int end, int line, int column)
        {
            this.StartIndex = start;
            this.StopIndex = end;
            this.Line = line;
            this.Column = column;
        }

        public TokenLocation(Antlr4.Runtime.IToken token)
        {
            this.Line = token.Line;
            this.Column = token.Column;
            this.StartIndex = token.StartIndex;
            this.StopIndex = token.StopIndex;
        }

        public TokenLocation(LocationResult location)
        {
            this.Line = location.StartLine;
            this.Column = location.StartColumn;
            this.StartIndex = location.StartCharacter;
            this.StopIndex = location.EndCharacter;
        }

        public int Line { get; }

        public int Column { get; }

        public int StartIndex { get; }

        public int StopIndex { get; }

        public TokenLocation Clone()
        {
            return new TokenLocation(this.StartIndex, this.StopIndex);
        }

    }

    public static class TokenLocationExtension
    {

        public static TokenLocation ToLocation(this IToken self)
        {
            return new TokenLocation(self);
        }

    }

}
