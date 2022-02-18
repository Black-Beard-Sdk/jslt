using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace Bb.Json.Jslt.Services
{

    public class OutputSerializationRule
    {

        public Func<RuntimeContext, JToken, StringBuilder> Rule { get; internal set; }

        public string Filter { get; internal set; }

    }

}
