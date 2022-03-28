using Bb;
using Bb.Json.Jslt.Services;
using System;
using System.IO;
using System.Text;

namespace Wizards
{
    public static class TemplateHelper
    {

        /// <summary>
        /// Call this method for load anc compile template
        /// </summary>
        /// <param name="file">file that content the template jslt</param>
        /// <param name="withDebug">if true, activate the debug mode</param>
        /// <param name="paths">that for auto detect extended services</param>
        /// <param name="services">add extended services</param>
        /// <returns></returns>
        public static JsltTemplate LoadTemplate(this FileInfo file, bool withDebug, string[] paths, params Type[] services)
        {
            var content = file.FullName.LoadFromFile();
            StringBuilder sb = new StringBuilder(content);
            var _template = sb.GetTransformProvider(withDebug, file.FullName, paths, services);
            return _template;
        }

        public static JsltTemplate GetTransformProvider(this StringBuilder sb, bool withDebug, string templatefilename, string[] paths, params Type[] services)
        {
            var provider = GetProvider(paths, services);
            JsltTemplate template = provider.GetTemplate(sb, withDebug, templatefilename);
            return template;
        }

        public static TemplateTransformProvider GetProvider(string[] paths, params Type[] services)
        {

            var configuration = new TranformJsonAstConfiguration();

            // If you havn't added Package "Black.Beard.Jslt.Services" you can comment this line.
            configuration.Assemblies.Add(typeof(Bb.Jslt.Services.Services).Assembly);

            if (paths != null)
                foreach (var item in paths)
                    if (!string.IsNullOrEmpty(item))
                        configuration.Paths.Add(item);

            foreach (var item in services)
                configuration.Services.ServiceDiscovery.AddService(item);

            TemplateTransformProvider Templateprovider = new TemplateTransformProvider(configuration);

            return Templateprovider;

        }


    }


}
