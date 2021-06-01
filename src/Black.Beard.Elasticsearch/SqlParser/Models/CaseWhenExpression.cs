using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class CaseWhenExpression : AstBase
    {

        public CaseWhenExpression(Locator position) : base(position)
        {

        }
        public AstBase WhenExpr { get; set; }

        public AstBase ThenExpr { get; internal set; }


        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitCaseWhen(this);
        }

    }


}
