using Bb.Analysis.DiagTraces;
using Bb.Asts;
using Bb.Contracts;
using Bb.Jslt.Parser;
using Bb.Jslt.Services;
using System.Collections.Generic;

namespace Bb.Jslt.Asts
{

    /// <summary>
    /// Represents a node in a Jslt.
    /// </summary>
    public abstract class JsltBase : IWriter
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltBase"/> class.
        /// </summary>
        public JsltBase()
        {
            this._comments = new List<JsltComment>();
        }

        /// <summary>
        /// Gets the kind of the node ast.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public JsltKind Kind { get; internal set; }

        /// <summary>
        /// Accepts the specified visitor for parsing the tree.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public abstract object Accept(IJsltJsonVisitor visitor);

        /// <summary>
        /// Gets the source of data.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public JsltBase Source { get; set; }

        /// <summary>
        /// Gets the where condition to apply on source.
        /// </summary>
        /// <value>
        /// The where.
        /// </value>
        public JsltBase Where { get; set; }

        /// <summary>
        /// Gets or sets the location of the code source.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public TextLocation? Location { get; set; }


        /// <summary>
        /// Gets the comment's list.
        /// </summary>
        /// <returns></returns>
        public TextLocation? GetLocation()
        {
            return Location?.Copy();
        }

        /// <summary>
        /// Gets the comment's list.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public IEnumerable<JsltComment> Comments { get => this._comments; }

        public virtual string RuleName => GetType().Name;

        /// <summary>
        /// Evaluate text value
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static JsltBase Evaluate(string text)
        {
            var _errors = new ScriptDiagnostics();
            var parser = ScriptParser.ParseString(text);
            var visitor = new ScriptBuilderVisitor(TranformJsonAstConfiguration.Configuration, parser.Parser, _errors, string.Empty);
            var tree = (JsltBase)parser.Visit(visitor);
            return tree;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            Writer writer = new Writer();
            writer.ToString(this);
            return writer.ToString();
        }

        /// <summary>
        /// Converts the tree to json string source code.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        public abstract bool ToString(Writer writer, StrategySerializationItem strategy);

        /// <summary>
        /// Adds the specified comments.
        /// </summary>
        /// <param name="comments">The comments.</param>
        internal void AddComments(IEnumerable<JsltComment> comments)
        {
            _comments.AddRange(comments);
        }

        private List<JsltComment> _comments;

        public const string Quote = "\"";

    }

}
