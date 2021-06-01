using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class FunctionCall : AstBase
    {

        public FunctionCall(Locator position) : base(position)
        {
            this.Arguments = new AstList<AstBase>(position);
        }

        public Identifier Name { get; set; }
        public AstList<AstBase> Arguments { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitFunctionCall(this);
        }

    }

}
