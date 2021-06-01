using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class AliasAstBase : Identifier
    {

        public AliasAstBase(Locator position) : base(position)
        {

        }

        public AstBase Value { get; set; }

        public Identifier AliasName { get; set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitAlias(this);
        }

    }


}
