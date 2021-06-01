using Bb.Elastic.Runtimes;

namespace Bb.Elastic.SqlParser.Models
{
    public class ParameterBind : AstBase
    {


        public ParameterBind(Locator position) : base(position)
        {

        }
        public string Label { get;  set; }

        public override T Accept<T>(IVisitor<T> visitor)
        {
            return visitor.VisitParameter(this);
        }

    }




}
