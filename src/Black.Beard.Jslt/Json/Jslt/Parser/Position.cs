using Oldtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    internal class Position
    {

        public Position(TokenLocation start, TokenLocation stop, JValue comment)
        {
            this.Start = start;
            this.Stop = stop;
            this.Value = comment;
        }

        public JValue Value { get; }

        public TokenLocation Start { get; }

        public TokenLocation Stop { get; }
    }

}
