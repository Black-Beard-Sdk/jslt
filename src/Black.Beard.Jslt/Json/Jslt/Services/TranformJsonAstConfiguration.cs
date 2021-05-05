using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{
    public class TranformJsonAstConfiguration
    {

        public TranformJsonAstConfiguration()
        {

            this.Services = new ServiceContainer();

            //this.AddService(typeof(ServiceAdd))
            //    .AddService(typeof(ServiceConcat))
            //    .AddService(typeof(ServiceConcatAll))
            //    .AddService(typeof(ServiceCrc32))
            //    .AddService(typeof(ServiceDistinct))
            //    .AddService(typeof(ServiceNotNull))
            //    .AddService(typeof(ServiceDiv))
            //    .AddService(typeof(ServiceFrombase64))
            //    .AddService(typeof(ServiceModulo))
            //    .AddService(typeof(ServiceSha256))
            //    .AddService(typeof(ServiceSha512))
            //    .AddService(typeof(ServiceSubStr))
            //    .AddService(typeof(ServiceUniquekey))
            //    .AddService(typeof(ServiceSubstract))
            //    .AddService(typeof(ServiceSum))
            //    .AddService(typeof(ServiceTime))
            //    .AddService(typeof(ServiceTobase64))

                ;

        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="System.ComponentModel.DisplayNameAttribute" /> for identify the key to match.
        /// The type of service must implemente <see cref="Bb.TransformJson.ITransformJsonService" />
        /// </summary>
        /// <param name="service"></param>
        /// <returns>return the current instance of <see cref="TranformJsonAstConfiguration"/> for using in fluence code.</returns>
        public TranformJsonAstConfiguration AddService(Type service)
        {

            var name = service.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
            if (name == null)
                throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(DisplayNameAttribute)} ");

            var ctor = service.GetConstructor(new Type[] { });
            var factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor);

            Services.AddService(name.DisplayName, () => factory());

            return this;
        }

        public TranformJsonAstConfiguration AddService(string typeName, Func<ITransformJsonService> provider)
        {
            Services.AddService(typeName, provider);
            return this;
        }

        public TranformJsonAstConfiguration AddService<T>(string typeName, T provider)
            where T : ITransformJsonService
        {
            Services.AddService(typeName, () => provider);
            return this;
        }


        public ServiceContainer Services { get; }


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
        private static class ObjectCreator
        {

            /// <summary>
            /// Gets an customed activator factory for the specified ctor.
            /// Note if the the generic is diferent of the declaring type of the ctor a cast is injected in the method.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="ctor">The ctor.</param>
            /// <returns></returns>
            public static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
            {

                Type type = ctor.DeclaringType;
                ParameterInfo[] paramsInfo = ctor.GetParameters();

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

                //make a NewExpression that calls the ctor with the args we just created
                Expression newExp = Expression.New(ctor, argsExp);

                if (ctor.DeclaringType != typeof(T))
                    newExp = Expression.Convert(newExp, typeof(T));

                //create a lambda with the New expression as body and our param object[] as arg
                LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

                //compile it
                ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();

                return compiled;

            }
        }

    }

}
