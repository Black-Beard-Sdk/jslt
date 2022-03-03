using Antlr4.Runtime.Atn;

namespace Bb.Parsers.Intellisense
{


    public class IntellisenseKey
    {


        public IntellisenseKey(ATNState state, string name)
        {
            this.State = state;
            this.Name = name;
        }


        public IntellisenseKey(Token token)
        {
            this.Token = token;
            this.Name = token.Name;
        }


        public string Name { get; }


        public Token? Token { get; }

        public ATNState? State { get; }


        public override string ToString()
        {
            return this.Name;
        }

    }

}
