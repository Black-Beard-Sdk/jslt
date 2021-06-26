using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{
    public class ExpressionStatement : Statement
    {

        public ExpressionStatement() 
        {

        }

        public Expression Expression { get; set; }

        public override Expression GetExpression(HashSet<string> variableParent)
        {

            Expression expression = this.Expression;

            if (expression.CanReduce)
                expression = expression.Reduce();

            return expression;

        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            
        }

    }

}
