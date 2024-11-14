using Bb.Analysis.DiagTraces;
using Bb.Expressions;
using Bb.Jslt.Asts;
using Bb.Metrology;
using Bb.Jslt.Parser;
using Bb.Exceptions;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using Bb.Jslt.Visitors;

namespace Bb.Jslt
{

    public class TemplateProvider
    {

        static TemplateProvider()
        {
            Default = new TemplateProvider();
            typeof(InternalConverters).AppendConverters(true, BindingFlags.Public, (m) => true);
        }


        public static TemplateProvider Get(TranformJsonAstConfiguration configuration)
        {
            if (configuration == null)
                return Default;

            return new TemplateProvider(configuration);

        }

        public static TemplateProvider Default { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateProvider"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public TemplateProvider(TranformJsonAstConfiguration configuration = null)
        {
            _configuration = configuration
                ?? TranformJsonAstConfiguration.Configuration;
        }

        /// <summary>
        /// Gets the template built from text.
        /// </summary>
        /// <param name="tree">The template to run for transform the data</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug]. generate source code and manage a debugger for running step by step.</param>
        /// <param name="filename">The filename that  contains the code.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <returns></returns>
        /// <exception cref="Json.ParsingJsonException">Failed to parse Json. " + e.Message</exception>
        public JsltTemplate GetTemplate(JsltBase tree, bool withDebug, string filename, ScriptDiagnostics diagnostics = null)
        {
            return GetTemplate(new StringBuilder(tree.ToString()), withDebug, filename, diagnostics);
        }

        /// <summary>
        /// Gets the template built from text.
        /// </summary>
        /// <param name="sb">The template payload for transform the data</param>
        /// <param name="withDebug">if set to <c>true</c> [with debug]. generate source code and manage a debugger for running step by step.</param>
        /// <param name="filename">The filename that  contains the code.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <returns></returns>
        /// <exception cref="Json.ParsingJsonException">Failed to parse Json. " + e.Message</exception>
        public JsltTemplate GetTemplate(StringBuilder sb, bool withDebug, string filename, ScriptDiagnostics diagnostics = null)
        {

            using (var activity = JsltActivityProvider.StartActivity("Build jslt template", System.Diagnostics.ActivityKind.Internal))
            {

                if (string.IsNullOrEmpty(_configuration.OutputPath) && !string.IsNullOrEmpty(filename))
                    _configuration.OutputPath = new FileInfo(filename).Directory.FullName;

                var _errors = diagnostics ?? new ScriptDiagnostics();
                CultureInfo culture = _configuration.Culture;
                OutputModelConfiguration outputConfiguration = null;

                JsltBase tree = null;

                try
                {
                    if (sb.Length > 0)
                    {

                        // Parse the template or get the syntax tree
                        var parser = ScriptParser.ParseString(sb);
                        var visitor = new ScriptBuilderVisitor(_configuration, parser.Parser, _errors, filename);
                        tree = (JsltBase)parser.Visit(visitor);

                        if (tree != null && _errors.Success)
                            NormalizeComments(sb, tree);

                        culture = visitor.Culture; // the script define a specific culture for execution context
                        outputConfiguration = visitor.OutputConfiguration;

                    }
                }
                catch (Exception e)
                {
                    //LocalDebug.Stop();
                    throw new ParsingJsonException("Failed to parse Json. " + e.Message, e);
                }


                if (_errors.Success && tree != null) // if the parsing haven't  thrown any error
                {

                    var result = build(sb, tree, _errors, filename, withDebug, outputConfiguration, culture);

                    JsltActivityProvider.Set(c =>
                    {
                        foreach (var item in _errors)
                            c.SetCustomProperty(item.Id.ToString(), item);
                    });

                    return result;
                }


                JsltActivityProvider.Set(c =>
                {
                    foreach (var item in _errors)
                        c.SetCustomProperty(item.Id.ToString(), item);
                });

                return new JsltTemplate()
                {
                    Diagnostics = _errors,
                    Filename = filename,
                    Culture = culture,
                    Rule = sb,
                    Configuration = _configuration,
                    Rules = null,
                    RuleOutput = null,
                    Tree = tree,
                };


            }

        }

        private JsltTemplate build(StringBuilder sb, JsltBase tree, ScriptDiagnostics _errors,
            string filename, bool withDebug, OutputModelConfiguration outputConfiguration, CultureInfo culture)
        {

            Func<RuntimeContext, JToken, JToken> rules = null;
            Func<RuntimeContext, StringBuilder> ruleOutput = null;
            Func<RuntimeContext, object> ruleWriter = null;
            string filepathCode = string.Empty;

            var crc = sb.CalculateCrc32().ToString();
            filepathCode = crc + ".cs";

            // build the template
            rules = Get(tree, _errors, filepathCode, filename, withDebug); // compilation

            if (outputConfiguration != null && outputConfiguration.Function != null)
            {

                var codeName = Path.GetFileNameWithoutExtension(filepathCode) + "_output" + Path.GetExtension(filepathCode);
                ruleOutput = GetOutput(outputConfiguration.Function, _errors, codeName, withDebug);

                if (outputConfiguration.Writer != null)
                    ruleWriter = GetWriter(outputConfiguration.Writer, _errors, codeName, withDebug);

            }

            JsltTemplate result = new JsltTemplate()
            {
                Rule = sb,
                Configuration = _configuration,
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

        private static void NormalizeComments(StringBuilder sb, JsltBase tree)
        {
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
                        comment.Location = TextLocation.Create(i + 1);
                        inComment = false;
                    }
                }
                else
                {
                    if (c == '/' && sb[i + 1] == '*')
                    {
                        comment = new JsltComment()
                        {
                            Location = TextLocation.Create(i),
                        };
                        _comments.Add(comment);
                        inComment = true;
                    }

                }
            }

            tree.AddComments(_comments);
        }

        private Func<RuntimeContext, JToken, JToken> Get(JsltBase tree, ScriptDiagnostics _errors, string filepathCode, string scriptPath, bool withDebug)
        {

            var path = string.IsNullOrEmpty(scriptPath)
                ? string.IsNullOrEmpty(_configuration.OutputPath)
                    ? Environment.CurrentDirectory
                    : _configuration.OutputPath
                : scriptPath;


            Func<RuntimeContext, JToken, JToken> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = path,
                };

                var builder = new TemplateWithExpressionBuilder(_errors, sourceCompiler, withDebug)
                {
                    ScriptPath = scriptPath,
                    Configuration = _configuration,
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

        private Func<RuntimeContext, StringBuilder> GetOutput(JsltBase tree, ScriptDiagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, StringBuilder> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = _configuration.OutputPath,
                };

                var builder = new OutputExpressionBuilder(_errors, sourceCompiler) { Configuration = _configuration };
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

        private Func<RuntimeContext, object> GetWriter(JsltBase tree, ScriptDiagnostics _errors, string filepathCode, bool withDebug)
        {

            Func<RuntimeContext, object> fnc;

            if (tree != null)
            {

                var sourceCompiler = new LocalMethodCompiler(withDebug)
                {
                    OutputPath = _configuration.OutputPath,
                };

                var builder = new SaveExpressionBuilder(_errors, sourceCompiler) { Configuration = _configuration };
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
