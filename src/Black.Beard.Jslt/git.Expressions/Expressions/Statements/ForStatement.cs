using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{
    public class ForStatement : LoopStatement
    {


        public ForStatement(Expression InitialExpression)
        {

        }

        public ParameterExpression Index { get; set; }

        public Expression MoveIndex { get; set; }


        public override Expression GetExpression(HashSet<string> variableParent)
        {

            if (MoveIndex == null)
                throw new NullReferenceException(nameof(MoveIndex));

            Body.Add(MoveIndex);

            return base.GetExpression(variableParent);

        }


    }

}
