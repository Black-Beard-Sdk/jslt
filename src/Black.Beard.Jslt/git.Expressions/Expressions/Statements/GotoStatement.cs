using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{
    public class GotoStatement : Statement
    {

        public GotoStatement()
        {

        }

        public Label Label { get; set; }

        public Expression Expression { get; set; }

        public override Expression GetExpression(HashSet<string> variableParent)
        {
            return null;
        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            
        }

    }

}
