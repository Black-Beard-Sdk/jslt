using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Oldtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Json.Jslt.Services
{


    public class JsltTemplate
    {

        public JsltTemplate()
        {

        }

        public Func<RuntimeContext, JToken, JToken> Rules { get; internal set; }

        public RuntimeContext LastExecutionContext { get; private set; }

        public TranformJsonAstConfiguration Configuration { get; internal set; }

        public CultureInfo Culture { get; internal set; }

        public string Filename { get; internal set; }

        public JsltBase Tree { get; internal set; }

        internal StringBuilder Rule { get; set; }

        public Diagnostics Diagnostics { get; internal set; }

        public OutputSerializationRule RuleOutput { get; internal set; }

        public StringBuilder TransformForOutput(Sources sources)
        {
            RuntimeContext result = this.Transform(sources);
            return ApplyOutput(result);
        }

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

        public RuntimeContext Transform(Sources sources)
        {
            RuntimeContext ctx = GetContext(sources);
            ctx.Configuration = this.Configuration;

            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;

        }

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
