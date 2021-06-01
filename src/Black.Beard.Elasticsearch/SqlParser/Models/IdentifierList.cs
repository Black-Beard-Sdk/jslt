
using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class IdentifierList : AstList<Identifier>
    {

        public IdentifierList(Locator position) : base(position)
        {

        }

    }


}
