using System.Collections.Generic;
using Bb.ComponentModel.Factories;
using Bb.Json.Jslt.Asts;
using Oldtonsoft.Json;

namespace Bb.Json.Jslt.Services
{

    public class OutputModelConfiguration
    {

        public OutputModelConfiguration()
        {

        }


        public JsltFunctionCall Function { get; internal set; }

        public JsltPath Filter { get; internal set; }

        public JsltBase Writer { get; internal set; }


    }


}
