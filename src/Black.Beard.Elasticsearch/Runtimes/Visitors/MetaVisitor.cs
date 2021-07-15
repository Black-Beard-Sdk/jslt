using Bb.Elastic.Runtimes.Models;
using Bb.Elastic.SqlParser.Models;
using System;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes.Visitors
{
    internal class MetaVisitor
    {

        public MetaVisitor(ElasticConnectionList connections)
        {

            this._visitors = new List<Func<ElasticConnectionList, ContextExecutor, IVisitor>>();
            this._connections = connections;
        }

        public MetaVisitor Append(Func<ElasticConnectionList, ContextExecutor, IVisitor> visitor)
        {
            this._visitors.Add(visitor);
            return this;
        }

        public object Visit(AstBase n, ContextExecutor ctx)
        {

            object lastResult = null;

            foreach (var item in this._visitors)
            {
                var v = item(this._connections, ctx);
                lastResult = v.Visit(n);
            }

            return lastResult;

        }

        internal ElasticConnectionList Connections => _connections; 

        private readonly List<Func<ElasticConnectionList, ContextExecutor, IVisitor>> _visitors;
        private readonly ElasticConnectionList _connections;

    }

}