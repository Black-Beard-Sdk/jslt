using Bb.Analysis.DiagTraces;
using Bb.Json.Jslt.Asts;
using Oldtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Json.Jslt.Services
{


    public class JsltTemplate
    {

        internal JsltTemplate()
        {

        }

        /// <summary>
        /// Gets the template from tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug].</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(JsltBase tree, bool withDebug, string filename, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(tree, withDebug, filename, diagnostics);
        }

        /// <summary>
        /// Gets the template from tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(JsltBase tree, string filename, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(tree, false, filename, diagnostics);
        }

        /// <summary>
        /// Gets the template from tree.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(JsltBase tree, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(tree, false, string.Empty, diagnostics);
        }

        /// <summary>
        /// Gets the template from text.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug].</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(StringBuilder sb, bool withDebug, string filename, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(sb, withDebug, filename, diagnostics);
        }

        /// <summary>
        /// Gets the template from text.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(StringBuilder sb, string filename, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(sb, false, filename, diagnostics);
        }

        /// <summary>
        /// Gets the template from text.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static JsltTemplate GetTemplate(StringBuilder sb, ScriptDiagnostics diagnostics = null, TranformJsonAstConfiguration configuration = null)
        {
            var provider = new TemplateTransformProvider(configuration);
            return provider.GetTemplate(sb, false, string.Empty, diagnostics);
        }

        public Func<RuntimeContext, JToken, JToken> Rules { get; internal set; }

        public RuntimeContext LastExecutionContext { get; private set; }

        public TranformJsonAstConfiguration Configuration { get; internal set; }

        public CultureInfo Culture { get; internal set; }

        public string Filename { get; internal set; }

        public JsltBase Tree { get; internal set; }

        internal StringBuilder Rule { get; set; }

        public ScriptDiagnostics Diagnostics { get; internal set; }

        public OutputSerializationRule RuleOutput { get; internal set; }

        /// <summary>
        /// Execute the template
        /// </summary>
        /// <param name="sources">The sources.</param>
        /// <returns></returns>
        public StringBuilder TransformForOutput(Sources sources)
        {
            RuntimeContext result = this.Transform(sources);
            return ApplyOutput(result);
        }

        /// <summary>
        /// Execute the template
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        public StringBuilder TransformForOutput(RuntimeContext ctx)
        {
            RuntimeContext result = this.Transform(ctx);
            return ApplyOutput(result);
        }

        public StringBuilder ApplyOutput(RuntimeContext result)
        {

            var resultTokens = result.TokenResult;

            if (RuleOutput != null)
            {

                if (!string.IsNullOrEmpty(RuleOutput.Filter))
                {
                    var selects = resultTokens.SelectTokens(RuleOutput.Filter).ToList();
                    if (selects.Count == 1)
                        resultTokens = selects[0];

                    else if (selects.Count > 1)
                        resultTokens = new JArray(selects);

                    else
                        resultTokens = JValue.CreateNull();

                }

                if (RuleOutput.Rule != null)
                {

                    result.TokenResult = resultTokens;

                    var sb = RuleOutput.Rule(result);
                    result.Output = sb;

                    if (RuleOutput.Writer != null)
                        RuleOutput.Writer(result);

                    return result.Output;

                }

            }

            var resultText = new StringBuilder(resultTokens.ToString());

            return resultText;

        }

        /// <summary>
        /// Execute the template.
        /// </summary>
        /// <returns></returns>
        public RuntimeContext Transform()
        {
            RuntimeContext ctx = GetContext(null);
            ctx.Configuration = this.Configuration;
            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;

        }

        /// <summary>
        /// Execute the template
        /// </summary>
        /// <param name="sources">The sources.</param>
        /// <returns></returns>
        public RuntimeContext Transform(Sources sources)
        {
            RuntimeContext ctx = GetContext(sources);
            ctx.Configuration = this.Configuration;

            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;

        }

        /// <summary>
        /// Execute the template
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">ctx</exception>
        public RuntimeContext Transform(RuntimeContext ctx)
        {
            if (ctx == null)
                throw new ArgumentNullException(nameof(ctx));

            ctx.Configuration = this.Configuration;

            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;

        }

        public RuntimeContext GetContext(Sources? sources)
        {

            if (sources == null)
                sources = new Sources(SourceJson.GetEmpty());

            return new RuntimeContext(sources, this.Diagnostics)
            {
                Configuration = this.Configuration,
            };
        }

    }

}
