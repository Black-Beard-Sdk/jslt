using Bb.Elastic.Runtimes;
using Bb.Elastic.Runtimes.Models;

namespace Bb.Elastic.SqlParser.Models
{

    public class ElasticServerReference : AstBase
    {

        public ElasticServerReference(Locator position) : base (position)
        {

        }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitElasticServerReference(this);
        }


        public Reference ServerReference { get; set; }
        
        public ElasticProcessor ServerConnection { get; set; }

    }


}
