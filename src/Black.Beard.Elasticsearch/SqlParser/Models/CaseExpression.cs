using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{

    public class CaseExpression : AstBase
    {


        public CaseExpression(Locator position) : base(position)
        {
            Cases = new AstList<CaseWhenExpression>(position);
        }

        public AstBase CaseExpr { get; set; }
        
        public AstList<CaseWhenExpression> Cases { get; set; }

        public AstBase ElseExpr { get; internal set; }


        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitCase(this);
        }

    }


}
