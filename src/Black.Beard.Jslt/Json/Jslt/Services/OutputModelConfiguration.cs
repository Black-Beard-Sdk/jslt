using System.Collections.Generic;
using Bb.ComponentModel.Factories;
using Bb.Json.Jslt.Asts;
using Newtonsoft.Json;

namespace Bb.Json.Jslt.Services
{

    public class OutputModelConfiguration
    {

        public OutputModelConfiguration()
        {

        }

        public Factory OutputFunction { get; internal set; }

        public JsltFunctionCall Function { get; internal set; }
    }


}
