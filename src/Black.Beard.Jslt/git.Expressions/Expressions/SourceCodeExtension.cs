﻿using Bb.Expresssions.Statements;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expresssions
{
    public static partial class SourceCodeExtension
    {

        public static SourceCode Assign(this SourceCode source, Expression left, Expression right)
        {
            source.Add(left.AssignFrom(right));
            return source;
        }

        public static ConditionalStatement If(this SourceCode source, Expression test, params Statement[] thenCodes)
        {
            return source.If(test, thenCodes, null);
        }

        public static ConditionalStatement If(this SourceCode source, Expression test, SourceCode @then, SourceCode @else)
        {

            var n = new ConditionalStatement()
            {
                ConditionalExpression = test,
            };

            n.Then.Merge(@then);

            if (@else != null)
                n.Else.Merge(@else);

            source.Add(n);

            return n;

        }


        public static ForStatement For(this SourceCode source, Expression initialValueExpression, Expression endValueExpression)
        {

            var Index = source.AddVar(typeof(int), null, initialValueExpression);

            var loop = new ForStatement(initialValueExpression)
            {
                Where = Expression.LessThan(Index, endValueExpression),
                Index = Index,
                MoveIndex = Index.PostIncrementAssign(),
            };
            source.Add(loop);

            return loop;

        }


        public static LoopStatement While(this SourceCode source, Expression conditionExpression)
        {

            var loop = new LoopStatement()
            {
                Where = conditionExpression
            };
            source.Add(loop);

            return loop;

        }




    }

}
