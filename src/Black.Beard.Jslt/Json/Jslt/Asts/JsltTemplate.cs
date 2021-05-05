using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json.Jslt.Asts
{

    public class JsltTemplate
    {

        public JsltTemplate()
        {

        }

        public Func<RuntimeContext, JToken, JToken> Rules { get; internal set; }

        public RuntimeContext LastExecutionContext { get; private set; }

        public JsltJson Template { get; internal set; }

        public TranformJsonAstConfiguration Configuration { get; internal set; }

        internal StringBuilder Rule { get; set; }

        public (JToken, RuntimeContext) Transform(Sources sources)
        {

            var ctx = new RuntimeContext(sources);

            var result = Rules(ctx, ctx.TokenSource);
            return (result, ctx);

        }

        //public override string ToString()
        //{
        //    var t = new VisualiserBuilder();
        //    var o = (JObject)this.Template.Accept(t);
        //    return o.ToString();
        //}

    }



}
