using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Elastic.Runtimes
{
    public class RequestContext
    {


        public RequestContext(ContextExecutor ctx)
        {
            this.Parent = ctx;

        }

        public bool IsSql { get; internal set; }

        public string Filename { get; internal set; }

        public StringBuilder QueryText { get; internal set; }

        public AstBase Ast { get; internal set; }

        public List<ECall> ExecutableQueries { get; internal set; }

        
        public ContextExecutor Parent { get; }

        internal void AppendRequest(RequestQuery result)
        {
            


        }
    }

}