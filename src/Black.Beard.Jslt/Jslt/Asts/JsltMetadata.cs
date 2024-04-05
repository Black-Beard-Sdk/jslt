using Bb.Contracts;
using Bb.Jslt.Parser;

namespace Bb.Jslt.Asts
{

    public class JsltMetadata : JsltConstant
    {

        public JsltMetadata(object value) : base(value, JsltKind.Object)
        {

        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitMetadata(this);
        }


    }

}
