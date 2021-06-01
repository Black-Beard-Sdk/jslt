using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationLimit : AstBase
    {


        public SpecificationLimit(Locator position) : base(position)
        {

        }
        public Literal RowCount { get; set; }

        public Literal Offset { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSpecificationLimit(this);
        }

    }

}
