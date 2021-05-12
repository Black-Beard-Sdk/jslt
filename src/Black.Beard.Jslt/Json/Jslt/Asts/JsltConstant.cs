using Newtonsoft.Json.Linq;
using System;

namespace Bb.Json.Jslt.Asts
{

    public class JsltConstant : JsltBase
    {

        public JsltConstant()
        {

        }

        public object Value { get; set; }

        
        public Type Type { get => Value?.GetType() ?? typeof(object); }


        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitConstant(this);
        }


        public override string ToString()
        {
            return Value.ToString();
        }


    }

}
