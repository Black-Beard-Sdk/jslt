using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using static Bb.Json.Jslt.Services.TranformJsonAstConfiguration;

namespace Bb.Json.Jslt.Services
{

    public class ServiceContainer
    {

        static ServiceContainer()
        {
            var service = new ServiceContainer();
            service.ServiceDiscovery.AddAssembly(typeof(TranformJsonAstConfiguration).Assembly);

            ServiceContainer.Common = service;
        }

        public ServiceContainer()
        {
            
            this._dictionary = new Dictionary<string, TransformJsonServiceProvider>();
            this.ServiceDiscovery = new ServiceDiscovery(this);

            if (ServiceContainer.Common != null)
                this.Replicate(ServiceContainer.Common);

        }

        private void Replicate(ServiceContainer common)
        {
            
            foreach (var item in common._dictionary)
                this._dictionary.Add(item.Key, item.Value);

            foreach (var item in common.ServiceDiscovery._assemblies)
                this.ServiceDiscovery._assemblies.Add(item);

        }

        public ServiceContainer AddService(string name, Factory provider)
        {

            if (!_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                this._dictionary.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));

            serviceProvider.Add(provider);

            return this;
        }

        public Factory GetService(string name, Type[] parameters)
        {

            if (_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get(parameters);

            return null;

        }

        public ServiceDiscovery ServiceDiscovery { get; }
        public static ServiceContainer Common { get; }

        private readonly Dictionary<string, TransformJsonServiceProvider> _dictionary;


    }

}
