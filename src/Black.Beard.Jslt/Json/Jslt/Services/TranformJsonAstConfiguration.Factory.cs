using System.Reflection;

namespace Bb.Json.Jslt.Services
{


    public abstract class Factory
    {

        public Factory(ConstructorInfo ctor, ParameterInfo[] paramsInfo)
        {
            this.Constructor = ctor;
            this.Parameters = paramsInfo;
        }

        public ConstructorInfo Constructor { get; }

        public ParameterInfo[] Parameters { get; }

        public MethodInfo Method { get; internal set; }
    }

    public class Factory<T> : Factory
    {

        public Factory(ObjectActivator<T> objectActivator, ConstructorInfo ctor, ParameterInfo[] paramsInfo)
            : base(ctor, paramsInfo)
        {
            this._creator = objectActivator;
            base.Method = typeof(Factory<T>).GetMethod(nameof(Get));
        }


        public T Get(params object[] args)
        {
            return _creator(args);
        }

        private ObjectActivator<T> _creator { get; }

    }





}
