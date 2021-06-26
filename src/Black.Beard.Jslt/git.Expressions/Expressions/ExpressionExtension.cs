using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Expressions
{
    public static class ExpressionExtension
    {


        public static NewArrayExpression NewArray(this Type self, IEnumerable<Expression> expressions)
        {
            List<Expression> e = new List<Expression>(expressions.Count());
            foreach (var item in expressions)
                e.Add(item.ConvertIfDifferent(self));

            return Expression.NewArrayInit(self, e.ToArray());
        }

        public static NewArrayExpression NewArray(this Type self, params Expression[] expressions)
        {
            List<Expression> e = new List<Expression>(expressions.Length);
            foreach (var item in expressions)
                e.Add(item.ConvertIfDifferent(self));

            return Expression.NewArrayInit(self, e.ToArray());
        }

        public static NewExpression CreateObject(this Type type, params Expression[] args)
        {

            List<Type> _types = new List<Type>();
            foreach (var arg in args)
                _types.Add(arg.ResolveType());

            var ctor = type.GetConstructor(_types.ToArray());
            if (ctor == null)
                throw new MissingMethodException(string.Join(", ", _types.Select(c => c.Name)));

            var result = Expression.New(ctor, args);

            return result;

        }

        /// <summary>
        /// return a creation of object expression
        /// </summary>
        /// <param name="ctor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static NewExpression CreateObject(this ConstructorInfo ctor, params Expression[] args)
        {

            if (ctor == null)
                throw new NullReferenceException(nameof(ctor));

            var result = Expression.New(ctor, args);

            return result;

        }

        public static ConstantExpression AsConstant(this object self, Type type = null)
        {

            if (self is Expression e)
            {
                if (e is ConstantExpression c)
                    return c;
                else
                    throw new InvalidCastException("an expression can't be converted in constant");
            }

            if (type == null)
                return Expression.Constant(self);

            if (self != null && self.GetType() != type && self is IConvertible)
                self = Convert.ChangeType(self, type);

            return Expression.Constant(self, type);

        }

     
        public static MethodCallExpression CallStatic(this MethodInfo self, params Expression[] arguments)
        {

            var parameters = self.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }

            return Expression.Call(self, _args.ToArray());

        }

        

        public static DefaultExpression DefaultValue(this Type self)
        {
            return Expression.Default(self);
        }

    }

}
