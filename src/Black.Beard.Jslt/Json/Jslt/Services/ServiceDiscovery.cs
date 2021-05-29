using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{


    public partial class ServiceDiscovery
    {

        public ServiceDiscovery(ServiceContainer parent)
        {
            this.ServiceContainer = parent;
            this._assemblies = new HashSet<string>();
        }

        public void AddAssembly(Assembly assembly)
        {

            string assemblyName = assembly.FullName;
            if (!_assemblies.Contains(assemblyName))
                lock (_lock)
                    if (!_assemblies.Contains(assemblyName))
                    {

                        var types = (assembly.GetTypes().Where(c => c.IsPublic)).ToList();
                        foreach (var type in types)
                        {

                            if (typeof(ITransformJsonService).IsAssignableFrom(type) && type.GetCustomAttribute<JsltExtensionMethodAttribute>() != null)
                                AddService(type, null);

                            else
                            {

                                var methods = MethodDiscovery.GetMethods(type, BindingFlags.Public | BindingFlags.Static, typeof(JToken)).ToList();
                                foreach (var method in methods)
                                {
                                    var attribute = method.GetCustomAttribute<JsltExtensionMethodAttribute>();
                                    if (attribute != null)
                                    {
                                        var parameters = method.GetParameters();
                                        if (parameters.Length >= 1 && parameters[0].ParameterType == typeof(RuntimeContext))
                                            AddService(method, attribute.Name);
                                    }
                                }

                            }

                        }

                        _assemblies.Add(assemblyName);

                    }
        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="Bb.Json.Attributes.JsltExtensionMethodAttribute" /> for identify the key to match.
        /// The type of service must implemente <see cref="Bb.TransformJson.ITransformJsonService" />
        /// </summary>
        /// <param name="service"></param>
        /// <returns>return the current instance of <see cref="TranformJsonAstConfiguration"/> for using in fluence code.</returns>
        public void AddService(Type service, string name = null)
        {

            string _description = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                var n = JsltExtensionMethodAttribute.GetAttribute(service);
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;
                _description = n.Description;
            }

            var ctors = service.GetConstructors();
            foreach (var ctor in ctors)
            {

                MethodDescription description = JsltExtensionMethodParameterAttribute.Map(new MethodDescription(name, ctor) { Description = _description });
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor, description);
                ServiceContainer.AddService(name, factory);
            }

        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="Bb.Json.Attributes.JsltExtensionMethodAttribute" /> for identify the key to match.
        /// </summary>
        /// <param name="service"></param>
        /// <returns>return the current instance of <see cref="TranformJsonAstConfiguration"/> for using in fluence code.</returns>
        public void AddService(MethodInfo service, string name = null)
        {

            string _description = string.Empty;
            if (string.IsNullOrEmpty(name))
            {

                var n = JsltExtensionMethodAttribute.GetAttribute(service);
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;
                _description = n.Description;

            }

            MethodDescription description = JsltExtensionMethodParameterAttribute.Map(new MethodDescription(name, service) { Description = _description });
            Factory<JToken> factory = ObjectCreator.GetActivator<JToken>(service, description);
            ServiceContainer.AddService(name, factory);

        }

        public ServiceContainer ServiceContainer { get; }


        internal HashSet<string> _assemblies;

        private volatile object _lock = new object();
    }



}
