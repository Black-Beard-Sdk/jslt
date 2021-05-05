using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Services
{
    public class ServiceContainer
    {

        public ServiceContainer()
        {
            this._dictionary = new Dictionary<string, Func<ITransformJsonService>>();
        }

        public ServiceContainer AddService(string typeName, Func<ITransformJsonService> provider)
        {
            this._dictionary.Add(typeName.ToLower(), provider);
            return this;
        }

        public TransformJsonServiceProvider GetService(string type)
        {

            if (_dictionary.TryGetValue(type.ToLower(), out Func<ITransformJsonService> serviceProvider))
                return new TransformJsonServiceProvider(serviceProvider);

            return null;

        }

        private readonly Dictionary<string, Func<ITransformJsonService>> _dictionary;

    }

}
