using Bb.Jslt.Asts;

namespace Bb.Jslt
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
