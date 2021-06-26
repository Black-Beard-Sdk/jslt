using System;
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


        internal SourceCode _parent;

        public static implicit operator Statement(Expression expression)
        {
            return new ExpressionStatement() { Expression = expression };
        }

        internal abstract void SetParent(SourceCode sourceCodes);

    }

    public abstract class BodyStatement : Statement
    {


        public BodyStatement()
        {

        }
     
        public SourceCode Body
        {
            get
            {

                if (_body == null)
                    Body = new SourceCode();

                return _body;
            }
            set
            {
                if (this._parent != null)
                    _body.SetParent(_parent);

                _body = value;
            }
        }

        internal override void SetParent(SourceCode sourceCodes)
        {
            _body.SetParent(sourceCodes);
        }

        private SourceCode _body;
    }


}
