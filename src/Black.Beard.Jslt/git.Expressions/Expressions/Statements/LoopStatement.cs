using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{


    public class LoopStatement : BodyStatement
    {

        public LoopStatement()
        {
            this.Body = new SourceCode();
            this._breakLabel = this.Body.AddLabel(Labels.GetNewName(), KindLabelEnum.Break);
            this._continueLabel = this.Body.AddLabel(Labels.GetNewName(), KindLabelEnum.Continue);
        }

        public Expression Condition { get; set; }

        public override Expression GetExpression(HashSet<string> variableParent)
        {

            Expression b1 = Body.GetExpression(new HashSet<string>(variableParent));

            if (b1.CanReduce)
                b1 = b1.Reduce();

            var @if = Expression.IfThenElse(Condition, b1, GenerateBreak());

            var expression = Expression.Loop(@if, this._breakLabel.Instance, this._continueLabel.Instance);

            return expression;

        }

        public GotoExpression GenerateBreak() { return Expression.Break(_breakLabel.Instance); }

        public GotoExpression GenerateContinue() { return Expression.Break(_continueLabel.Instance); }

        protected readonly Label _breakLabel;
        protected readonly Label _continueLabel;


    }

}
