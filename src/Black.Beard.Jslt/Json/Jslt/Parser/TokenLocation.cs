namespace Bb.Json.Jslt.Parser
{
    internal class TokenLocation
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

}
