using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    public class ConditionalStatement : Statement
    {


        public ConditionalStatement()
        {

        }

        public Expression ConditionalExpression { get; set; }

        public SourceCode Then
        {
            get
            {
                if (_then == null)
                    Then = new SourceCode();

                return _then;
            }
            set
            {
                _then = value;

                if (this.ParentIsNull)
                    _then.SetParent(this.GetParent());
            }
        }

        public SourceCode Else
        {
            get
            {
                if (_else == null)
                    Else = new SourceCode();

                return _else;
            }
            set
            {
                if (this.ParentIsNull)
                    _else.SetParent(this.GetParent());

                _else = value;
            }
        }


        

        public override Expression GetExpression(HashSet<string> variableParent)
        {

            Expression b1 = Then.GetExpression(new HashSet<string>(variableParent));
            Expression b2 = null;

            if (_else != null)
                b2 = Else.GetExpression(new HashSet<string>(variableParent));

            Expression expression = b2 == null
                ? Expression.IfThen(ConditionalExpression, b1)
                : Expression.IfThenElse(ConditionalExpression, b1, b2)
                ;

            if (expression.CanReduce)
                expression = expression.Reduce();

            return expression;

        }


        internal override void SetParent(SourceCode sourceCodes)
        {
            _then.SetParent(sourceCodes);
            if (_else != null)
                _else.SetParent(sourceCodes);
        }


        private SourceCode _then;
        private SourceCode _else;

    }

}
