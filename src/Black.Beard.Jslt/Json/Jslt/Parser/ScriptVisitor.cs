using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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

            if (txt.StartsWith("$"))
                return AddPosition(new JPath(txt), context.Start, context.Stop);

            return AddPosition(new JValue(txt), context.Start, context.Stop);

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

        public override object VisitJsonLtOperation([NotNull] JsltParser.JsonLtOperationContext context)
        {

            JToken left = null;

            var ltItem = context.jsonLtItem();
            if (ltItem != null)
            {
                var item = (JToken)ltItem.Accept(this);
                if (context.NT() == null)
                    left = item;
                else
                    left = AddPosition(new JUnaryOperation(item, OperationEnum.Not), context.Start, context.Stop);
            }

            var right_operation = context.jsonLtOperation();

            if (right_operation != null)
            {

                var operationRight = (JToken)right_operation.Accept(this);

                if (context.PAREN_LEFT() == null)
                {
                    var operation = (OperationEnum)context.operation().Accept(this);
                    return AddPosition(new JBinaryOperation(left, operation, operationRight), context.Start, context.Stop);
                }

                return AddPosition(new JSubExpression(left), context.Start, context.Stop);

            }

            return left;
        }

        public override object VisitOperation([NotNull] JsltParser.OperationContext context)
        {

            if (context.EQ() != null)
                return OperationEnum.Equal;

            else if (context.GE() != null)
                return OperationEnum.GreaterThanOrEqual;

            else if (context.GT() != null)
                return OperationEnum.GreaterThan;

            else if (context.LE() != null)
                return OperationEnum.LessThanOrEqual;

            else if (context.LT() != null)
                return OperationEnum.LessThan;

            else if (context.NE() != null)
                return OperationEnum.NotEqual;

            else if (context.PLUS() != null)
                return OperationEnum.Add;

            else if (context.MINUS() != null)
                return OperationEnum.Subtract;

            else if (context.DIVID() != null)
                return OperationEnum.Divide;

            else if (context.MODULO() != null)
                return OperationEnum.Modulo;

            else if (context.WILDCARD_SUBSCRIPT() != null)
                return OperationEnum.Multiply;

            else if (context.POWER() != null)
                return OperationEnum.Power;

            else if (context.CHAIN() != null)
                return OperationEnum.Chain;

            else if (context.AND() != null)
                return OperationEnum.And;

            else if (context.AND_EXCLUSIVE() != null)
                return OperationEnum.AndExclusive;

            else if (context.OR() != null)
                return OperationEnum.Or;

            else if (context.OR_EXCLUSIVE() != null)
                return OperationEnum.OrExclusive;

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonLtItem([NotNull] JsltParser.JsonLtItemContext context)
        {

            var ctor = context.jsonfunctionCall();
            if (ctor != null)
                return ctor.Accept(this);

            var jsonWhen = context.jsonWhen();
            if (jsonWhen != null)
                return jsonWhen.Accept(this);

            var jsonBool = context.jsonValueBoolean();
            if (jsonBool != null)
                return jsonBool.Accept(this);

            var jsonString = context.jsonValueString();
            if (jsonString != null)
                return jsonString.Accept(this);

            var jsonInteger = context.jsonValueInteger();
            if (jsonInteger != null)
                return jsonInteger.Accept(this);

            var jsonNumber = context.jsonValueNumber();
            if (jsonNumber != null)
                return jsonNumber.Accept(this);

            Stop();

            return null;
        }

        public override object VisitJsonWhen([NotNull] JsltParser.JsonWhenContext context)
        {

            var expression = (JToken)context.jsonWhenExpression().Accept(this);

            var cases = context.jsonCase();

            List<JCaseExpression> _caseList = new List<JCaseExpression>(cases.Length);
            foreach (var @case in cases)
                _caseList.Add((JCaseExpression)@case.Accept(this));

            JDefaultCaseExpression d = null;
            var defaultCase = context.jsonDefaultCase();
            if (defaultCase != null)
                d = (JDefaultCaseExpression)defaultCase.Accept(this);

            return AddPosition(new JWhenExpression(expression, _caseList, d), context.Start, context.Stop);

        }

        public override object VisitJsonCase([NotNull] JsltParser.JsonCaseContext context)
        {
            var expression = (JToken)context.jsonWhenExpression().Accept(this);
            var content = (JToken)context.jsonValue().Accept(this);
            return AddPosition(new JCaseExpression(expression, content), context.Start, context.Stop);
        }

        public override object VisitJsonDefaultCase([NotNull] JsltParser.JsonDefaultCaseContext context)
        {
            var content = (JToken)context.jsonValue().Accept(this);
            return AddPosition(new JDefaultCaseExpression(content), context.Start, context.Stop);
        }

        public override object VisitJsonfunctionCall([NotNull] JsltParser.JsonfunctionCallContext context)
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


    public enum OperationEnum
    {
        Equal,
        GreaterThanOrEqual,
        GreaterThan,
        LessThanOrEqual,
        LessThan,
        NotEqual,
        Add,
        Subtract,
        Divide,
        Modulo,
        Multiply,
        Power,
        Not,
        Chain,
        And,
        AndExclusive,
        Or,
        OrExclusive,
    }

}
