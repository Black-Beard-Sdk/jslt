using Bb.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Expresssions
{


    /// <summary>
    /// build lanbda and compile for ActionResult 
    /// </summary>
    public static partial class ExpressionHelper
    {


        public static BinaryExpression AssignFrom(this Expression left, Expression right)
        {
            return Expression.Assign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static MemberExpression Property(this Expression self, string propertyName)
        {
            var properties = self.Type.GetProperties();
            var property = properties.Where(c => c.Name == propertyName).FirstOrDefault();

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);
        }

        public static MemberExpression Property(this Expression self, string propertyName, BindingFlags binding)
        {

            var property = self.Type.GetProperty(propertyName, binding);

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);
        }

        public static MemberExpression Property(this Expression self, PropertyInfo property)
        {
            if (property is null)
                throw new NullReferenceException(nameof(property));

            return Expression.Property(self, property);
        }



        public static MethodCallExpression Call(this Expression self, string methodName, params Expression[] arguments)
        {

            var methods = self.Type.GetMethods().ToList();
            methods = methods.Where(c => c.Name == methodName).ToList();

            if (methods.Count == 0)
                throw new MissingMemberException(methodName);

            methods = methods.Where(c => c.GetParameters().Length == arguments.Length).ToList();
            if (methods.Count == 0)
                throw new MissingMemberException($"no method {methodName} match with specified argumentq");

            if (methods.Count > 1)
                throw new DuplicatedArgumentNameException(methodName);

            var method = methods[0];

            var parameters = method.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }


            return Expression.Call(self, method, _args.ToArray());

        }

        public static MethodCallExpression Call(this Expression self, MethodInfo methodTarget, params Expression[] arguments)
        {

            var parameters = methodTarget.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }

            return Expression.Call(self, methodTarget, _args.ToArray());

        }

        public static MethodCallExpression Call(this MethodInfo methodTarget, params Expression[] arguments)
        {

            var parameters = methodTarget.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];
                if (argument != null && parameter != null)
                    _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));
                else
                    return null;

            }

            return Expression.Call(null, methodTarget, _args.ToArray());

        }


        public static UnaryExpression Throw(this Type type, params Expression[] args)
        {

            if (!typeof(Exception).IsAssignableFrom(type))
                throw new InvalidCastException($"{type.Name} don't inherit from Exception");

            var result = Expression.Throw(type.CreateObject(args), typeof(NullReferenceException));

            return result;

        }



        public static Type ResolveType(this Expression self)
        {

            return self.NodeType == ExpressionType.Lambda
                ? (self as LambdaExpression).ReturnType
                : self.Type;

        }

        public static IndexExpression Arrayindex(this Expression self, Expression index)
        {
            return Expression.ArrayAccess(self, index);
        }


        public static int CanBeConverted(this Type sourceType, Type targetType)
        {

            if (sourceType == targetType)
                return 0;

            try
            {
                var e = Expression.Convert(Expression.Parameter(sourceType), targetType);
                return 1;
            }
            catch (Exception)
            {
                var method = ConverterHelper.GetConvertMethod(sourceType, targetType);
                if (method != null)
                    return 2;
            }

            return -1;

        }


        //private static bool InheritFrom(this Type sourceType, Type tartType)
        //{

        //}


        /// <summary>
        /// return an expression of convertion if targetype are differents
        /// </summary>
        /// <param name="self"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static Expression ConvertIfDifferent(this Expression self, Type targetType)
        {

            Expression result = null;
            Type sourceType = self.ResolveType();

            if (sourceType != targetType)
            {

                if (targetType.IsAssignableFrom(sourceType))
                    result = Expression.Convert(self, targetType);

                else if (sourceType.IsAssignableFrom(targetType))
                    result = Expression.Convert(self, targetType);

                else
                {

                    var method = ConverterHelper.GetConvertMethod(sourceType, targetType);
                    if (method != null)
                    {
                        result = Convert(self, targetType, result, sourceType, method);
                        if (result == null)
                            throw new InvalidCastException($"no method for convert {sourceType} in {targetType}. please use ConverterHelper forregister a custom method");

                    }
                    
                }


            }
            else
                result = self;

            return result;

        }

        private static Expression Convert(Expression self, Type targetType, Expression result, Type sourceType, MethodBase method)
        {

            var parameters = method.GetParameters();
            Expression[] arguments = new Expression[parameters.Length];

            if (parameters[0].ParameterType == sourceType)
                arguments[0] = self;

            else if (typeof(IFormatProvider).IsAssignableFrom(parameters[0].ParameterType))
                arguments[0] = Expression.Constant(CultureInfo.CurrentCulture);

            else if (parameters[0].ParameterType.IsAssignableFrom(sourceType))
                arguments[0] = ConvertIfDifferent(self, parameters[0].ParameterType);

            else if (parameters[0].ParameterType == typeof(Type))
                arguments[0] = Expression.Constant(targetType);

            else
            {

            }

            if (parameters.Length > 1)
            {
                if (parameters[1].ParameterType == sourceType)
                    arguments[1] = self;

                else if (typeof(IFormatProvider).IsAssignableFrom(parameters[1].ParameterType))
                    arguments[1] = Expression.Constant(CultureInfo.CurrentCulture);

                else if (parameters[1].ParameterType.IsAssignableFrom(sourceType))
                    arguments[1] = ConvertIfDifferent(self, parameters[0].ParameterType);

                else if (parameters[1].ParameterType == typeof(Type))
                    arguments[1] = Expression.Constant(targetType);

                else
                {

                }

            }

            if (method is MethodInfo m)
            {

                if (m.IsStatic)
                    result = Expression.Call(null, m, arguments);
                else
                    result = Expression.Call(self, m, arguments);

            }
            else if (method is ConstructorInfo ctor)
                result = Expression.New(ctor, arguments);
            return result;
        }

        public static TypeBinaryExpression TypeEqual(this Expression left, Type type)
        {
            return Expression.TypeEqual(left, type);
        }

        public static TypeBinaryExpression TypeIs(this Expression left, Type type)
        {
            return Expression.TypeIs(left, type);
        }

        public static LoopExpression TypeIs(this Expression body)
        {
            return Expression.Loop(body);
        }




        #region Binary expressions

        public static BinaryExpression Add(this Expression left, Expression right)
        {
            return Expression.Add(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression AddAssign(this Expression left, Expression right)
        {
            return Expression.AddAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression And(this Expression left, Expression right)
        {
            return Expression.And(left, right);
        }

        public static BinaryExpression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        public static BinaryExpression AndAssign(this Expression left, Expression right)
        {
            return Expression.AndAssign(left, right);
        }

        public static BinaryExpression Coalesce(this Expression left, Expression right)
        {
            return Expression.Coalesce(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression Divide(this Expression left, Expression right)
        {
            return Expression.Divide(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression DivideAssign(this Expression left, Expression right)
        {
            return Expression.DivideAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression Equal(this Expression left, Expression right)
        {
            return Expression.Equal(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression ExclusiveOr(this Expression left, Expression right)
        {
            return Expression.ExclusiveOr(left, right);
        }

        public static BinaryExpression ExclusiveOrAssign(this Expression left, Expression right)
        {
            return Expression.ExclusiveOrAssign(left, right);
        }

        public static BinaryExpression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression GreaterThanOrEqual(this Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression LeftShift(this Expression left, Expression right)
        {
            return Expression.LeftShift(left, right);
        }

        public static BinaryExpression LeftShiftAssign(this Expression left, Expression right)
        {
            return Expression.LeftShiftAssign(left, right);
        }

        public static BinaryExpression LessThan(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression LessThanOrEqual(this Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression Modulo(this Expression left, Expression right)
        {
            return Expression.Modulo(left, right);
        }

        public static BinaryExpression ModuloAssign(this Expression left, Expression right)
        {
            return Expression.ModuloAssign(left, right);
        }

        public static BinaryExpression Multiply(this Expression left, Expression right)
        {
            return Expression.Multiply(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression MultiplyAssign(this Expression left, Expression right)
        {
            return Expression.MultiplyAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression NotEqual(this Expression left, Expression right)
        {
            return Expression.NotEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression Or(this Expression left, Expression right)
        {
            return Expression.Or(left, right);
        }

        public static BinaryExpression OrAssign(this Expression left, Expression right)
        {
            return Expression.OrAssign(left, right);
        }

        public static BinaryExpression OrElse(this Expression left, Expression right)
        {
            return Expression.OrElse(left, right);
        }

        public static BinaryExpression Power(this Expression left, Expression right)
        {
            return Expression.Power(left, right);
        }

        public static BinaryExpression PowerAssign(this Expression left, Expression right)
        {
            return Expression.PowerAssign(left, right);
        }

        public static BinaryExpression RightShift(this Expression left, Expression right)
        {
            return Expression.RightShift(left, right);
        }

        public static BinaryExpression RightShiftAssign(this Expression left, Expression right)
        {
            return Expression.RightShiftAssign(left, right);
        }

        public static BinaryExpression Subtract(this Expression left, Expression right)
        {
            return Expression.Subtract(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        public static BinaryExpression SubtractAssign(this Expression left, Expression right)
        {
            return Expression.SubtractAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        #endregion Binary expressions

        #region Unary expression

        public static UnaryExpression TypeAs(this Expression left, Type type)
        {
            return Expression.TypeAs(left, type);
        }

        public static UnaryExpression Decrement(this Expression left)
        {
            return Expression.Decrement(left);
        }

        public static UnaryExpression PostDecrementAssign(this Expression left)
        {
            return Expression.PostDecrementAssign(left);
        }

        public static UnaryExpression PreDecrementAssign(this Expression left)
        {
            return Expression.PreDecrementAssign(left);
        }



        public static UnaryExpression IsTrue(this Expression left)
        {
            return Expression.IsTrue(left);
        }

        public static UnaryExpression IsFalse(this Expression left)
        {
            return Expression.IsFalse(left);
        }

        public static UnaryExpression Not(this Expression left)
        {
            return Expression.Not(left);
        }

        public static UnaryExpression Negate(this Expression left)
        {
            return Expression.Negate(left);
        }


        public static UnaryExpression Increment(this Expression left)
        {
            return Expression.Increment(left);
        }

        public static UnaryExpression PostIncrementAssign(this Expression left)
        {
            return Expression.PostIncrementAssign(left);
        }

        public static UnaryExpression PreIncrementAssign(this Expression left)
        {
            return Expression.PreIncrementAssign(left);
        }

        #endregion Unary expression




    }

}
