using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bb.Elastic.Runtimes
{
    public class TraceContext
    {

        public TraceContext(ContextExecutor ctx)
        {
            this.Parent = ctx;
            this._errors = new List<ResultMessageModel>();
        }

        public ContextExecutor Parent { get; }

        public TextWriter Output { get; set; }

        public TextWriter OutputError { get; set; }

        public bool InError { get => _errors.Any(c => c.Severity == ResultMessageModelSeverityEnum.Error); }

        internal void AddError(ResultMessageModel errorModel)
        {
            errorModel.Position.Filename = this.Parent.Request.Filename;
            _errors.Add(errorModel);
        }

        private List<ResultMessageModel> _errors;

    }

}