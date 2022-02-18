using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
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
