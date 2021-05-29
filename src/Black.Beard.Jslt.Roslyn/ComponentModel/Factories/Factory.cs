using System;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    public abstract class Factory
    {

        public Factory(MethodBase method, ParameterInfo[] paramsInfo, MethodDescription description)
        {
            this.MethodSource = method;
            IsStatic = method.IsStatic;
            IsCtor = method is ConstructorInfo;
            this.Parameters = paramsInfo;
            this.MethodInfos = description;

        }

        public MethodBase MethodSource { get; }

        public ParameterInfo[] MethodParameters { get; protected set; }

        public bool IsStatic { get; }

        public bool IsCtor { get; }

        public Type[] Types { get; protected set; }

        public ParameterInfo[] Parameters { get; }

        public MethodInfo Method { get; internal set; }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        //public abstract object Create(params dynamic[] args);

        public abstract bool IsEmpty { get; }

        public MethodDescription MethodInfos { get; }

    }

    /// <summary>
    /// Factory of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T> : Factory //: IFactory<T> 
        where T : class
    {

        public Factory(ObjectActivator<T> objectActivator, MethodBase methodSource, ParameterInfo[] paramsInfo, MethodDescription description)
          : base(methodSource, paramsInfo, description)
        {
            this._delegate = objectActivator;
            base.Method = typeof(Factory<T>).GetMethod(nameof(Call));
            base.MethodParameters = methodSource.GetParameters();
            Types = this.MethodParameters.Select(c => c.ParameterType).ToArray();
        }


        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public T Call(params dynamic[] args)
        {
            return _delegate(args);
        }

        public override bool IsEmpty => _delegate == null;

        private ObjectActivator<T> _delegate { get; }
        

    }
}
