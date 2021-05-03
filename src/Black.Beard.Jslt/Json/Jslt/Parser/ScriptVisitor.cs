using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bb.Json.Jslt.Parser
{
    public class ScriptVisitor : JsltParserBaseVisitor<object>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        public ScriptVisitor(CultureInfo culture = null)
        {
            this._currentCulture = culture ?? CultureInfo.InvariantCulture;
        }

        public override object VisitScript([NotNull] JsltParser.ScriptContext context)
        {
            var result = context.json().Accept(this);
            return result;
        }

        /// <summary>
        /// json : jsonValue
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitJson([NotNull] JsltParser.JsonContext context)
        {
            var result = base.VisitJson(context);
            return result;
        }


        /// <summary>
        /// obj : 
        ///       BRACE_LEFT pair(COMMA pair)* BRACE_RIGHT
        ///     | BRACE_LEFT BRACE_RIGHT
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitObj([NotNull] JsltParser.ObjContext context)
        {

            var result = new JObject();
            var items = context.pair();

            foreach (var item in items)
                result.Add((JProperty)item.Accept(this));

            return result;

        }

        /// <summary>
        /// array :
        ///       BRACKET_LEFT jsonValue(COMMA jsonValue)* BRACKET_RIGHT
        ///     | BRACKET_LEFT BRACKET_RIGHT
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitArray([NotNull] JsltParser.ArrayContext context)
        {

            var result = new JArray();
            var items = context.jsonValue();

            foreach (var item in items)
            {
                var itemResult = item.Accept(this);
                if (itemResult is JToken t)
                    result.Add(t);

                else if (itemResult is string s)
                    result.Add((JValue)s);

                else if (itemResult is float f)
                    result.Add((JValue)f);

                else if (itemResult is double d)
                    result.Add((JValue)d);

                else if (itemResult is int i)
                    result.Add((JValue)i);

                else if (itemResult is long l)
                    result.Add((JValue)l);

                else
                {
                    Stop();
                }

            }
            return result;

        }

        public override object VisitJsonValueInteger([NotNull] JsltParser.JsonValueIntegerContext context)
        {

            string value = context.GetText();

            if (!string.IsNullOrEmpty(value))
            {
                var o = Int64.Parse(value);
                if (o <= Int32.MaxValue)
                    return new JValue((Int32)o);
                return new JValue(o);
            }

            return new JValue(0);

        }

        public override object VisitPair([NotNull] JsltParser.PairContext context)
        {
            return new JProperty(context.STRING().GetText().Trim().Trim('\"'), context.jsonValue().Accept(this));
        }

        public override object VisitJsonValueBoolean([NotNull] JsltParser.JsonValueBooleanContext context)
        {
            return new JValue(context.GetText() == "TRUE");
        }

        public override object VisitJsonValueNumber([NotNull] JsltParser.JsonValueNumberContext context)
        {

            string value = context.GetText();

            if (!string.IsNullOrEmpty(value))
            {

                if (value.Contains(this._currentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    var p = double.Parse(value, this._currentCulture);
                    if (p <= float.MaxValue)
                        return new JValue((float)p);
                    return new JValue(p);
                }

                var o = Int64.Parse(value);
                if (o <= Int32.MaxValue)
                    return new JValue((Int32)o);
                return new JValue(o);

            }

            return new JValue(0);

        }

        public override object VisitJsonValueString([NotNull] JsltParser.JsonValueStringContext context)
        {
            return context.GetText().Trim().Trim('\"');
        }

        public override object VisitJsonValueNull([NotNull] JsltParser.JsonValueNullContext context)
        {
            return JValue.CreateNull();
        }


        #region Jsonlt

        public override object VisitJsonLt([NotNull] JsltParser.JsonLtContext context)
        {
            var result = new JChained();
            var items = context.jsonLtItem();
            foreach (var item in items)
                result.Add((JToken)item.Accept(this));
            return result;
        }

        public override object VisitJsonLtItem([NotNull] JsltParser.JsonLtItemContext context)
        {
            object result = null;
            var path = context.jsonpath();
            if (path != null)
                result = path.Accept(this);

            else
            {

                var ctor = context.jsonCtor();
                if (ctor != null)
                    result = ctor.Accept(this);

                else
                {
                    Stop();
                }
            }

            return result;

        }

        
        #region Extended json
                
        public override object VisitJsonCtor([NotNull] JsltParser.JsonCtorContext context)
        {
            var name = context.ID().ToString();
            List<object> argumentsJson = new List<object>();
            var arguments = context.jsonValueList();
            if (arguments != null)
            {
                var o = (List<object>)arguments.Accept(this);
                argumentsJson.AddRange(o);
            }
            return new JConstructor(name, argumentsJson.ToArray());
        }

        public override object VisitJsonValueList([NotNull] JsltParser.JsonValueListContext context)
        {

            List<object> result = new List<object>();
            var items = context.jsonValue();

            foreach (var item in items)
                result.Add(item.Accept(this));

            return result;

        }

        #endregion

        #region Jpath

        public override object VisitJsonpath([NotNull] JsltParser.JsonpathContext context)
        {
            var txt = context.GetText();
            return new JPath(txt);
        }

        public override object VisitSliceable([NotNull] JsltParser.SliceableContext context)
        {
            return base.VisitSliceable(context);
        }
        
        public override object VisitAndExpression([NotNull] JsltParser.AndExpressionContext context)
        {
            return base.VisitAndExpression(context);
        }

        public override object VisitExpression([NotNull] JsltParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }

        public override object VisitNotExpression([NotNull] JsltParser.NotExpressionContext context)
        {
            return base.VisitNotExpression(context);
        }

        public override object VisitOrExpression([NotNull] JsltParser.OrExpressionContext context)
        {
            return base.VisitOrExpression(context);
        }

        public override object VisitSubscript([NotNull] JsltParser.SubscriptContext context)
        {
            return base.VisitSubscript(context);
        }

        public override object VisitSubscriptable([NotNull] JsltParser.SubscriptableContext context)
        {
            return base.VisitSubscriptable(context);
        }

        public override object VisitSubscriptableBareword([NotNull] JsltParser.SubscriptableBarewordContext context)
        {
            return base.VisitSubscriptableBareword(context);
        }

        public override object VisitSubscriptables([NotNull] JsltParser.SubscriptablesContext context)
        {
            return base.VisitSubscriptables(context);
        }

        #endregion Jpath

        #endregion Jsonlt

        #region not implemented

        ///// <summary>
        ///// jsonValue :
        /////       STRING
        /////     | NUMBER
        /////     | obj
        /////     | array
        /////     | TRUE
        /////     | FALSE
        /////     | NULL
        /////     
        /////     /* extension */
        /////     | jsonpath
        /////     | jsonCtor
        /////     
        /////     ;
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override object VisitJsonValue([NotNull] JsltParser.JsonValueContext context)
        //{
        //    return base.VisitJsonValue(context);
        //}

        #endregion

        public void EvaluateErrors(IParseTree item)
        {

            if (item != null)
            {

                if (item is ErrorNodeImpl e)
                    this._errors.Add(new ErrorModel()
                    {
                        Filename = Filename,
                        Line = e.Symbol.Line,
                        StartIndex = e.Symbol.StartIndex,
                        Column = e.Symbol.Column,
                        Text = e.Symbol.Text,
                        Message = $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} ' {e.Symbol.Text}'"
                    });

                int c = item.ChildCount;
                for (int i = 0; i < c; i++)
                {
                    IParseTree child = item.GetChild(i);
                    EvaluateErrors(child);
                }

            }

        }

        public override object Visit(IParseTree tree)
        {
            this._errors = new List<ErrorModel>();
            EvaluateErrors(tree);
            if (this._errors.Count > 0)
                Stop();
            var result = base.Visit(tree);

            return result;

        }

        ///// <summary>
        ///// script_fragment | script_full
        ///// </summary>
        ///// <param name="context"></param>
        ///// <returns></returns>
        //public override object VisitScript([NotNull] WorkflowParser.ScriptContext context)
        //{

        //    this._initialSource = new StringBuilder(context.Start.InputStream.ToString());

        //    if (this._workflow == null)
        //        this._workflow = new WorkflowConfig()
        //        {
        //            Crc = this.Crc,
        //        };
        //    else
        //        this._workflow.Crc ^= this._workflow.Crc;

        //    base.VisitScript(context);

        //    this._workflow.BuildWorkflow();

        //    return this._workflow;

        //}



        public IEnumerable<ErrorModel> Errors { get => this._errors; }

        public string Filename { get; set; }

        public uint Crc { get; set; }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        //private StringBuilder GetText(RuleContext context)
        //{

        //    if (context is ParserRuleContext s)
        //        return GetText(s.Start.StartIndex, s.Stop.StopIndex + 1);
        //    return new StringBuilder();
        //}

        //private StringBuilder GetText(int startIndex, int stopIndex)
        //{

        //    int length = stopIndex - startIndex;

        //    length++;

        //    StringBuilder sb2 = new StringBuilder(length);
        //    char[] ar = new char[length];
        //    _initialSource.CopyTo(startIndex, ar, 0, length);
        //    sb2.Append(ar);

        //    return sb2;

        //}

        //public WorkflowConfigVisitor AddRule(string name, Func<RunContext, bool> function)
        //{
        //    AddRule(name, function.Method);
        //    return this;
        //}

        //public WorkflowConfigVisitor AddRule(string name, MethodInfo method)
        //{
        //    var r = new RuleDefinitionModel()
        //    {
        //        Key = name,
        //        Comment = string.Empty,
        //        Method = method,
        //    };
        //    _rules.Add(r.Key, r);
        //    return this;
        //}

        //private Type ResolveTypeOfArgument(string key, MethodReference method)
        //{

        //    if (!method.Arguments.TryGetValue(key, out Type type))
        //        throw new InvalidArgumentNameMethodReferenceException(key);

        //    return type;

        //}

        //private Func<RunContext, object> GetLambda(string key, string value, Type type)
        //{

        //    Func<RunContext, object> func = null;

        //    if (value.StartsWith("'") && value.EndsWith("'"))
        //    {
        //        value = value.Trim('\'');
        //        var v = Convert.ChangeType(value, type);
        //        func = GetConstant<object>(v);
        //    }
        //    else if (value.StartsWith("'@"))
        //        func = ExpressionDynobjectExtension.GetAccessors<RunContext>(value.Substring(1));

        //    else
        //    {

        //        if (this._constants.TryGetValue(value, out ConstantExpressionModel m))
        //        {
        //            var v = Convert.ChangeType(m.Value, type);
        //            func = GetConstant<object>(v);
        //        }
        //        else
        //        {
        //            var v = Convert.ChangeType(value, type);
        //            func = GetConstant<object>(v);
        //        }
        //    }

        //    return func;

        //}

        //public static Func<object, T> GetConstant<T>(object value)
        //{
        //    Expression cc = Expression.Constant(value);
        //    if (cc.Type != typeof(T))
        //        cc = Expression.Convert(cc, typeof(T));
        //    ParameterExpression arg0 = Expression.Parameter(typeof(object), "arg0");
        //    var lbd = Expression.Lambda<Func<object, T>>(cc, arg0);
        //    return lbd.Compile();
        //}

        //private RuleDefinitionModel ResolveRule(string key)
        //{

        //    RuleDefinitionModel rule = ResolveRule_impl(key);
        //    if (rule == null)
        //        throw new Exceptions.InvalidMethodReferenceException(key);

        //    return rule;

        //}

        //protected virtual RuleDefinitionModel ResolveRule_impl(string key)
        //{
        //    this._rules.TryGetValue(key, out RuleDefinitionModel rule);
        //    return rule;
        //}

        //private (Func<RunContext, bool>, string) Compile(ExpressionModel expressionModel)
        //{
        //    StateConverterVisitor<RunContext> visitor = new StateConverterVisitor<RunContext>(_constants);
        //    (Func<RunContext, bool>, string) result = visitor.Visit(expressionModel);
        //    return result;
        //}


        //private readonly Dictionary<string, ConstantExpressionModel> _constants = new Dictionary<string, ConstantExpressionModel>();
        //private readonly Dictionary<string, RuleDefinitionModel> _rules = new Dictionary<string, RuleDefinitionModel>();
        //private readonly Dictionary<string, MethodReference> _actions = new Dictionary<string, MethodReference>();

        private StringBuilder _initialSource;
        private List<ErrorModel> _errors;
        private readonly CultureInfo _currentCulture;

    }

}
