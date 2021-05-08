using Bb.Json.Jslt.Parser;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Services
{
    internal class FunctionFoundry
    {


        public FunctionFoundry(TranformJsonAstConfiguration configuration, Dictionary<string, JfunctionDefinition> functions)
        {
            this.configuration = configuration;
            this.functions = functions;
            this.Services = new ServiceContainer();
        }

        internal Factory<ITransformJsonService> GetService(string name, Type[] types)
        {

            //TransformJsonServiceProvider result = GetServiceImpl(name);
            //if (result != null)
            //    return result;

            var result = this.configuration.Services.GetService(name, types);
            if (result != null)
                return result;

            throw new MissingMethodException(name);
        }

        //private ObjectActivator<ITransformJsonService> GetServiceImpl(string name)
        //{
        //    ObjectActivator<ITransformJsonService> srv = Services.GetService(name);
        //    if (srv == null)
        //        if (this.functions.TryGetValue(name, out JfunctionDefinition function))
        //        {
        //            var f = Compile(function);
        //            this.Services.AddService(name, f);
        //            srv = Services.GetService(name);
        //        }

        //    return srv;

        //}

        private Factory<ITransformJsonService> Compile(JfunctionDefinition function)
        {
            throw new NotImplementedException();
        }

        private TranformJsonAstConfiguration configuration;
        private Dictionary<string, JfunctionDefinition> functions;
        private ServiceContainer Services;
    }
}