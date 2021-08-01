using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class SpecificationSourceSelect : SpecificationSource
    {

        public SpecificationSourceSelect(Locator position) : base(position)
        {
            
        }

        public Specification Select { get; set; }
        public Identifier ShortName { get; internal set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitSelectSpecificationSource(this);
        }

    }

    public class SpecificationSourceAlias : SpecificationSource
    {

        public SpecificationSourceAlias(Locator position) : base(position)
        {

        }

        public AliasReferenceAst Alias { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.SpecificationSourceAlias(this);
        }

    }


}
