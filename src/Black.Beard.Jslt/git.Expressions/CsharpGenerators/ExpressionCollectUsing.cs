using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.CsharpGenerators
{
    public class ExpressionCollectUsing : ExpressionVisitor
    {

        public static HashSet<string> Collect(Expression e, HashSet<string> usings)
        {
            var v = new ExpressionCollectUsing(usings ?? new HashSet<string>());
            v.Visit(e);
            return v.Usings;
        }

        private ExpressionCollectUsing(HashSet<string> usings)
        {
            this._usings = usings;
        }

        public HashSet<string> Usings => _usings;

        protected override Expression VisitBinary(BinaryExpression node)
        {
            CollectNamespace(node.Left.Type);
            CollectNamespace(node.Right.Type);
            return base.VisitBinary(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            CollectNamespace(node.Type);
            return base.VisitConstant(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            CollectNamespace(node.Type);
            return base.VisitParameter(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            CollectNamespace(node.Method.DeclaringType);
            foreach (var arg in node.Arguments)
            {
                CollectNamespace(arg.Type);
            }
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            CollectNamespace(node.Member.DeclaringType);
            return base.VisitMember(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            CollectNamespace(node.Operand.Type);
            return base.VisitUnary(node);
        }

        protected override Expression VisitNew(NewExpression node)
        {
            CollectNamespace(node.Type);
            foreach (var arg in node.Arguments)
            {
                CollectNamespace(arg.Type);
            }
            return base.VisitNew(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            CollectNamespace(node.ReturnType);
            foreach (var param in node.Parameters)
            {
                CollectNamespace(param.Type);
            }
            return base.VisitLambda(node);
        }

        private void CollectNamespace(Type type)
        {
            try
            {
                if (type.Namespace != null)
                {
                    _usings.Add(type.Namespace);
                }
            }
            catch (Exception)
            {

            }

        }

        private readonly HashSet<string> _usings;

    }

}
