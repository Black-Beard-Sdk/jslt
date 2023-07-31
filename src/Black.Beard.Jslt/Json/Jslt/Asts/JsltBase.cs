using Bb.Analysis;
using Bb.Asts;
using Bb.Json.Jslt.Parser;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{

    public abstract class JsltBase : IWriter
    {

        public JsltBase()
        {
            this._comments = new List<JsltComment>();
        }

        public JsltKind Kind { get; internal set; }

        public abstract object Accept(IJsltJsonVisitor visitor);

        public JsltBase Source { get; internal set; }

        public JsltBase Where { get; internal set; }

        public TokenLocation Location { get; set; }

        //public TokenLocation Start { get; set; }

        //public TokenLocation End { get; set; }

        public TokenLocation GetLocation()
        {
            int line = this.Location.Start.Line;
            int column = this.Location.Start.Column;
            int startIndex = this.Location.Start.Index;
            int endIndex = this.Location.End.Index;
            return new TokenLocation(startIndex, endIndex, line, column);
        }


        public IEnumerable<JsltComment> Comments { get => this._comments; }

        public virtual string RuleName => GetType().Name;

        public override string ToString()
        {
            Writer writer = new Writer();
            writer.ToString(this);
            return writer.ToString();
        }

        public abstract bool ToString(Writer writer, StrategySerializationItem strategy);

        internal void AddComments(IEnumerable<JsltComment> comments)
        {
            _comments.AddRange(comments);
        }

        private List<JsltComment> _comments;

        public const string Quote = "\"";

    }

}
