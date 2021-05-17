using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
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

        internal Factory GetService(string name, Type[] types)
        {

            var result = this.Services.GetService(name, types);
            if (result != null)
                return result;

            result = this.configuration.Services.GetService(name, types);
            if (result != null)
                return result;

            throw new MissingMethodException(name);

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