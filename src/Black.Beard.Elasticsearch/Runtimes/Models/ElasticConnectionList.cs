using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Elastic.Runtimes.Models
{

    public class ElasticConnectionList
    {

        internal ElasticConnectionList()
        {
            this._connections = new Dictionary<string, ElasticAbstractProcessor>();
        }

        public ElasticExecutor GetExecutor()
        {
            return new ElasticExecutor(this);
        }

        public ElasticConnectionList AddConnection(ElasticAbstractProcessor cnx)
        {
            this._connections.Add(cnx.ConnectionName, cnx);
            cnx.Parent = this;
            return this;
        }

        public int Count { get => _connections.Count; }

        public ElasticAbstractProcessor this[string key]
        {
            get
            {
                if (!string.IsNullOrEmpty(key))
                    if (_connections.TryGetValue(key, out ElasticAbstractProcessor cnx))
                        return cnx;
                return _connections.FirstOrDefault().Value;
            }
        }

        public ElasticAbstractProcessor this[int key] { get => _connections.Values.Skip(key).First(); }

        public IEnumerable<ElasticAbstractProcessor> Resolve<T>(Func<T, bool> func = null) where T : ElasticAbstractProcessor
        {
            foreach (ElasticAbstractProcessor item in _connections.Values)
                if (item is T c)
                {
                    if (func == null || func(c))
                    yield return item;
                }
        }



        private readonly Dictionary<string, ElasticAbstractProcessor> _connections;


    }


}