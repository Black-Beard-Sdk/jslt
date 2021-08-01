using Bb.Elastic.Runtimes;
using Bb.Elastic.Runtimes.Models;

namespace Bb.Elastic.SqlParser.Models
{
    public class ElasticTableReference : AstBase
    {

        public ElasticTableReference(Locator position) 
            : base(position)
        {
            
        }


        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitElasticTableReference(this);
        }

        public ServerTableStructure TableReference { get; set; }

    }


}
