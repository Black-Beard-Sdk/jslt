using System;
using System.Collections.Generic;
using static Bb.Json.Jslt.Services.TranformJsonAstConfiguration;

namespace Bb.Json.Jslt.Services
{
    public class ServiceContainer
    {

        public ServiceContainer()
        {
            this._dictionary = new Dictionary<string, TransformJsonServiceProvider>();
        }

        public ServiceContainer AddService(string name, Factory<ITransformJsonService> provider)
        {

            if (!_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                this._dictionary.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));

            serviceProvider.Add(provider);

            return this;
        }

        public Factory<ITransformJsonService> GetService(string name, Type[] parameters)
        {

            if (_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get(parameters);

            return null;

        }

        private readonly Dictionary<string, TransformJsonServiceProvider> _dictionary;

    }

}
