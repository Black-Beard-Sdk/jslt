using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Compilers;
using Bb.ComponentModel.Factories;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Builds;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        public ScriptVisitor(TranformJsonAstConfiguration configuration, string path = null)
        {

            this._scriptPath = path;
            this._configuration = configuration;
            this._currentCulture = _configuration.Culture;
            this._functions = new List<JsltFunctionCall>();
            this._foundry = new FunctionFoundry(this._configuration);
        }

        public FunctionFoundry Foundry { get => this._foundry; }

        public override object VisitScript([NotNull] JsltParser.ScriptContext context)
        {

            this._initialSource = new StringBuilder(context.Start.InputStream.ToString());
            var result = context.json().Accept(this);

            foreach (var item in this._functions)
            {
                var types = ResolveArgumentsTypes(item);
                Factory service = this._foundry.GetService(item.Name, types);
                if (service == null)
                {

                }
                else
                {
                    item.ServiceProvider = service;
                    item.ParameterTypes = service.Types;
                }
            }

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


            var result = new JsltObject() { Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            var items = context.pair();

            foreach (var item in items)
            {

                var prop = (JsltProperty)item.Accept(this);
                if (prop.Name.StartsWith("$"))
                {

                    if (prop.Name.ToLower() == "$funcs")
                    {
                        var cs = new List<FileInfo>();

                        if (prop.Value is JsltArray ar)
                            foreach (JsltBase fu in ar.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is Uri u)
                                        CollectCs(u.AbsoluteUri, cs, fu);
                                    else if (v.Value is string str)
                                        CollectCs(str, cs, fu);

                        LoadAssemblyFromCs(cs);

                    }

                    if (prop.Name.ToLower() == "$imports")
                    {

                        var dll = new List<FileInfo>();

                        if (prop.Value is JsltArray ar)
                            foreach (JsltBase fu in ar.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is Uri u)
                                        CollectCs(u.AbsoluteUri, dll, fu);
                                    else if (v.Value is string str)
                                        CollectCs(str, dll, fu);

                        LoadAssembly(dll);

                    }

                    else if (prop.Name.ToLower() == "$source")
                    {
                        Stop();
                        result.Source = prop.Value;
                    }

                    else if (prop.Name.ToLower() == "$where")
                    {
                        Stop();
                        result.Where = prop.Value;
                    }

                }
                //else if (prop.Name.StartsWith("@"))
                //{

                //}
                else
                    result.Append(prop);

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

            var items = context.jsonValue();
            var result = new JsltArray(items.Length) { Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            foreach (var item in items)
            {
                var itemResult = item.Accept(this);

                if (itemResult is JsltBase t)
                    result.Items.Add(t);

                else if (itemResult is string s)
                    result.Items.Add(new JsltConstant() { Value = s, Start = item.Start.ToLocation(), Stop = item.Start.ToLocation() });

                else if (itemResult is float f)
                    result.Items.Add(new JsltConstant() { Value = f, Start = item.Start.ToLocation(), Stop = item.Start.ToLocation() });

                else if (itemResult is double d)
                    result.Items.Add(new JsltConstant() { Value = d, Start = item.Start.ToLocation(), Stop = item.Start.ToLocation() });

                else if (itemResult is int i)
                    result.Items.Add(new JsltConstant() { Value = i, Start = item.Start.ToLocation(), Stop = item.Start.ToLocation() });

                else if (itemResult is long l)
                    result.Items.Add(new JsltConstant() { Value = l, Start = item.Start.ToLocation(), Stop = item.Start.ToLocation() });

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
                    return new JsltConstant() { Value = (Int32)0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

                return new JsltConstant() { Value = o, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
            }

            return new JsltConstant() { Value = 0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

        }

        public override object VisitJsonValueBoolean([NotNull] JsltParser.JsonValueBooleanContext context)
        {
            return new JsltConstant() { Value = context.GetText().ToUpper() == "TRUE", Kind = JsltKind.Boolean, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
        }

        public override object VisitJsonValueNumber([NotNull] JsltParser.JsonValueNumberContext context)
        {

            string value = context.GetText();

            if (!string.IsNullOrEmpty(value))
            {

                if (value.Contains(this._currentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    var p = double.Parse(value, this._currentCulture);
                    return new JsltConstant() { Value = p, Kind = JsltKind.Float, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
                }

                var o = Int64.Parse(value);
                return new JsltConstant() { Value = o, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            }

            return new JsltConstant() { Value = 0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

        }

        public override object VisitJsonValueString([NotNull] JsltParser.JsonValueStringContext context)
        {

            JsltBase result = null;
            Type type = null;

            var txt = context.STRING().GetText().Trim().Trim('\"');
            var containsVariable = txt.Contains("@@");

            var jsonType = context.jsonType();
            if (jsonType != null)
                type = ((JsltConstant)jsonType.Accept(this)).Value as Type;

            if (txt.StartsWith("$"))
            {

                if (type != null)
                {
                    if (type == typeof(string))
                    {
                        if (containsVariable)
                            result = new JsltTranslateVariable(GetConstant(txt, type, context));
                        else
                            result = GetConstant(txt, type, context);
                    }
                    else
                    {

                        List<JsltBase> args = null;
                        var c = new JsltConstant() { Value = type, Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
                        if (containsVariable)
                        {
                            var d = new JsltTranslateVariable(c);
                            args = new List<JsltBase>() { new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() }, d };

                        }
                        else
                            args = new List<JsltBase>() { new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() }, c };

                        result = new JsltFunctionCall("convert", args);

                    }
                }
                else
                {
                    if (containsVariable)
                        result = new JsltTranslateVariable(new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() });
                    else
                        result = new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

                }

            }

            else if (type != null)
            {
                if (containsVariable)
                    result = new JsltTranslateVariable(GetConstant(txt, type, context));
                else
                    result = GetConstant(txt, type, context);
            }
            else
            {
                if (containsVariable)
                    result = new JsltTranslateVariable(new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() });
                else
                    result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
            }

            return result;

        }

        private JsltConstant GetConstant(string txt, Type type, JsltParser.JsonValueStringContext context)
        {

            JsltConstant result;

            if (type == typeof(string))
                result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (type == typeof(Uri))
                result = new JsltConstant() { Value = new Uri(txt), Kind = JsltKind.Uri, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (type == typeof(TimeSpan))
                result = new JsltConstant() { Value = TimeSpan.Parse(txt, this._currentCulture), Kind = JsltKind.TimeSpan, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant() { Value = DateTime.Parse(txt, this._currentCulture), Kind = JsltKind.Date, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant() { Value = Guid.Parse(txt), Kind = JsltKind.Guid, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else
                result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            return result;

        }

        public override object VisitJsonType([NotNull] JsltParser.JsonTypeContext context)
        {

            var txt = context.GetText().Substring(1);

            if (context.URI() != null)
                return new JsltConstant() { Value = typeof(Uri), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (context.TIME() != null)
                return new JsltConstant() { Value = typeof(TimeSpan), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (context.DATETIME() != null)
                return new JsltConstant() { Value = typeof(DateTime), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (context.STRING_() != null)
                return new JsltConstant() { Value = typeof(string), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (context.GUID() != null)
                return new JsltConstant() { Value = typeof(Guid), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonValueNull([NotNull] JsltParser.JsonValueNullContext context)
        {
            return new JsltConstant() { Value = null, Kind = JsltKind.Null, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
        }

        public override object VisitPair([NotNull] JsltParser.PairContext context)
        {

            var name = context.STRING().GetText().Trim().Trim('\"');

            JsltBase value = (JsltBase)context.jsonValue().Accept(this);

            if (name.StartsWith("@"))
                return new JsltVariable() { Name = name.Substring(1), Value = value, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            else if (name.ToLower() == "$culture" && value is JsltConstant culture)
            {

                if (culture.Value is string t)
                    this._currentCulture = CultureInfo.GetCultureInfo(t);

                else if (culture.Value is int i)
                    this._currentCulture = CultureInfo.GetCultureInfo(i);

            }

            return new JsltProperty() { Name = name, Value = value, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

        }

        //public override object VisitJsonValueCodeString([NotNull] JsltParser.JsonValueCodeStringContext context)
        //{

        //    var code = context.CODE_STRING().GetText().Trim('\'');

        //    List<int> lst = new List<int>()
        //    {
        //        code.IndexOf(' '),
        //        code.IndexOf('\t'),
        //        code.IndexOf('\r'),
        //        code.IndexOf('\n'),
        //    };

        //    var index = lst.Where(c => c != -1).Min();

        //    var l = code.Substring(0, index);
        //    var c = code.Substring(index).Trim();

        //    return AddPosition(new JfunctionBodyDefinition(l, c), context.Start, context.Stop);

        //}

        #region Jsonlt

        public override object VisitJsonLtOperation([NotNull] JsltParser.JsonLtOperationContext context)
        {

            JsltBase left = null;

            var ltItem = context.jsonLtItem();
            if (ltItem != null)
            {
                var item = (JsltBase)ltItem.Accept(this);
                if (context.NT() == null)
                    left = item;
                else
                    left = new JsltOperator(item, OperationEnum.Not) { Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            }

            var right_operation = context.jsonLtOperation();

            if (right_operation != null)
            {

                var operationRight = (JsltBase)right_operation.Accept(this);

                if (context.PAREN_LEFT() == null)
                {
                    var operation = (OperationEnum)context.operation().Accept(this);
                    return new JsltBinaryOperator(left, operation, operationRight) { Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
                }

                //return AddPosition(new JSubExpression(context.GetText(), left), context.Start, context.Stop);
                //return new JsltConstant() { Value = typeof(string), Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

                return left;

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

            var expression = (JsltBase)context.jsonWhenExpression().Accept(this);

            JsltBase d = null;
            var defaultCase = context.jsonDefaultCase();
            if (defaultCase != null)
                d = (JsltBase)defaultCase.Accept(this);

            var result = new JsltSwitch() { Expression = expression, Default = d, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            var cases = context.jsonCase();

            foreach (var @case in cases)
                result.Cases.Add((JsltCase)@case.Accept(this));

            return result;

        }

        public override object VisitJsonCase([NotNull] JsltParser.JsonCaseContext context)
        {
            var expression = (JsltBase)context.jsonWhenExpression().Accept(this);
            var content = (JsltBase)context.jsonValue().Accept(this);
            return new JsltCase() { RightExpression = expression, Block = content, Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };
        }

        public override object VisitJsonDefaultCase([NotNull] JsltParser.JsonDefaultCaseContext context)
        {
            var content = (JsltBase)context.jsonValue().Accept(this);
            return content;
        }

        public override object VisitJsonfunctionCall([NotNull] JsltParser.JsonfunctionCallContext context)
        {

            var name = context.ID().ToString();
            List<JsltBase> argumentsJson = new List<JsltBase>();
            var arguments = context.jsonValueList();
            if (arguments != null)
                argumentsJson.AddRange((List<JsltBase>)arguments.Accept(this));

            var result = new JsltFunctionCall(name, argumentsJson) { Start = context.Start.ToLocation(), Stop = context.Start.ToLocation() };

            this._functions.Add(result);

            return result;

        }

        private Type[] ResolveArgumentsTypes(JsltFunctionCall n)
        {

            var c = n.Arguments;
            List<Type> _types = new List<Type>(10);
            foreach (var item in c)
            {
                if (item.Value is JsltFunctionCall ctor)
                {
                    Stop();
                    var types = ResolveArgumentsTypes(ctor);
                    var service = this._foundry.GetService(ctor.Name, types);


                }
                else if (item.Value is JsltConstant v)
                    _types.Add(v.Type);

                else if (item.Value is JsltPath p)
                    _types.Add(typeof(JToken));

                else if (item.Value is JsltTranslateVariable t)
                    _types.Add(typeof(JToken));

                else
                {
                    Stop();

                }
            }

            return _types.ToArray();

        }

        public override object VisitJsonValueList([NotNull] JsltParser.JsonValueListContext context)
        {

            List<JsltBase> result = new List<JsltBase>();
            var items = context.jsonValue();

            foreach (var item in items)
                result.Add((JsltBase)item.Accept(this));

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
                    AddError(e);

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

        public IEnumerable<ErrorModel> Errors { get => this._errors; }

        public string Filename { get; set; }

        public uint Crc { get; set; }
        public CultureInfo Culture { get => _currentCulture; }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        #region load files

        private void LoadAssemblyFromCs(List<FileInfo> sources)
        {

            var assembly = CSharp.GetAssembly(sources.Select(c => c.FullName).ToArray());

            if (!assembly.Success)
            {

                foreach (DiagnosticResult diagnostic in assembly.Disgnostics)
                {
                    var location = new TokenLocation(diagnostic.Locations.FirstOrDefault()) { };
                    AddError(location, diagnostic.Message, diagnostic.Message);
                }

                Stop();

            }

            this._foundry.AddAssembly(assembly.AssemblyFile);

        }

        private void LoadAssembly(List<FileInfo> sources)
        {
            foreach (var file in sources)
                this._foundry.AddAssembly(file.FullName);
        }

        private void CollectLib(string u, List<FileInfo> dll, JsltBase item)
        {
            var file = ResolveFile(u);
            if (file.Exists)
            {

                if (file.Extension == ".dll")
                    dll.Add(file);

                else if (file.Extension == ".exe")
                    dll.Add(file);

            }
            else
                AddError(item.Start, u, $"Failed to local file at position {item.Start.StartIndex}, line {item.Start.Line}, col {item.Start.Column} '{u}'");

        }

        private void CollectCs(string u, List<FileInfo> cs, JsltBase item)
        {
            var file = ResolveFile(u);
            if (file.Exists)
            {
                if (file.Extension == ".cs")
                    cs.Add(file);
            }
            else
                AddError(item.Start, u, $"Failed to local file at position {item.Start.StartIndex}, line {item.Start.Line}, col {item.Start.Column} '{u}'");

        }





        private FileInfo ResolveFile(string u)
        {
            var file = new FileInfo(u);

            if (!file.Exists)
            {
                if (!string.IsNullOrEmpty(this._scriptPath))
                    file = new FileInfo(Path.Combine(this._configuration.Path, this._scriptPath));

                if (!file.Exists)
                {
                    if (!string.IsNullOrEmpty(this._configuration.Path))
                        file = new FileInfo(Path.Combine(this._configuration.Path, u));
                }
            }

            return file;

        }

        #endregion load files


        void AddError(TokenLocation start, string txt, string message, string path = null)
        {
            this._errors.Add(new ErrorModel()
            {
                Filename = path ?? Filename,
                Line = start.Line,
                StartIndex = start.StartIndex,
                Column = start.Column,
                Text = txt,
                Message = message,
            });
        }

        void AddError(ErrorNodeImpl e)
        {
            this._errors.Add(new ErrorModel()
            {
                Filename = Filename,
                Line = e.Symbol.Line,
                StartIndex = e.Symbol.StartIndex,
                Column = e.Symbol.Column,
                Text = e.Symbol.Text,
                Message = $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} '{e.Symbol.Text}'"
            });
        }

        private StringBuilder _initialSource;
        private List<ErrorModel> _errors;
        private readonly FunctionFoundry _foundry;
        private readonly string _scriptPath;
        private TranformJsonAstConfiguration _configuration;
        private CultureInfo _currentCulture;
        private List<JsltFunctionCall> _functions;

    }

}
