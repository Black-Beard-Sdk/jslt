using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.CsharpGenerators
{
    public class VariableCollectorVisitor : ExpressionVisitor
    {

        private VariableCollectorVisitor()
        {
            _parameters = new HashSet<ParameterExpression>();
        }

        public static HashSet<ParameterExpression> GetParameters(Expression e)
        {
            VariableCollectorVisitor visitor = new VariableCollectorVisitor();
            visitor.Visit(e);
            return visitor._parameters;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _parameters.Add(node);
            return base.VisitParameter(node);
        }

        private readonly HashSet<ParameterExpression> _parameters;

    }


}
