using Bb.Analysis;
using Oldtonsoft.Json.Linq;

namespace Bb.Json.Jslt.Parser
{
    internal class Position
    {

        public Position(TextLocation start, TextLocation stop, JValue comment)
        {
            this.Start = start;
            this.Stop = stop;
            this.Value = comment;
        }

        public JValue Value { get; }

        public TextLocation Start { get; }

        public TextLocation Stop { get; }
    }

}
