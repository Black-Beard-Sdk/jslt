using Bb.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{
    public partial class TranformJsonAstConfiguration
    {

        public TranformJsonAstConfiguration(CultureInfo culture = null)
        {

            this.Culture = culture ?? CultureInfo.InvariantCulture;

            this.Services = new ServiceContainer();
            var assembly = typeof(TranformJsonAstConfiguration).Assembly;
            var types = TypeDiscovery.Instance.GetTypesWithAttributes<DisplayNameAttribute>(typeof(ITransformJsonService), c => true)
                .Where(c => c.Assembly == assembly);

            foreach (var item in types)
                AddService(item, null);

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

        public string Path { get; set; }
        public CultureInfo Culture { get; set; }

    }



}
