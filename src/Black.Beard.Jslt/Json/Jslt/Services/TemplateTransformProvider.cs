using Bb.Expressions;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Bb.JSon;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
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

        public JsltTemplate GetTemplate(StringBuilder sb, bool withDebug, string filename, Diagnostics diagnostics = null)
        {
               
            if (string.IsNullOrEmpty(this._configuration.OutputPath) && !string.IsNullOrEmpty(filename))
                this._configuration.OutputPath = new FileInfo(filename).Directory.FullName;

            string filepathCode = string.Empty;
            var _errors = diagnostics ?? new Diagnostics();
            CultureInfo culture = this._configuration.Culture;
            OutputModelConfiguration outputConfiguration = null;
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
                    outputConfiguration = visitor.OutputConfiguration;

                }
            }
            catch (Exception e)
            {
                throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
            }

            Func<RuntimeContext, JToken, JToken> rules = null;
            Func<RuntimeContext, JToken, StringBuilder> ruleOutput = null;

            if (_errors.Success)
            {
                var crc = sb.Calculate().ToString();
                filepathCode = crc + ".cs";
                // Transform the template
                rules = Get(tree, _foundry, _errors, filepathCode, withDebug);

                if (outputConfiguration != null && outputConfiguration.Function != null)
                {
                    var codeName = Path.GetFileNameWithoutExtension(filepathCode) + "_output" + Path.GetExtension(filepathCode);
                    ruleOutput = GetOutput(outputConfiguration.Function, _foundry, _errors, codeName, withDebug);
                }

            }

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = this._configuration,
                Rules = rules,
                RuleOutput = new OutputSerializationRule()
                {
                    Filter = outputConfiguration.Filter?.Value,
                    Rule = ruleOutput,
                },
                Tree = tree,
                Culture = culture,
                Filename = filename,
                Diagnostics = _errors,
            };

            return result;

        }

        private Func<RuntimeContext, JToken, JToken> Get(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = this._configuration.OutputPath,
                };

                var builder = new TemplateWithExpressionBuilder(_errors, sourceCompiler) { Configuration = this._configuration, EmbbededFunctions = foundry };
                fnc = builder.GenerateLambda(tree, filepathCode);

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

        private Func<RuntimeContext, JToken, StringBuilder> GetOutput(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, JToken, StringBuilder> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = this._configuration.OutputPath,
                };

                var builder = new OutputExpressionBuilder(_errors, sourceCompiler) { Configuration = this._configuration, EmbbededFunctions = foundry };
                fnc = builder.GenerateLambdaOutput(tree, filepathCode);

            }
            else // Template empty
            {
                var arg = Expression.Parameter(typeof(RuntimeContext), "arg0");
                var arg1 = Expression.Parameter(typeof(JToken), "arg1");
                var lbd = Expression.Lambda<Func<RuntimeContext, JToken, StringBuilder>>(arg1, arg, arg1);

                if (lbd.CanReduce)
                    lbd.ReduceAndCheck();

                fnc = lbd.Compile();
            }

            return fnc;

        }


        private TranformJsonAstConfiguration _configuration;

    }

}
