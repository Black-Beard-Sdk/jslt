using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationProjection : AstBase
    {

        public SpecificationProjection(Locator position) : base(position)
        {
            Projections = new AstList<AstBase>(position);
        }

        public AstList<AstBase> Projections { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitProjection(this);
        }

    }


}
