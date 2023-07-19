using Bb.Expressions;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Parser;
using Bb.JSon;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Gets the template from text.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug].</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <returns></returns>
        /// <exception cref="Bb.JSon.ParsingJsonException">Failed to parse Json. " + e.Message</exception>
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
                    var visitor = new ScriptBuilderVisitor(this._configuration, parser.Parser, _errors, filename);
                    tree = (JsltBase)parser.Visit(visitor);

                    JsltComment comment = null;
                    List<JsltComment> _comments = new List<JsltComment>();
                    bool inComment = false;

                    for (int i = 0; i < sb.Length; i++)
                    {
                        var c = sb[i];
                        if (inComment)
                        {
                            if (c == '*' && sb[i + 1] == '/')
                            {
                                comment.Stop = new TokenLocation(i + 1, 0, 0, 0);
                                inComment = false;
                            }
                        }
                        else
                        {
                            if (c == '/' && sb[i + 1] == '*')
                            {
                                comment = new JsltComment()
                                {
                                    Start = new TokenLocation(i, 0, 0, 0),
                                };
                                _comments.Add(comment);
                                inComment = true;
                            }

                        }
                    }

                    tree.AddComments(_comments);

                    _foundry = visitor.Foundry;
                    culture = visitor.Culture;
                    outputConfiguration = visitor.OutputConfiguration;

                }
            }
            catch (Exception e)
            {
                //LocalDebug.Stop();
                throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
            }

            Func<RuntimeContext, JToken, JToken> rules = null;
            Func<RuntimeContext, StringBuilder> ruleOutput = null;
            Func<RuntimeContext, object> ruleWriter = null;

            if (_errors.Success)
            {
                var crc = Crc32.CalculateCrc32(sb).ToString();
                filepathCode = crc + ".cs";
                // Transform the template
                rules = Get(tree, _foundry, _errors, filepathCode, filename, withDebug);

                if (outputConfiguration != null && outputConfiguration.Function != null)
                {
                    var codeName = Path.GetFileNameWithoutExtension(filepathCode) + "_output" + Path.GetExtension(filepathCode);
                    ruleOutput = GetOutput(outputConfiguration.Function, _foundry, _errors, codeName, withDebug);

                    if (outputConfiguration.Writer != null)
                    {
                        ruleWriter = GetWriter(outputConfiguration.Writer, _foundry, _errors, codeName, withDebug);

                    }

                }

            }

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = this._configuration,
                Rules = rules,
                RuleOutput = new OutputSerializationRule()
                {
                    Filter = outputConfiguration?.Filter?.Value,
                    Rule = ruleOutput,
                    Writer = ruleWriter,
                },
                Tree = tree,
                Culture = culture,
                Filename = filename,
                Diagnostics = _errors,
            };

            return result;

        }

        /// <summary>
        /// Gets the template from tree syntax.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug].</param>
        /// <param name="filename">The filename.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <returns></returns>
        public JsltTemplate GetTemplate(JsltBase tree, bool withDebug, string filename, Diagnostics diagnostics = null)
        {
            return GetTemplate(new StringBuilder(tree.ToString()), withDebug, filename, diagnostics);
        }


        private Func<RuntimeContext, JToken, JToken> Get(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors, string filepathCode, string scriptPath, bool withDebug)
        {

            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = this._configuration.OutputPath,
                };

                var builder = new TemplateWithExpressionBuilder(_errors, sourceCompiler, withDebug)
                {
                    ScriptPath = scriptPath,
                    Configuration = this._configuration,
                    EmbbededFunctions = foundry
                };
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

        private Func<RuntimeContext, StringBuilder> GetOutput(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, StringBuilder> fnc;

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
                var lbd = Expression.Lambda<Func<RuntimeContext, StringBuilder>>(arg1, arg, arg1);

                if (lbd.CanReduce)
                    lbd.ReduceAndCheck();

                fnc = lbd.Compile();
            }

            return fnc;

        }

        private Func<RuntimeContext, object> GetWriter(JsltBase tree, FunctionFoundry foundry, Diagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, object> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = this._configuration.OutputPath,
                };

                var builder = new SaveExpressionBuilder(_errors, sourceCompiler) { Configuration = this._configuration, EmbbededFunctions = foundry };
                fnc = builder.GenerateLambdaWriter(tree, filepathCode);

            }
            else // Template empty
            {
                var arg = Expression.Parameter(typeof(RuntimeContext), "arg0");
                var arg1 = Expression.Parameter(typeof(JToken), "arg1");
                var lbd = Expression.Lambda<Func<RuntimeContext, object>>(arg1, arg, arg1);

                if (lbd.CanReduce)
                    lbd.ReduceAndCheck();

                fnc = lbd.Compile();
            }

            return fnc;

        }

        private TranformJsonAstConfiguration _configuration;

    }



}
