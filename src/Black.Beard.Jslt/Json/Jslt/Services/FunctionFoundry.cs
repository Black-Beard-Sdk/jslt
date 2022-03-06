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

    public class FunctionFoundry
    {

        public FunctionFoundry(TranformJsonAstConfiguration configuration)
        {
            this.configuration = configuration;
            this.Services = this.configuration.Services; 

            foreach (Assembly assembly in configuration.Assemblies)
                ServiceContainer.Common.ServiceDiscovery.AddAssembly(assembly);
        }

       

        internal Factory GetServiceOutput(string name, Type[] types, Diagnostics diagnostics, TokenLocation location)
        {

            var result = this.Services.GetOutputService(name, types);
            if (result != null)
                return result;

            result = this.configuration.Services.GetOutputService(name, types);
            if (result != null)
                return result;

            var result2 = this.Services.GetOutputService(name);
            if (result2 != null)
                diagnostics.AddError(null, location, name, $"Service {name} exists but bad arguments calling");

            else
            {
                result2 = this.configuration.Services.GetOutputService(name);
                if (result2 != null)
                    diagnostics.AddError(null, location, name, $"Service {name} exists but bad arguments calling");

                else
                    diagnostics.AddError(null, location, name, $"Service {name} not found");

            }

            return null;

        }

        internal Factory GetService(string name, Type[] types, Diagnostics diagnostics, TokenLocation location)
        {

            var result = this.Services.GetService(name, types);
            if (result != null)
                return result;

            result = this.configuration.Services.GetService(name, types);
            if (result != null)
                return result;

            var result2 = this.Services.GetService(name);
            if (result2 != null)
                diagnostics.AddError(null, location, name, $"Service {name} exists but bad arguments calling");

            else
            {
                result2 = this.configuration.Services.GetService(name);
                if (result2 != null)
                    diagnostics.AddError(null, location, name, $"Service {name} exists but bad arguments calling");

                else
                    diagnostics.AddError(null, location, name, $"Service {name} not found");

            }

            return null;

        }

        private TranformJsonAstConfiguration configuration;
        private ServiceContainer Services;

        internal Assembly AddAssembly(string assemblyFilename)
        {
            Assembly assembly = TypeDiscovery.Instance.AddAssemblyFile(assemblyFilename, System.Diagnostics.Debugger.IsAttached);
            AddAssembly(assembly);
            return assembly;
        }

        internal Assembly AddAssemblyName(string assemblyname)
        {
            Assembly assembly = TypeDiscovery.Instance.AddAssemblyname(assemblyname);
            AddAssembly(assembly);
            return assembly;

        }
        
        public Assembly AddAssembly(Assembly assembly)
        {
            
            var types = TypeDiscovery.Instance.GetTypesWithAttributes<JsltExtensionMethodAttribute>(typeof(ITransformJsonService), c => true)
            .Where(c => c.Assembly == assembly);

            foreach (var item in types)
                AddService(item, null);

            return assembly;
        }

        public FunctionFoundry AddService(Type service, string name = null)
        {

            string _description = string.Empty;
            bool _forOutput = false;

            if (string.IsNullOrEmpty(name))
            {
                var n = JsltExtensionMethodAttribute.GetAttribute(service);
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;
                _description = n.Description;
                _forOutput = n.ForOutput;

            }

            var ctors = service.GetConstructors();
            foreach (var ctor in ctors)
            {

                MethodDescription description = JsltExtensionMethodParameterAttribute.Map( new MethodDescription(name, ctor) { Description = _description });
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor, description);
                Services.AddService(name, factory, _forOutput);
            }

            return this;
        }

    }
}