using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    public abstract class Statement
    {

        public Statement()
        {

        }

        public abstract Expression GetExpression(HashSet<string> variableParent);

        public static implicit operator Statement(Expression expression)
        {
            return new ExpressionStatement() { Expression = expression };
        }

        internal virtual void SetParent(SourceCode sourceCodes)
        {
            _parent = sourceCodes;
        }

        internal SourceCode GetParent()
        {
            return _parent;
        }

        internal bool ParentIsNull { get => _parent != null; }

        private SourceCode _parent;

    }


}
