
using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{




    public class SpecificationFilter : AstBase
    {


        public SpecificationFilter(Locator position) : base(position)
        {

        }
        public AstBase Filter { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSpecificationFilter(this);
        }

    }

}
