using Bb.Analysis;
using Bb.Analysis.Traces;
using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{

    /// <summary>
    /// Discovers services in assemblies
    /// </summary>
    public class ServiceFunctionFoundry
    {

        /// <summary>
        /// Create a new instance of FunctionFoundry
        /// </summary>
        /// <param name="configuration"></param>
        public ServiceFunctionFoundry(TranformJsonAstConfiguration configuration)
        {
            this.configuration = configuration;
            this.Services = this.configuration.Services; 

            foreach (Assembly assembly in configuration.Assemblies)
                this.Services.ServiceDiscovery.AddAssembly(assembly);

        }


        internal Factory GetService(FunctionKindEnum kind, string name, Type[] types, ScriptDiagnostics diagnostics, TextLocation location)
        {

            var result = this.Services.GetService(kind, name, types);
            if (result != null)
                return result;

            result = this.configuration.Services.GetService(kind, name, types);
            if (result != null)
                return result;

            var result2 = this.Services.GetService(kind, name);
            if (result2 != null)
                diagnostics.AddError(location, name, $"Service {name} exists but bad arguments calling");

            else
            {
                result2 = this.configuration.Services.GetService(kind, name);
                if (result2 != null)
                    diagnostics.AddError(location, name, $"Service {name} exists but bad arguments calling");

                else
                    diagnostics.AddError(location, name, $"Service {name} not found");

            }

            return null;

        }


        /// <summary>
        /// Discovers services in assembly specified by name
        /// </summary>
        /// <param name="assemblyFilename"></param>
        /// <returns></returns>
        internal Assembly AddAssembly(string assemblyFilename)
        {
            Assembly assembly = TypeDiscovery.Instance.AddAssemblyFile(assemblyFilename, System.Diagnostics.Debugger.IsAttached);
            AddAssembly(assembly);
            return assembly;
        }

        /// <summary>
        /// Discovers services in assembly specified by name
        /// </summary>
        /// <param name="assemblyname"></param>
        /// <returns></returns>
        internal Assembly AddAssemblyName(string assemblyname)
        {
            Assembly assembly = TypeDiscovery.Instance.AddAssemblyname(assemblyname, true);
            AddAssembly(assembly);
            return assembly;

        }

        /// <summary>
        /// Discovers services in specified assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public Assembly AddAssembly(Assembly assembly)
        {
            
            var types = TypeDiscovery.Instance.GetTypesWithAttributes<JsltExtensionMethodAttribute>(typeof(ITransformJsonService), c => true)
            .Where(c => c.Assembly == assembly);

            foreach (var item in types)
                AddService(item, null);

            return assembly;
        }

        /// <summary>
        /// Add service
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceFunctionFoundry AddService(Type service, string name = null)
        {

            string _description = string.Empty;
            FunctionKindEnum _kind = FunctionKindEnum.FunctionStandard;

            if (string.IsNullOrEmpty(name))
            {
                var n = JsltExtensionMethodAttribute.GetAttribute(service);
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;
                _description = n.Description;
                _kind = n.ForOutput;

            }

            var ctors = service.GetConstructors();
            foreach (var ctor in ctors)
            {

                MethodDescription description = JsltExtensionMethodParameterAttribute.Map( new MethodDescription(name, ctor) { Description = _description });
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor, description);
                Services.AddService(name, factory, _kind);
            }

            return this;
        }


        private TranformJsonAstConfiguration configuration;
        private ServiceContainer Services;

    }
}