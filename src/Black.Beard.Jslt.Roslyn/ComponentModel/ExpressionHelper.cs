using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// very helpfull expression helper
    /// </summary>
    public static class ExpressionHelper
    {

        /// <summary>
        /// Smarts convert help to create expression with many consideration on source type and target type.
        /// if no converter found yo can create one in custom class decorated '[Bb.ComponentModel.Attributes.ExposeClass(Context = ConstantsCore.Cast)]'
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException">no adapted method cast found for {argument.Type.Name} -> {targetType.Name}</exception>
        public static Expression SmartConvert(this Expression self, Type targetType)
        {

            var bindings = BindingFlags.Static | BindingFlags.Public;
            var argument = self;

            if (argument is ConstantExpression c)
                argument = Expression.Constant(Convert.ChangeType(c.Value, targetType));

            else
            {

                var types = new List<Type>() { argument.Type };
                MethodInfo convertMethod = null;

                if (targetType.IsAssignableFrom(self.Type))
                    argument = Expression.Convert(self, targetType);

                else
                {

                    if (convertMethod == null) // try to get implicit or explicit opérator
                        convertMethod = MethodDiscovery.GetMethods(argument.Type, bindings, targetType, types).FirstOrDefault();

                    if (convertMethod == null) // try in convert static methods
                        convertMethod = MethodDiscovery.GetMethods(typeof(Convert), bindings, targetType, types).FirstOrDefault();

                    if (convertMethod == null) // try in custom class
                    {

                        var _types = TypeDiscovery.Instance.GetTypesWithAttributes<ExposeClassAttribute>(typeof(object), (attr) => attr.Context == ConstantsCore.Cast).ToList();

                        foreach (var item in _types)
                            if ((convertMethod = MethodDiscovery.GetMethods(item, bindings, targetType, types).FirstOrDefault()) != null)
                                break;

                    }

                    if (convertMethod != null)
                        argument = Expression.Call(convertMethod, argument);

                    else
                    {

                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();

                        throw new InvalidCastException($"no adapted method cast found for {argument.Type.Name} -> {targetType.Name}. Please considere use a static class tagged [ExposeClass(Context =Constants.Cast)] with a specialized method to convert.");

                    }

                }

            }

            return argument;

        }

        /// <summary>
        /// Match parameters names of the method with dictionary key
        /// </summary>
        /// <param name="method">MethodInfo to map</param>
        /// <param name="properties">dictionary of arguments</param>
        /// <param name="arg">instance of dictionary</param>
        /// <param name="ignoreCase">specify if can ignore</param>
        /// <returns></returns>
        public static MethodCallExpression MatchDictionaryOnMethodParameters(this MethodInfo method, Expression instance, Expression arg, bool ignoreCase = true)
        {

            if (method == null)
                throw new ArgumentNullException(nameof(method));

            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            if (arg == null)
                throw new ArgumentNullException(nameof(arg));

            var componentType = typeof(Dictionary<string, object>);

            var methodContainsKey = componentType.GetNamedMethod("ContainsKey", typeof(object));
            var methodThis = componentType.GetNamedMethod("get_Item", typeof(string));

            var parameters = method.GetParameters();
            List<Expression> arguments = new List<Expression>();

            foreach (ParameterInfo parameter in parameters)
            {

                string n = parameter.Name;
                if (ignoreCase)
                    n = n.ToLower();
                var cc = Expression.Constant(n);

                Expression c1 = parameter.ParameterType == typeof(object)
                    ? Expression.Call(arg, methodThis, cc)
                    : (Expression)Expression.Convert(Expression.Call(arg, methodThis, cc), parameter.ParameterType);

                if (parameter.IsOptional)
                    c1 = Expression.IfThen(Expression.Call(arg, methodContainsKey, cc), c1);

                arguments.Add(c1);

            }

            MethodCallExpression m1 = instance == null
                ? Expression.Call(method, arguments)
                : Expression.Call(instance, method, arguments)
                ;

            return m1;

        }

        public static MemberExpression Member(this Expression self, FieldInfo field)
        {
            return Expression.Field(self, field);
        }

        public static MemberExpression Member(this Expression self, PropertyInfo property)
        {
            return Expression.Property(self, property);
        }

        public static UnaryExpression Throw(this Exception exception)
        {
            return Expression.Throw(Expression.Constant(exception));
        }

        public static ConditionalExpression If(Expression test, Expression expressionTrue, Expression expressionFalse = null)
        {
            if (expressionFalse == null)
                return Expression.IfThen(test, expressionTrue);
            return Expression.IfThenElse(test, expressionTrue, expressionFalse);
        }

        public static UnaryExpression IsNull(this Expression test)
        {
            return Expression.IsTrue(Expression.Equal(test, Expression.Constant(null)));
        }

        public static BinaryExpression CreateObject(this Expression self)
        {
            return self.SettedBy(Expression.New(self.Type));
        }

        public static UnaryExpression As(this Expression self, Type type)
        {
            return Expression.ConvertChecked(self, type);
        }

        public static BinaryExpression SettedBy(this Expression self, Expression right)
        {
            return Expression.Assign(self, right);
        }

        public static MethodCallExpression Invoke(this Expression self, MethodInfo method, params Expression[] args)
        {

            if (args.Length == 0)
                return Expression.Call(self, method);
            else
                return Expression.Call(self, method, args);

        }

        public static MethodCallExpression Invoke(this Expression self, string methodName, params Expression[] args)
        {

            MethodInfo method = self.Type.GetNamedMethod(methodName);

            if (method == null)
                throw new Exception("Invalid method name " + methodName);

            if (args.Length == 0)
                return Expression.Call(self, method);
            else
                return Expression.Call(self, method, args);

        }

    }

}
