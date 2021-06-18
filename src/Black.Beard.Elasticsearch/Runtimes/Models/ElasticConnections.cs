using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class ElasticConnections
    {


        public ElasticConnections()
        {
            this._connections = new Dictionary<string, Connection>();
        }

        public ElasticExecutor GetExecutor()
        {
            return new ElasticExecutor(this);
        }

        public ElasticConnections AddConnection(Connection cnx)
        {
            this._connections.Add(cnx.ConnectionName, cnx);
            cnx.Parent = this;
            return this;
        }

        public int Count { get => _connections.Count; }

        internal Connection this[string key]
        {
            get
            {
                if (!string.IsNullOrEmpty(key))
                    if (_connections.TryGetValue(key, out Connection cnx))
                        return cnx;
                return _connections.FirstOrDefault().Value;
            }
        }

        public Connection this[int key] { get => _connections.Values.Skip(key).First(); }

        public IEnumerable<Connection> Resolve<T>(Func<T, bool> func = null) where T : Connection
        {
            foreach (Connection item in _connections.Values)
                if (item is T c)
                {
                    if (func == null || func(c))
                    yield return item;
                }
        }



        private readonly Dictionary<string, Connection> _connections;


    }


}