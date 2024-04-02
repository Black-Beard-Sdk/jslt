using Bb.Asts;
using Bb.Contracts;
using Bb.Json.Jslt.Parser;

namespace Bb.Json.Jslt.Asts
{

    /// <summary>
    /// Represents a comment in a Jslt.
    /// </summary>
    public class JsltComment : JsltBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="JsltComment"/> class.
        /// </summary>
        public JsltComment()
        {

        }

        public override object Accept(IJsltJsonVisitor visitor)
        {
            return visitor.VisitComment(this);
        }

        public override bool ToString(Writer writer, StrategySerializationItem strategy)
        {
            return true;
        }

    }

}
