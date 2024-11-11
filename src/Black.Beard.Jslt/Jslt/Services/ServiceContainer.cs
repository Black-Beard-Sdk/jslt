using Bb.Attributes;
using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.Jslt.Services
{

    /// <summary>
    /// Manage the storage of the services registered
    /// </summary>
    public class ServiceContainer
    {


        /// <summary>
        /// static constructor
        /// </summary>
        static ServiceContainer()
        {
            var service = new ServiceContainer();
            ServiceContainer.Instance = service;
            service.ServiceDiscovery.AddAssembly(typeof(TranformJsonAstConfiguration).Assembly);
        }

        /// <summary>
        /// private creation
        /// </summary>
        public ServiceContainer()
        {

            this._dic = new Dictionary<FunctionKindEnum, Dictionary<string, TransformJsonServiceProvider>>
            {
                { FunctionKindEnum.FunctionStandard, new Dictionary<string, TransformJsonServiceProvider>() },
                { FunctionKindEnum.Output, new Dictionary<string, TransformJsonServiceProvider>() },
                { FunctionKindEnum.Writer, new Dictionary<string, TransformJsonServiceProvider>() }
            };

            this.ServiceDiscovery = new ServiceDiscovery(this);

        }

        /// <summary>
        /// add a new assembly to the service container
        /// </summary>
        /// <param name="assembly"></param>
        public static void AddAssembly(Assembly assembly)
        {
            ServiceContainer.Instance.ServiceDiscovery.AddAssembly(assembly);
        }

        /// <summary>
        /// add a new service, the name is the key for finding the service
        /// </summary>
        /// <param name="name">name for matching service</param>
        /// <param name="provider"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public ServiceContainer AddService(string name, Factory provider, FunctionKindEnum kind)
        {

            TransformJsonServiceProvider serviceProvider = null;

            Dictionary<string, TransformJsonServiceProvider> dic = null;

            dic = this._dic[kind];

            if (dic != null)
            {

                if (!dic.TryGetValue(name.ToLower(), out serviceProvider))
                    dic.Add(name.ToLower(), (serviceProvider = new TransformJsonServiceProvider()));

                provider.Name = name;
                serviceProvider.Add(provider);
                System.Diagnostics.Debug.WriteLine($"service {name} is added");

            }

            return this;

        }

        /// <summary>
        /// resolve factory for the service matched by the name
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public TransformJsonServiceProvider GetService(FunctionKindEnum kind, string name)
        {

            //if (ServiceContainer.Instance != this)
            //    return ServiceContainer.Instance.GetService(FunctionKindEnum.FunctionStandard, name);

            var d = _dic[kind];

            if (d.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider;

            return null;

        }

        /// <summary>
        /// resolve factory for the service matched by the name and the arguments
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Factory GetService(FunctionKindEnum kind, string name, Type[] parameters, RuleMatching[] ruleMatchings)
        {

            var d = _dic[kind];

            List<Type> sign = new List<Type> { typeof(RuntimeContext) }; // add the runtime context as first parameter because it's alway the first parameter of all services
            sign.AddRange(parameters);

            //if (ServiceContainer.Instance != this)
            //    return ServiceContainer.Instance.GetService(kind, name, parameters);

            if (d.TryGetValue(name.ToLower(), out TransformJsonServiceProvider serviceProvider))
                return serviceProvider.Get_Impl(sign.ToArray(), ruleMatchings);

            return null;

        }

        public IEnumerable<TransformJsonServiceProvider> GetServices(FunctionKindEnum kind)
        {

            var d = _dic[kind];

            //if (ServiceContainer.Instance != this)
            //    foreach (var item in ServiceContainer.Instance.GetServices(kind))
            //        yield return item;

            foreach (var item in d.Values)
                yield return item;

        }

        public ServiceDiscovery ServiceDiscovery { get; }

        public static ServiceContainer Instance { get; }

        private readonly Dictionary<FunctionKindEnum, Dictionary<string, TransformJsonServiceProvider>> _dic;


    }

}
