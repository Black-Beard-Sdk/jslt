using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class UnaryExpression : AstBase
    {

        public UnaryExpression(Locator position) : base(position)
        {

        }
        public UnaryOperatorEnum Operator { get; set; }

        public AstBase Expression { get; set; }


        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitUnaryExpression(this);
        }

    }

   
}
