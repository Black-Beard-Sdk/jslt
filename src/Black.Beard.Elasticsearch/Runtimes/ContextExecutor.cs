using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Elastic.Runtimes
{

    public class ContextExecutor
    {

        internal ContextExecutor(ElasticExecutor parent, StringBuilder querySql, string filename)
        {
            this._parent = parent;
            this._references = new List<Reference>();
            this.Request = new RequestContext(this)
            {
                Filename = filename,
                Query = querySql,
            };
            this.Trace = new TraceContext(this);
        }

        public DirectoryInfo WorkingSpace { get => this._parent.WorkingSpace; }

        public CultureInfo Culture { get => this._parent.Culture; }


        public List<Reference> Get(string name)
        {
            if (this._lookup == null)
                this._lookup = this._references.ToLookup(c => c.Name);
            return this._lookup[name].ToList();
        }

        public IEnumerable<Reference> Items { get => _references; }


        public void AddReference(Reference reference)
        {
            this._lookup = null;
            this._references.Add(reference);
        }


        private ElasticExecutor _parent;
        private List<Reference> _references;
        private ILookup<string, Reference> _lookup;

        public RequestContext Request { get; }
        public TraceContext Trace { get; }
    }

}