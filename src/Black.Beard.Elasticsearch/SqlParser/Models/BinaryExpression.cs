using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{

    public class BinaryExpression : AstBase
    {

        public BinaryExpression(Locator position) : base(position)
        {

        }
        public AstBase Left { get; set; }

        public AstBase Right { get; set; }

        public BinaryOperatorEnum Operator { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitBinaryExpression(this);
        }

    }

   
}
