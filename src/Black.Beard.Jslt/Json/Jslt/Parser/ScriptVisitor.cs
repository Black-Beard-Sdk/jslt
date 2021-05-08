using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            this._dictionaryPosition = new Dictionary<JToken, Position>();
            this._definitionFunction = new Dictionary<string, JfunctionDefinition>();
        }

        public Dictionary<string, JfunctionDefinition> EmbeddedFunctions { get => this._definitionFunction; }

        public override object VisitScript([NotNull] JsltParser.ScriptContext context)
        {
            this._initialSource = new StringBuilder(context.Start.InputStream.ToString());
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
            AddPosition(result, context.Start, context.Stop);

            var items = context.pair();

            foreach (var item in items)
            {

                var prop = (JProperty)item.Accept(this);
                if (prop.Name.StartsWith("$"))
                {

                    if (prop.Name.ToLower() == "$funcs")
                    {
                        if (prop.Value is JObject f)
                            foreach (JfunctionDefinition fu in f.Properties())
                                this._definitionFunction.Add(fu.Name, fu);
                    }

                    else if (prop.Name.ToLower() == "$source")
                    {
                        Stop();
                    }

                    else if (prop.Name.ToLower() == "$where")
                    {
                        Stop();
                    }

                }
                else
                    result.Add(prop);

            }

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
            AddPosition(result, context.Start, context.Stop);

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
                    return AddPosition(new JValue((Int32)o), context.Start, context.Stop);
                return AddPosition(new JValue(o), context.Start, context.Stop);
            }

            return AddPosition(new JValue(0), context.Start, context.Stop);

        }

        public override object VisitPair([NotNull] JsltParser.PairContext context)
        {

            var name = context.STRING().GetText().Trim().Trim('\"');
            var value = context.jsonValue().Accept(this);

            if (value is JfunctionBodyDefinition body)
                return AddPosition(new JfunctionDefinition(name, body), context.Start, context.Stop);

            return AddPosition(new JProperty(name, value), context.Start, context.Stop);

        }

        public override object VisitJsonValueBoolean([NotNull] JsltParser.JsonValueBooleanContext context)
        {
            var result = new JValue(context.GetText() == "TRUE");
            AddPosition(result, context.Start, context.Stop);
            return result;
        }

        public override object VisitJsonValueNumber([NotNull] JsltParser.JsonValueNumberContext context)
        {

            string value = context.GetText();

            if (!string.IsNullOrEmpty(value))
            {

                if (value.Contains(this._currentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    var p = double.Parse(value, this._currentCulture);
                    return AddPosition(new JValue(p), context.Start, context.Stop);
                }

                var o = Int64.Parse(value);
                return AddPosition(new JValue(o), context.Start, context.Stop);

            }

            return AddPosition(new JValue(0), context.Start, context.Stop);

        }

        public override object VisitJsonValueString([NotNull] JsltParser.JsonValueStringContext context)
        {
            var txt = context.GetText().Trim().Trim('\"');
            var data = new JValue(txt);
            return AddPosition(data, context.Start, context.Stop);
        }

        public override object VisitJsonType([NotNull] JsltParser.JsonTypeContext context)
        {

            var txt = context.GetText().Substring(1);

            if (context.URI() != null)
                return new JType(txt) { Type = typeof(Uri) };

            else if (context.TIME() != null)
                return new JType(txt) { Type = typeof(TimeSpan) };

            else if (context.DATETIME() != null)
                return new JType(txt) { Type = typeof(DateTime) };

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonValueNull([NotNull] JsltParser.JsonValueNullContext context)
        {
            return AddPosition(JValue.CreateNull(), context.Start, context.Stop);
        }

        public override object VisitJsonValueCodeString([NotNull] JsltParser.JsonValueCodeStringContext context)
        {

            var code = context.CODE_STRING().GetText().Trim('\'');

            List<int> lst = new List<int>()
            {
                code.IndexOf(' '),
                code.IndexOf('\t'),
                code.IndexOf('\r'),
                code.IndexOf('\n'),
            };

            var index = lst.Where(c => c != -1).Min();

            var l = code.Substring(0, index);
            var c = code.Substring(index).Trim();

            return AddPosition(new JfunctionBodyDefinition(l, c), context.Start, context.Stop);

        }

        #region Jsonlt

        public override object VisitJsonLt([NotNull] JsltParser.JsonLtContext context)
        {
            var result = new JChained();
            AddPosition(result, context.Start, context.Stop);

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

                    //var jsonLtItemFunction = context.jsonLtItemFunction();
                    //if (jsonLtItemFunction != null)
                    //    result = jsonLtItemFunction.Accept(this);

                    //else
                    //{

                    Stop();

                    //}

                }
            }

            return result;

        }

        //public override object VisitJsonLtItemFunction([NotNull] JsltParser.JsonLtItemFunctionContext context)
        //{

        //    var jsonArgumentList = context.jsonArgumentList();
        //    var parameters = (List<string>)jsonArgumentList.Accept(this);
        //    var js_block = context.js_block().GetText();

        //    var lenght = context.Stop.StopIndex - context.Start.StartIndex;
        //    StringBuilder sb = new StringBuilder(lenght);

        //    string functionName = string.Empty;
        //    var id = context.ID();
        //    if (id != null)
        //        functionName = id.GetText();
        //    else
        //        functionName = "anonymus_" + Crc32.Calculate(js_block).ToString();
        //    sb.Append(functionName);


        //    sb.Append("(");
        //    string comma = string.Empty;
        //    foreach (var item in parameters)
        //    {
        //        sb.Append(comma);
        //        sb.Append(item);
        //        comma = ", ";
        //    }

        //    sb.Append(") ");

        //    sb.Append(js_block);

        //    return new JfunctionDefinition(functionName, parameters, sb.ToString());

        //}

        //public override object VisitJsonArgumentList([NotNull] JsltParser.JsonArgumentListContext context)
        //{
        //    var ids = context.ID();
        //    List<string> result = new List<string>(ids.Length);
        //    foreach (var item in ids)
        //        result.Add(item.GetText());
        //    return result;
        //}

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

            return AddPosition(new JConstructor(name, argumentsJson.ToArray()), context.Start, context.Stop);

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
            return AddPosition(new JPath(txt), context.Start, context.Stop);
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


        private T AddPosition<T>(T result, IToken start, IToken stop, JValue comment = null)
            where T : JToken
        {
            this._dictionaryPosition.Add(result, new Position(new TokenLocation(start), new TokenLocation(stop), comment));
            return result;
        }

        private Position Get(JToken token)
        {
            return this._dictionaryPosition[token];
        }

        private StringBuilder _initialSource;
        private List<ErrorModel> _errors;
        private Dictionary<JToken, Position> _dictionaryPosition;
        private Dictionary<string, JfunctionDefinition> _definitionFunction;
        private readonly CultureInfo _currentCulture;

    }

}
