using System;
using System.Text;

namespace Bb.Jslt.Services
{

    public class OutputSerializationRule
    {

        public Func<RuntimeContext, StringBuilder> Rule { get; internal set; }

        public string Filter { get; internal set; }
        
        public Func<RuntimeContext, object> Writer { get; internal set; }

    }

}
