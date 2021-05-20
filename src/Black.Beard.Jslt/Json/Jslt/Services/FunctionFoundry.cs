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
            this.Services = new ServiceContainer();
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

        internal void AddAssembly(string assemblyFilename)
        {
            Assembly assembly = TypeDiscovery.Instance.AddAssemblyFile(assemblyFilename, System.Diagnostics.Debugger.IsAttached);
            AddAssembly(assembly);
        }

        internal void AddAssembly(Assembly assembly)
        {
            var types = TypeDiscovery.Instance.GetTypesWithAttributes<JsltExtensionMethodAttribute>(typeof(ITransformJsonService), c => true);
            foreach (var item in types)
                AddService(item, null);
        }

        public FunctionFoundry AddService(Type service, string name = null)
        {

            if (string.IsNullOrEmpty(name))
            {
                var n = service.GetCustomAttributes(typeof(JsltExtensionMethodAttribute), true).OfType<JsltExtensionMethodAttribute>().FirstOrDefault();
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(JsltExtensionMethodAttribute)} ");

                name = n.Name;

            }

            var ctors = service.GetConstructors();
            foreach (var ctor in ctors)
            {
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor);
                Services.AddService(name, factory);
            }

            return this;
        }

    }
}