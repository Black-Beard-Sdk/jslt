using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Visitors
{
    internal class MetaVisitor
    {

        public MetaVisitor(Connections connections)
        {

            this._visitors = new List<Func<Connections, ContextExecutor, IVisitor>>();
            this._connections = connections;
        }

        public MetaVisitor Append(Func<Connections, ContextExecutor, IVisitor> visitor)
        {
            this._visitors.Add(visitor);
            return this;
        }

        public object Visit(AstBase n, ContextExecutor ctx)
        {

            foreach (var item in this._visitors)
            {
                var v = item(this._connections, ctx);
                v.Visit(n);
            }
            return n;

        }

        private readonly List<Func<Connections, ContextExecutor, IVisitor>> _visitors;
        private readonly Connections _connections;
    }

}