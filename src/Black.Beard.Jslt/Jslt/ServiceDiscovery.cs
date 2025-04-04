﻿using Bb.Attributes;
using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Contracts;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Jslt
{


    public partial class ServiceDiscovery
    {

        public ServiceDiscovery(ServiceContainer parent)
        {
            ServiceContainer = parent;
            _assemblies = new HashSet<string>();
        }

        /// <summary>
        /// explore the assembly and add services in the configuration container. the type must to have an attribute <see cref="JsltExtensionMethodAttribute" /> for identify the key to match.
        /// </summary>
        /// <param name="assembly"></param>
        public void AddAssembly(Assembly assembly)
        {

            string assemblyName = assembly.FullName;
            if (!_assemblies.Contains(assemblyName))
                lock (_lock)
                    if (!_assemblies.Contains(assemblyName))
                    {

                        _assemblies.Add(assemblyName);

                        var types = assembly.GetTypes().Where(c => c.IsPublic).ToList();
                        foreach (var type in types)
                        {

                            if (typeof(ITransformJsonService).IsAssignableFrom(type) && type.GetCustomAttribute<JsltExtensionMethodAttribute>() != null)
                                AddService(type, null);

                            else
                            {

                                var methods = MethodDiscovery.GetMethods(type, BindingFlags.Public | BindingFlags.Static, null).Where(c =>
                                {
                                    var parameters = c.GetParameters();
                                    return parameters.Length >= 1 && parameters[0].ParameterType == typeof(RuntimeContext);
                                }).ToList();

                                if (methods.Any())
                                    Append(methods);

                                //methods = MethodDiscovery.GetMethods(type, BindingFlags.Public | BindingFlags.Static, typeof(StringBuilder)).ToList();
                                //if (methods.Any())
                                //    Append(methods);

                            }

                        }
                    }

        }

        private void Append(List<MethodInfo> methods)
        {
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<JsltExtensionMethodAttribute>();
                if (attribute != null)
                    AddService(method, attribute.Name, attribute.ForOutput);
            }
        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="JsltExtensionMethodAttribute" /> for identify the key to match.
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
                MethodDescription description = JsltExtensionMethodParameterAttribute.Map(new MethodDescription(name, ctor, service) { Description = _description });
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor, description);
                ServiceContainer.AddService(name, factory, FunctionKindEnum.FunctionStandard);
            }

        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="JsltExtensionMethodAttribute" /> for identify the key to match.
        /// </summary>
        /// <param name="service"></param>
        /// <returns>return the current instance of <see cref="TranformJsonAstConfiguration"/> for using in fluence code.</returns>
        public void AddService(MethodInfo service, string name = null, FunctionKindEnum forOutput = FunctionKindEnum.FunctionStandard)
        {

            string _description = string.Empty;
            FunctionKindEnum _forOutput = forOutput;

            if (string.IsNullOrEmpty(name))
            {

                var n = JsltExtensionMethodAttribute.GetAttribute(service);
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;
                _forOutput = n.ForOutput;
                _description = n.Description;

            }

            MethodDescription description = JsltExtensionMethodParameterAttribute.Map(new MethodDescription(name, service, service.ReturnType) { Description = _description });
            Factory factory = null;

            switch (_forOutput)
            {

                case FunctionKindEnum.Output:
                    factory = ObjectCreator.GetCallMethod<StringBuilder>(service, description);
                    break;

                case FunctionKindEnum.Writer:
                    factory = ObjectCreator.GetCallMethod<object>(service, description);
                    break;

                case FunctionKindEnum.FunctionStandard:
                    factory = ObjectCreator.GetCallMethod<JToken>(service, description);
                    break;

                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    break;

            }


            ServiceContainer.AddService(name, factory, _forOutput);

        }
        public ServiceContainer ServiceContainer { get; }

        internal HashSet<string> _assemblies;
        private volatile object _lock = new object();

    }



}
