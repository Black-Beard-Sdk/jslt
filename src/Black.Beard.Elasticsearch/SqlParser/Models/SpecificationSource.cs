using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{

    public abstract class SpecificationSource : AstBase
    {

        public SpecificationSource(Locator position) : base(position)
        {
            Subs = new AstList<SpecificationSource>(position);
        }

        public AstList<SpecificationSource> Subs { get; }


    }

}
