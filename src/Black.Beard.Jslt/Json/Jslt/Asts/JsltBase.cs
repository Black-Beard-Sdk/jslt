using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Asts
{


    public class Comment : JsltBase
    {

        public Comment()
        {

        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitComment(this);
        }

    }

    public abstract class JsltBase
    {

        public JsltBase()
        {
            this._comments = new List<Comment>();
        }

        public JsltKind Kind { get; internal set; }

        public abstract object Accept(IJsltJsonVisitor visitor);

        public JsltBase Source { get; internal set; }

        public JsltBase Where { get; internal set; }

        public TokenLocation Start { get; set; }

        public TokenLocation Stop { get; set; }

        public TokenLocation GetLocation()
        {
            int line = this.Start.Line;
            int column = this.Start.Column;
            int startIndex = this.Start.StartIndex;
            int endIndex = this.Stop.StopIndex;
            return new TokenLocation(startIndex, endIndex, line, column);
        }


        public IEnumerable<Comment> Comments { get => this._comments; }


        internal void AddComments(IEnumerable<Comment> comments)
        {
            _comments.AddRange(comments);
        }

        private List<Comment> _comments;


    }

}
