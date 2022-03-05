Implementation of jslt language in DOTNET. Use a template for transform Json document to another json document.

The following sample for help you to easy start.

```CSHARP

    using Bb;
    using Bb.Json.Jslt.Services;
    using System.Text;

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
            var content = file.FullName.LoadFile();
            StringBuilder sb = new StringBuilder();
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

            // If you haven't added Package "Black.Beard.Jslt.Services" you must comment this line.
            // configuration.Assemblies.Add(typeof(Bb.Jslt.Services.Services).Assembly);

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


```

```CSHARP

    var file = new FileInfo(rulePayload);
    file.Refresh();
    if (!file.Exists)
        throw new Exception($"the path '{file}' can't be resolved.");

    // Build template
    var _template = file.LoadTemplate(false, new string[0]);


    // create an instance of sources with no datas
    var src = Sources.GetEmpty();

    // inject data in the model, for accessing by json path '$"
    // var src2 = new Sources(SourceJson.GetFromText("{}"));
    
    // Add a value for for accessing from the template
    src.Variables.Add("My value", new JValue(1));

    // execute template but not apply output directives.
    var ctx = _template.Transform(src);

    // execute template and apply output directives.
    var result = _template.TransformForOutput(src);

```