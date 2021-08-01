using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{

    public abstract class AstBase 
    {

        public AstBase(Locator position)
        {
            this.Position = position;
        }

        public abstract T Accept<T>(IVisitor<T> visitor);


        public AstBase Reference { get; set; }

        public Locator Position { get; }

    }

}
