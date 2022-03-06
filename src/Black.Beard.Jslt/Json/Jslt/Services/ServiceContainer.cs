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
            ServiceContainer.Common = service;
            service.ServiceDiscovery.AddAssembly(typeof(TranformJsonAstConfiguration).Assembly);
        }

        private ServiceContainer()
        {

            this._dictionary = new Dictionary<string, TransformJsonServiceProvider>();
            this._dictionaryOutput = new Dictionary<string, TransformJsonServiceProvider>();
            this.ServiceDiscovery = new ServiceDiscovery(this);
        }

        public ServiceContainer AddService(string name, Factory provider, bool forOutput)
        {

            TransformJsonServiceProvider serviceProvider;

            if (forOutput)
            {
                if (!_dictionaryOutput.TryGetValue(name.ToLower(), out serviceProvider))
                    this._dictionaryOutput.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));
            }
            else
            {
                if (!_dictionary.TryGetValue(name.ToLower(), out serviceProvider))
                    this._dictionary.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));
            }

            provider.Name = name;
            serviceProvider.Add(provider);
            
            System.Diagnostics.Debug.WriteLine($"service {name} is added");

            return this;

        }

        public Factory GetOutputService(string name, Type[] parameters)
        {

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetOutputService(name, parameters);

            if (_dictionaryOutput.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.GetForOutput(parameters);

            return null;

        }


        public Factory GetService(string name, Type[] parameters)
        {

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetService(name, parameters);

            if (_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get(parameters);

            return null;

        }

        public TransformJsonServiceProvider GetService(string name)
        {

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetService(name);

            if (_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider;

            return null;

        }


        public TransformJsonServiceProvider GetOutputService(string name)
        {

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetOutputService(name);

            if (_dictionaryOutput.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider;

            return null;

        }

        public IEnumerable<TransformJsonServiceProvider> GetOutputServices()
        {

            if (ServiceContainer.Common != this)
                foreach (var item in ServiceContainer.Common.GetOutputServices())
                    yield return item;

            foreach (var item in _dictionaryOutput.Values)
                yield return item;

        }

        public IEnumerable<TransformJsonServiceProvider> GetServices()
        {

            if (ServiceContainer.Common != this)
                foreach (var item in ServiceContainer.Common.GetServices())
                    yield return item;

            foreach (var item in _dictionary.Values)
                yield return item;

        }

        public ServiceDiscovery ServiceDiscovery { get; }

        public static ServiceContainer Common { get; }

        private readonly Dictionary<string, TransformJsonServiceProvider> _dictionary;
        private readonly Dictionary<string, TransformJsonServiceProvider> _dictionaryOutput;


    }

}
