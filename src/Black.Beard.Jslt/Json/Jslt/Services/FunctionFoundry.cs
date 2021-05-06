using Bb.Json.Jslt.Parser;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Services
{
    internal class FunctionFoundry
    {
        private TranformJsonAstConfiguration configuration;
        private Dictionary<string, JfunctionDefinition> functions;

        public FunctionFoundry(TranformJsonAstConfiguration configuration, Dictionary<string, JfunctionDefinition> functions)
        {
            this.configuration = configuration;
            this.functions = functions;
        }
    }
}