using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
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

        public string TransformForOutput(Sources sources, RuntimeContext ctx = null)
        {
            RuntimeContext result = this.Transform(sources, ctx);
            return ApplyOutput(result);
        }

        public string ApplyOutput(RuntimeContext result)
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
                    {
                        resultTokens = JValue.CreateNull();
                    }

                }

                if (RuleOutput.Rule != null)
                {

                    result.TokenResult = resultTokens;

                    var sb = RuleOutput.Rule(result, null);
                    return sb.ToString();

                }

            }

            return resultTokens.ToString();
        }

        public RuntimeContext Transform(Sources sources, RuntimeContext ctx = null)
        {
            if (ctx == null)
                ctx = GetContext(sources);

            else
                ctx.Configuration = this.Configuration;

            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;

        }

        public RuntimeContext GetContext(Sources sources)
        {
            return new RuntimeContext(sources, this.Diagnostics)
            {
                Configuration = this.Configuration,
            };
        }

    }

}
