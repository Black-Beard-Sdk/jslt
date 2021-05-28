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

        public JsltTemplate GetTemplate(StringBuilder sb, string filename)
        {

            var _errors = new Diagnostics();
            CultureInfo culture = this._configuration.Culture;

            //for (int i = 0; i < sb.Length; i++)
            //{
            //    char ii = sb[i];
            //    if (ii == '\r' || ii == '\n')
            //    {
            //        ii = ' ';
            //        sb[i] = ii;
            //    }
            //}

            FunctionFoundry _foundry = null;
            JsltBase tree = null;

            try
            {
                if (sb.Length > 0)
                {
                    var parser = ScriptParser.ParseString(sb);
                    var visitor = new ScriptVisitor(this._configuration, _errors, filename);
                    tree = (JsltBase)parser.Visit(visitor);
                    _foundry = visitor.Foundry;
                    culture = visitor.Culture;

                }
            }
            catch (Exception e)
            {
                throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
            }

            Func<RuntimeContext, JToken, JToken> rules = null;
            if (_errors.Success)
                rules = Get(tree, _foundry, _errors);

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = this._configuration,
                Rules = rules,
                Tree = tree,
                Culture = culture,
                Filename = filename,
                Diagnostics = _errors,
            };

            return result;

        }

        private Func<RuntimeContext, JToken, JToken> Get(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors)
        {

            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {
                var builder = new TemplateBuilder(_errors) { Configuration = this._configuration, EmbbededFunctions = foundry };
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
