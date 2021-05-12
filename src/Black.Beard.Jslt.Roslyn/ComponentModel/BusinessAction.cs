using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Contain a method discovered
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    [System.Diagnostics.DebuggerDisplay("{RuleName}")]
    public class BusinessAction<TContext>
    {

        public BusinessAction()
        {

        }
        
        /// <summary>
        /// Return an expression from the method
        /// </summary>
        /// <param name="argumentContext"></param>
        /// <returns></returns>
        public MethodCallExpression GetCallMethod(Expression instance, Expression[] arguments)
        {
            // build custom method
            var _parameters = Method.GetParameters();
            List<Expression> _args = TranslateArguments(arguments, _parameters); // Force type of argument to match with type of parameters of the method

            var m = instance == null    // Business method
                ? Expression.Call(Method, _args.ToArray())
                : Expression.Call(instance, Method, _args.ToArray())
                ;

            return m;
        }

        /// <summary>
        /// Return an expression from the method
        /// </summary>
        /// <param name="argumentContext"></param>
        /// <returns></returns>
        public (ParameterExpression, Expression) GetembeddedCallAction(Expression instance, Expression parameters, Expression[] arguments)
        {

            MethodCallExpression m = GetCallMethod(instance, arguments);
            MethodCallExpression m2 = EmbedLog(arguments, m, parameters);

            var variableResult = Expression.Variable(typeof(object), "result");
            TryExpression _try = EmbedTryCatch(arguments, variableResult, m2, parameters);

            return (variableResult, _try);

        }

        private TryExpression EmbedTryCatch(Expression[] arguments, ParameterExpression variableResult, MethodCallExpression m2, Expression parameters)
        {

            var exceptionVariable = Expression.Variable(typeof(Exception), "e");
            List<Expression> _args3 = new List<Expression>(arguments.Length + 2) { Expression.Constant(RuleName), exceptionVariable };
            _args3.Add(parameters);
            MethodInfo method3 = typeof(BusinessAction<TContext>).GetMethod("LogError", BindingFlags.Static | BindingFlags.Public);

            BlockExpression block = Expression.Block(
                typeof(void),
                new ParameterExpression[] { },
                new Expression[] {
                    Expression.Call(method3, _args3),
                    Expression.Throw(exceptionVariable)
                }
                );
            var c = Expression.Catch(exceptionVariable, block);
            var blk2 = Expression.Block(typeof(void), new ParameterExpression[] { }, new Expression[] { Expression.Assign(variableResult, m2) });
            var _try = Expression.TryCatch(blk2, c);
            return _try;
        }

        private MethodCallExpression EmbedLog(Expression[] arguments, MethodCallExpression m, Expression parameters)
        {

            // Build log method
            List<Expression> _parameterLogResultArgument = new List<Expression>(arguments.Length + 2) { Expression.Constant(RuleName)};

            if (m.Type.IsValueType)
                _parameterLogResultArgument.Add(m.SmartConvert(typeof(object)));
            else
                _parameterLogResultArgument.Add(m);

            List<Expression> _args4 = new List<Expression>(arguments.Length);
            _parameterLogResultArgument.Add(parameters);
            MethodInfo method2 = typeof(BusinessAction<TContext>).GetMethod("LogResult", BindingFlags.Static | BindingFlags.Public);
            var m2 = Expression.Call(method2, _parameterLogResultArgument.ToArray()); // Business Method with log

            return m2;

        }

        /// <summary>
        /// Attention on y fait bien référence par reflexion dans la methode précédente.
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="result"></param>
        /// <param name="context"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static void LogError(string ruleName, Exception e, string[] arguments)
        {
            Trace.WriteLine(new
            {
                ActionName = ruleName,
                Arguments = string.Join(", ", arguments),
                Exception = e,
            }, TraceLevel.Error.ToString());
        }

        /// <summary>
        /// Attention on y fait bien référence par reflexion dans la methode précédente.
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="result"></param>
        /// <param name="context"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static object LogResult(string ruleName, object result, string[] arguments)
        {
            var r = result;
            Trace.WriteLine(new
            {
                ActionName = ruleName,
                Arguments = string.Join(", ", arguments),
                Result = result,
            }, TraceLevel.Info.ToString());

            return result;
        }


        private static List<Expression> TranslateArguments(Expression[] arguments, ParameterInfo[] parameters)
        {
            List<Expression> _args = new List<Expression>(arguments.Length);
            for (int i = 0; i < arguments.Length; i++)
            {

                var argument = arguments[i];
                if (parameters.Length > i)
                {

                    var parameter = parameters[i];

                    if (argument.Type != parameter.ParameterType)
                        argument = argument.SmartConvert(parameter.ParameterType);

                    _args.Add(argument);
                }
                else
                    break;

            }

            return _args;
        }


        ///// <summary>
        ///// Return an expression from the method
        ///// </summary>
        ///// <param name="argumentContext"></param>
        ///// <returns></returns>
        //public Expression GetLoadDatasAction(params Expression[] arguments)
        //{

        //    // build custom method
        //    List<Expression> _args = new List<Expression>(arguments.Length);
        //    var parameters = Method.GetParameters();

        //    for (int i = 0; i < arguments.Length; i++)
        //    {
        //        var argument = arguments[i];
        //        var parameter = parameters[i];

        //        if (argument.Type != parameter.ParameterType)
        //        {

        //            if (argument is ConstantExpression c)
        //                argument = Expression.Constant(Convert.ChangeType(c.Value, parameter.ParameterType));

        //            else
        //            {
        //                if (System.Diagnostics.Debugger.IsAttached)
        //                    System.Diagnostics.Debugger.Break();
        //                argument = Expression.Convert(argument, parameter.ParameterType);
        //            }

        //        }
        //        _args.Add(argument);
        //    }

        //    var m = Expression.Call(Method, _args.ToArray());


        //    //// Build log method
        //    //List<Expression> _args2 = new List<Expression>(arguments.Length + 2);
        //    //_args2.Add(Expression.Constant(this.RuleName));
        //    //_args2.Add(m);

        //    //List<string> _args3 = new List<string>(4);

        //    //for (int i = 0; i < arguments.Length; i++)
        //    //{
        //    //    var argument = arguments[i];

        //    //    if (argument.Type == typeof(TContext))
        //    //        _args2.Add(argument);

        //    //    else if (argument is ConstantExpression c)
        //    //        _args3.Add(c.Value.ToString());

        //    //    else
        //    //    {
        //    //        if (System.Diagnostics.Debugger.IsAttached)
        //    //            System.Diagnostics.Debugger.Break();
        //    //    }

        //    //}

        //    //_args2.Add(Expression.Constant(_args3.ToArray()));

        //    //MethodInfo method2 = typeof(BusinessAction<TContext>).GetMethod("LogResult", BindingFlags.Static | BindingFlags.Public);

        //    //var m2 = Expression.Call(method2, _args2.ToArray());


        //    return m;

        //}

        public string Context { get; internal set; }

        public MethodInfo Method { get; internal set; }

        public string RuleName { get; internal set; }

        public Type Type { get; internal set; }

        public string Origin { get; internal set; }
        public string Name { get; internal set; }
    }

}