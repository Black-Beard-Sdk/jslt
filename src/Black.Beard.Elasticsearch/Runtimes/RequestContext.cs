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

        public string Filename { get; internal set; }

        public StringBuilder Query { get; internal set; }

        public AstBase Ast { get; internal set; }

        public List<object> ExecuableQuery { get; internal set; }

        
        public ContextExecutor Parent { get; }

        internal void AppendRequest(RequestQuery result)
        {
            


        }
    }

}