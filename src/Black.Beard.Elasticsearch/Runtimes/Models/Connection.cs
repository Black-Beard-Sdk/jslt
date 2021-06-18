using Elasticsearch.Net;
using System;

namespace Bb.Elastic.Runtimes.Models
{

    public abstract class Connection
    {

        public Connection(string name)
        {
            this.ConnectionName = name;
        }

        public string ConnectionName { get; }
        public ElasticConnections Parent { get; internal set; }

        public abstract Result ExecuteQuery<TResponse>(ContextExecutor ctx, object query)
            where TResponse : class, new();

        public abstract RequestQuery Plane(ContextExecutor ctx, object query);


        public ServerTablesStructure Tables(ContextExecutor ctx)
        {

            if (_items == null)
                _items = ResolveCatalogue(ctx);

            return _items;
        }

        protected virtual ServerTablesStructure ResolveCatalogue(ContextExecutor ctx)
        {
            return new ServerTablesStructure();
        }

        public override string ToString()
        {
            return $"cnx : {ConnectionName}";
        }

        private ServerTablesStructure _items;

    }

}