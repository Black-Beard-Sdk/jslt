using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationSorting : AstBase
    {

        public SpecificationSorting(Locator position) : base(position)
        {
            Sorts = new AstList<SpecificationSortItem>(position);
        }
        
        
        public AstList<SpecificationSortItem> Sorts { get; set; }


        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSorting(this);
        }

    }


}
