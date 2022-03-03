using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Parsers.Intellisense.Jslt;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Parsers.Intellisense
{
    public class Parser
    {

        private Parser(TextWriter output, TextWriter outputError)
        {

            this.Output = output ?? Console.Out;
            this.OutputError = outputError ?? Console.Error;
            this._includes = new HashSet<string>();
        }

        public static Parser ParseString(StringBuilder source, string sourceFile = "", TextWriter output = null, TextWriter outputError = null)
        {
            ICharStream stream = CharStreams.fromString(source.ToString());

            var parser = new Parser(output, outputError)
            {
                File = sourceFile ?? string.Empty,
                Content = source,
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        public static bool Trace { get; set; }

        public JsltParser.ScriptContext Tree { get { return this._context; } }

        public IEnumerable<string> Includes { get => this._includes; }

        public string File { get; set; }

        public StringBuilder Content { get; private set; }

        public TextWriter Output { get; private set; }

        public TextWriter OutputError { get; private set; }

        private readonly HashSet<string> _includes;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Visit<Result>(IParseTreeVisitor<Result> visitor)
        {

            //if (visitor is IFile f)
            //    f.Filename = this.File;

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Trace.WriteLine(this.File);

            var context = this._context;
            return visitor.Visit(context);

        }

        public bool InError { get => this._parser.ErrorListeners.Count > 0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ParseCharStream(ICharStream stream)
        {

            var lexer = new JsltLexer(stream, this.Output, this.OutputError);
            var token = new CommonTokenStream(lexer);
            this._parser = new JsltParser(token)
            {
                BuildParseTree = true,
                //Trace = ScriptParser.Trace, // Ca plante sur un null, pourquoi ?
            };

            _context = _parser.script();                    

        }

        private JsltParser _parser;
        private JsltParser.ScriptContext _context;

        public bool IsFragment { get; private set; }
    }
}
