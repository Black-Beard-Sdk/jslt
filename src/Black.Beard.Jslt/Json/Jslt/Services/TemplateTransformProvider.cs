using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Bb.JSon;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Json.Jslt.Services
{
    public class TemplateTransformProvider
    {

        public TemplateTransformProvider(TranformJsonAstConfiguration configuration = null)
        {

            if (configuration == null)
                configuration = new TranformJsonAstConfiguration();

            this._configuration = configuration;

        }

        public JsltTemplate GetTemplate(StringBuilder sb)
        {

            JToken obj = null;

            for (int i = 0; i < sb.Length; i++)
            {
                char ii = sb[i];
                if (ii == '\r' || ii == '\n')
                {
                    ii = ' ';
                    sb[i] = ii;
                }
            }

            Dictionary<string, JfunctionDefinition> functions = null;
            try
            {
                if (sb.Length > 0)
                {
                    var parser = ScriptParser.ParseString(sb);
                    var visitor = new ScriptVisitor(CultureInfo.InvariantCulture);
                    obj = (JObject)parser.Visit(visitor);
                    functions = visitor.EmbeddedFunctions;
                }
            }
            catch (Exception e)
            {
                throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
            }

            var foundry = new FunctionFoundry(this._configuration, functions);

            TranformJsonTemplateReader reader = new TranformJsonTemplateReader(obj, this._configuration, foundry);
            var tree = reader.Tree();

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = this._configuration,
                Rules = Get(tree, foundry)
            };

            return result;

        }

        private Func<RuntimeContext, JToken, JToken> Get(JsltJson tree, FunctionFoundry foundry)
        {

            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {
                var builder = new TemplateBuilder() { Configuration = this._configuration, EmbbededFunctions = foundry };
                fnc = builder.GenerateLambda(tree);
            }
            else // Template empty
            {
                var arg = Expression.Parameter(typeof(RuntimeContext), "arg0");
                var arg1 = Expression.Parameter(typeof(JToken), "arg1");
                var lbd = Expression.Lambda<Func<RuntimeContext, JToken, JToken>>(arg1, arg, arg1);

                if (lbd.CanReduce)
                    lbd.ReduceAndCheck();

                fnc = lbd.Compile();
            }

            return fnc;

        }

        private TranformJsonAstConfiguration _configuration;

    }

}
