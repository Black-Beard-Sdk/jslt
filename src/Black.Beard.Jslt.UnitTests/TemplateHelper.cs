using Bb.Jslt.Asts;
using System;
using System.Linq;
using System.Text;
using Bb.Jslt;

namespace Black.Beard.Jslt.UnitTests
{
    public class TemplateHelper
    {


        public static RuntimeContext Test(string templatePayload, Action<Sources> sources = null, Action<TranformJsonAstConfiguration> initializerConfiguration = null)
        {

            Sources src = new Sources();
            if (sources != null)
                sources(src);

            return TestBase(templatePayload, src, false, initializerConfiguration);

        }

        public static RuntimeContext Test(string templatePayload, bool withDebug, Action<Sources> sources = null, Action<TranformJsonAstConfiguration> initializerConfiguration = null)
        {

            Sources src = new Sources();
            if (sources != null)
                sources(src);

            return TestBase(templatePayload, src, withDebug, initializerConfiguration);

        }

        private static RuntimeContext TestBase(string templateTree, Sources sources, bool withDebug, Action<TranformJsonAstConfiguration> initializerConfiguration)
        {

            var src = sources ?? new Sources(SourceJson.GetEmpty());

            var template = GetProvider(templateTree, withDebug, initializerConfiguration);
            var result = template.Transform(src);
            return result;
        }

        private static JsltTemplate GetProvider(string payloadTemplate, bool withDebug, Action<TranformJsonAstConfiguration> initializerConfiguration)
        {

            var configuration = new TranformJsonAstConfiguration()
                .AddAssembly(typeof(DataClass))
                ;

            if (initializerConfiguration != null)
                initializerConfiguration(configuration);

            //if (services.Length > 0)
            //    configuration.AddServices(services);

            TemplateProvider Templateprovider = TemplateProvider.Get(configuration);
            StringBuilder sb = new StringBuilder(payloadTemplate);
            JsltTemplate template = Templateprovider.GetTemplate(sb, withDebug, string.Empty);

            if (!template.Diagnostics.Success)
            {
                var error = template.Diagnostics.Errors.First();
                throw new Exception(error.Message);
            }


            return template;

        }






        public static RuntimeContext Test(JsltBase templateTree, Action<Sources> sources = null, Action<TranformJsonAstConfiguration> initializerConfiguration = null)
        {

            Sources src = new Sources();
            if (sources != null)
                sources(src);

            return TestBase(templateTree, src, false, initializerConfiguration);

        }

        public static RuntimeContext Test(JsltBase templateTree, bool withDebug, Action<Sources> sources = null, Action<TranformJsonAstConfiguration> initializerConfiguration = null)
        {

            Sources src = new Sources();
            if (sources != null)
                sources(src);

            return TestBase(templateTree, src, withDebug, initializerConfiguration);

        }


        private static RuntimeContext TestBase(JsltBase templateTree, Sources sources, bool withDebug, Action<TranformJsonAstConfiguration> initializerConfiguration)
        {

            var src = sources ?? new Sources(SourceJson.GetEmpty());

            var template = GetProvider(templateTree, withDebug, initializerConfiguration);
            var result = template.Transform(src);
            return result;
        }


        private static JsltTemplate GetProvider(JsltBase payloadTemplate, bool withDebug, Action<TranformJsonAstConfiguration> initializerConfiguration)
        {
            return GetProvider(payloadTemplate.ToString(), withDebug, initializerConfiguration);
        }


    }

}