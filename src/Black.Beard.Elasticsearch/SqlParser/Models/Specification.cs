using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{



    public class Specification : AstBase
    {

        public Specification(Locator position) : base(position)
        {

        }

        public SpecificationLimit Limit { get; set; }
        public SpecificationSorting Sort { get; internal set; }
        public SpecificationSource Source { get; internal set; }
        public SpecificationFilter Filter { get; internal set; }
        public SpecificationProjection Projection { get; internal set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSpecification(this);
        }

        
    }

}
