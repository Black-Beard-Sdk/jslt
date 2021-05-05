using Newtonsoft.Json.Linq;
using System;
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

        internal StringBuilder Rule { get; set; }

        public RuntimeContext Transform(Sources sources)
        {
            var ctx = new RuntimeContext(sources);
            ctx.TokenResult = Rules(ctx, ctx.TokenSource);
            return ctx;
        }

    }

}
