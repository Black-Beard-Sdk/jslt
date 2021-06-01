using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class CastExpression : AstBase
    {

        public CastExpression(Locator position) : base(position)
        {

        }
        public AstBase Expression { get; set; }
        
        public AstBase TargetType { get;  set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitCaseExpression(this);
        }

    }

}
