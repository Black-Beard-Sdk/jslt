using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationSortItem : AstBase
    {


        public SpecificationSortItem(Locator position) : base(position)
        {

        }

        public bool AscSort { get; set; }
        public Identifier CollationName { get; internal set; }
        public AstBase Expression { get; internal set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSpecificationSort(this);
        }

    }

}
