using System.Diagnostics;

namespace Bb.Parsers.Intellisense
{
    [DebuggerDisplay("{Type} : {Name} : '{Text}'")]
    public class Token
    {

        public int Type { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

    }

}
