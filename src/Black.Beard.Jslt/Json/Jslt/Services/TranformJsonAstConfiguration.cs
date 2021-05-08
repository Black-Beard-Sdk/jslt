using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{
    public partial class TranformJsonAstConfiguration
    {

        public TranformJsonAstConfiguration()
        {

            this.Services = new ServiceContainer();

            //this.AddService(typeof(ServiceAdd))
            //    .AddService(typeof(ServiceConcat))
            //    .AddService(typeof(ServiceConcatAll))
            //    .AddService(typeof(ServiceCrc32))
            //    .AddService(typeof(ServiceDistinct))
            //    .AddService(typeof(ServiceNotNull))
            //    .AddService(typeof(ServiceDiv))
            //    .AddService(typeof(ServiceFrombase64))
            //    .AddService(typeof(ServiceModulo))
            //    .AddService(typeof(ServiceSha256))
            //    .AddService(typeof(ServiceSha512))
            //    .AddService(typeof(ServiceSubStr))
            //    .AddService(typeof(ServiceUniquekey))
            //    .AddService(typeof(ServiceSubstract))
            //    .AddService(typeof(ServiceSum))
            //    .AddService(typeof(ServiceTime))
            //    .AddService(typeof(ServiceTobase64))

            ;

        }

        /// <summary>
        /// Add services in the configuration container. the type must to have an attribute <see cref="System.ComponentModel.DisplayNameAttribute" /> for identify the key to match.
        /// The type of service must implemente <see cref="Bb.TransformJson.ITransformJsonService" />
        /// </summary>
        /// <param name="service"></param>
        /// <returns>return the current instance of <see cref="TranformJsonAstConfiguration"/> for using in fluence code.</returns>
        public TranformJsonAstConfiguration AddService(Type service, string name = null)
        {

            if (string.IsNullOrEmpty(name))
            {
                var n = service.GetCustomAttributes(typeof(DisplayNameAttribute), true).OfType<DisplayNameAttribute>().FirstOrDefault();
                if (n == null)
                    throw new ArgumentNullException($"service {service}, can't be added by type. missing {typeof(DisplayNameAttribute)} ");

                name = n.DisplayName;

            }

            var ctors = service.GetConstructors();
            foreach (var ctor in ctors)
            {
                Factory<ITransformJsonService> factory = ObjectCreator.GetActivator<ITransformJsonService>(ctor);
                Services.AddService(name, factory);
            }

            return this;
        }

        public ServiceContainer Services { get; }


    }



}
