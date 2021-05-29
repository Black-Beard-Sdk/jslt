using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    /// <summary>
    /// define a factory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    public delegate T ObjectActivator<T>(params object[] args);

    /// <summary>
    /// dynamic factory
    /// </summary>
    public static class ObjectCreator
    {

        ///// <summary>
        ///// Gets an customed activator factory for the specified ctor.
        ///// Note if the the generic is diferent of the declaring type of the ctor a cast is injected in the method.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="ctor">The ctor.</param>
        ///// <returns></returns>
        //public static Factory<T> GetActivator<T>(MethodBase ctor, MethodDescription description)
        //    where T : class
        //{

        //    Type type = ctor.DeclaringType;
        //    ParameterInfo[] paramsInfo = ctor.GetParameters();

        //    //create a single param of type object[]
        //    ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

        //    Expression[] argsExp = new Expression[paramsInfo.Length];

        //    //pick each arg from the params array and create a typed expression of them
        //    for (int i = 0; i < paramsInfo.Length; i++)
        //    {
        //        Expression index = Expression.Constant(i);
        //        Type paramType = paramsInfo[i].ParameterType;
        //        Expression paramAccessorExp = Expression.ArrayIndex(param, index);
        //        Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
        //        argsExp[i] = paramCastExp;
        //    }

        //    //make a NewExpression that calls the ctor with the args we just created
        //    Expression newExp = Expression.New((ConstructorInfo)ctor, argsExp);

        //    if (ctor.DeclaringType != typeof(T))
        //        newExp = Expression.Convert(newExp, typeof(T));

        //    //create a lambda with the New expression as body and our param object[] as arg
        //    LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

        //    //compile it
        //    ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();

        //    return new Factory<T>(compiled, ctor, paramsInfo, description);

        //}

        /// <summary>
        /// Gets an customed activator factory for the specified ctor.
        /// Note if the the generic is diferent of the declaring type of the ctor a cast is injected in the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static Factory<T> GetActivator<T>(MethodBase methodBase, MethodDescription description)
            where T : class
        {

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;
                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }

            Expression newExp;

            if (methodBase is ConstructorInfo c)
                newExp = Expression.New(c, argsExp);
            else
                newExp = Expression.Call(null, (MethodInfo)methodBase, argsExp);

            if (methodBase.DeclaringType != typeof(T))
                newExp = Expression.Convert(newExp, typeof(T));

            //create a lambda with the New expression as body and our param object[] as arg
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();

            return new Factory<T>(compiled, methodBase, paramsInfo, description);

        }

    }



}