using Bb.Jslt.Asts;

namespace Bb.Jslt.Services
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
