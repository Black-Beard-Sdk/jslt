using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationSourceTable : SpecificationSource
    {

        public SpecificationSourceTable(Locator position) : base(position)
        {

        }

        public Identifier Name { get; set; }
        
        public Identifier IndexedBy { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitTableSpecificationSource(this);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }

}
