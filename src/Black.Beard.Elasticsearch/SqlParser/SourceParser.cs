using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Elastic.Parser;
using Bb.Elastic.Lexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Elastic.Parser
{


    public class SourceParser
    {

        public SourceParser(TextWriter output, TextWriter outputError)
        {

            this.Output = output ?? Console.Out;
            this.OutputError = outputError ?? Console.Error;
            this._includes = new HashSet<string>();
        }

        public static SourceParser ParseString(StringBuilder source, string sourceFile = "", TextWriter output = null, TextWriter outputError = null)
        {
            ICharStream stream = CharStreams.fromString(source.ToString());

            var parser = new SourceParser(output, outputError)
            {
                File = sourceFile ?? string.Empty,
                Content = source,
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        /// <summary>
        /// Load specified document in a dedicated parser
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output"></param>
        /// <param name="outputError"></param>
        /// <returns></returns>
        public static SourceParser ParsePath(string source, TextWriter output = null, TextWriter outputError = null)
        {

            var payload = new StringBuilder(source.LoadContentFromFile());
            ICharStream stream = CharStreams.fromString(payload.ToString());

            var parser = new SourceParser(output, outputError)
            {
                File = source,
                Content = payload,
            };

            parser.ParseCharStream(stream);

            return parser;

        }

        public static bool Trace { get; set; }

        public ElasticParser.Sql_stmt_listContext Tree { get { return this._context; } }

        public IEnumerable<string> Includes { get => this._includes; }

        public string File { get; set; }

        public StringBuilder Content { get; private set; }

        public TextWriter Output { get; private set; }

        public TextWriter OutputError { get; private set; }

        private readonly HashSet<string> _includes;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Visit<Result>(IParseTreeVisitor<Result> visitor)
        {

            if (visitor is IFile f)
                f.Filename = this.File;

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Trace.WriteLine(this.File);

            var context = this._context;
            return visitor.Visit(context);

        }

        public bool InError { get => this._parser.ErrorListeners.Count > 0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ParseCharStream(ICharStream stream)
        {

            var lexer = new ElasticLexer(stream, this.Output, this.OutputError);
            var token = new CommonTokenStream(lexer);
            this._parser = new ElasticParser(token)
            {
                BuildParseTree = true,
                //Trace = ScriptParser.Trace, // Ca plante sur un null, pourquoi ?
            };

            _context = _parser.sql_stmt_list();

        }

        private ElasticParser _parser;
        private ElasticParser.Sql_stmt_listContext _context;

    }

}
