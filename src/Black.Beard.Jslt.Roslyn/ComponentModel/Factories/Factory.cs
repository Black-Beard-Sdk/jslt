using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    [System.Diagnostics.DebuggerDisplay("{Name}")]
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

        public MethodInfo MethodCall { get; internal set; }

        public MethodInfo MethodReset { get; internal set; }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        //public abstract object Create(params dynamic[] args);

        public abstract bool IsEmpty { get; }

        public MethodDescription MethodInfos { get; }

        public string Name { get; set; }
    }

    /// <summary>
    /// Factory of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T> : Factory //: IFactory<T> 
        where T : class
    {
        private readonly Dictionary<string, T> _dic;

        public Factory(ObjectActivator<T> objectActivator, MethodBase methodSource, ParameterInfo[] paramsInfo, MethodDescription description)
          : base(methodSource, paramsInfo, description)
        {
            this._delegate = objectActivator;
            base.MethodCall = typeof(Factory<T>).GetMethod(nameof(Call));
            base.MethodReset = typeof(Factory<T>).GetMethod(nameof(Reset));
            base.MethodParameters = methodSource.GetParameters();
            Types = this.MethodParameters.Select(c => c.ParameterType).ToArray();
            this._dic = new Dictionary<string, T>();
        }


        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public T Call(string key, params dynamic[] args)
        {

            if (this.IsCtor && args.Length == 0)
            {

                if (!this._dic.TryGetValue(key, out T result))
                    this._dic.Add(key, (result = _delegate(args)));

                return result;

            }

            return _delegate(args);

        }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public void Reset()
        {
            this._dic.Clear();
        }

        public override bool IsEmpty => _delegate == null;

        private ObjectActivator<T> _delegate { get; }


    }
}
