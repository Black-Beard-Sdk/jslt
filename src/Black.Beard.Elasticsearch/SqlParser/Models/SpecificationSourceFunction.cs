using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{

    public class SpecificationSourceFunction : SpecificationSource
    {

        public SpecificationSourceFunction(Locator position) : base(position)
        {
        }

        public FunctionCall Function { get; set;  }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitFunctionSpecificationSource(this);
        }

    }

}
