using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{
    public class TransformJsonServiceProvider
    {

        static TransformJsonServiceProvider()
        {
            TransformJsonServiceProvider.Method = typeof(TransformJsonServiceProvider).GetMethod("Get", BindingFlags.Instance | BindingFlags.Public);
        }

        public TransformJsonServiceProvider(Func<ITransformJsonService> generator)
        {
            this._generator = generator;
        }

        public ITransformJsonService Get(int key)
        {

            if (!_instances.TryGetValue(key, out ITransformJsonService instance))
                lock (_lock)
                    if (!_instances.TryGetValue(key, out instance))
                        _instances.Add(key, instance = this._generator());

            return instance;

        }

        public static MethodInfo Method { get; private set; }

        private readonly Func<ITransformJsonService> _generator;
        private volatile object _lock = new object();
        private Dictionary<int, ITransformJsonService> _instances = new Dictionary<int, ITransformJsonService>();

    }

}
