using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
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
            this._dictionaryWriter = new Dictionary<string, TransformJsonServiceProvider>();
            
            this.ServiceDiscovery = new ServiceDiscovery(this);

        }

        public ServiceContainer AddService(string name, Factory provider, FunctionKindEnum kind)
        {

            TransformJsonServiceProvider serviceProvider = null;
            switch (kind)
            {

                case FunctionKindEnum.Output:
                    if (!_dictionaryOutput.TryGetValue(name.ToLower(), out serviceProvider))
                        this._dictionaryOutput.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));
                    break;

                case FunctionKindEnum.FunctionStandard:
                    if (!_dictionary.TryGetValue(name.ToLower(), out serviceProvider))
                        this._dictionary.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));
                    break;

                case FunctionKindEnum.Writer:
                    if (!_dictionaryWriter.TryGetValue(name.ToLower(), out serviceProvider))
                        this._dictionaryWriter.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));
                    break;

                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    break;

            }

            if (serviceProvider != null)
            {
                provider.Name = name;
                serviceProvider.Add(provider);
                System.Diagnostics.Debug.WriteLine($"service {name} is added");
            }

            return this;

        }


        public Factory GetWriterService(string name, Type[] parameters)
        {

            List<Type> sign = new List<Type> { typeof(RuntimeContext) };
            sign.AddRange(parameters);

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetWriterService(name, parameters);

            if (_dictionaryWriter.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get_Impl(sign.ToArray());

            return null;

        }
      

        public Factory GetOutputService(string name, Type[] parameters)
        {

            List<Type> sign = new List<Type> { typeof(RuntimeContext) };
            sign.AddRange(parameters);

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetOutputService(name, parameters);

            if (_dictionaryOutput.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get_Impl(sign.ToArray());

            return null;

        }

        public Factory GetService(string name, Type[] parameters)
        {

            List<Type> sign = new List<Type> { typeof(RuntimeContext) };
            sign.AddRange(parameters);

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetService(name, parameters);

            if (_dictionary.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get_Impl(sign.ToArray());

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

        public TransformJsonServiceProvider GetWriterService(string name)
        {

            if (ServiceContainer.Common != this)
                return ServiceContainer.Common.GetWriterService(name);

            if (_dictionaryWriter.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
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

        public IEnumerable<TransformJsonServiceProvider> GetWriterServices()
        {

            if (ServiceContainer.Common != this)
                foreach (var item in ServiceContainer.Common.GetWriterServices())
                    yield return item;

            foreach (var item in _dictionaryWriter.Values)
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
        private readonly Dictionary<string, TransformJsonServiceProvider> _dictionaryWriter;


    }

}
