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


        public JsltFunctionCall Function { get; internal set; }

        public JsltPath Filter { get; internal set; }

    }


}
