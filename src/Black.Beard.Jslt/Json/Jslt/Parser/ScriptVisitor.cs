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
        public ScriptVisitor(TranformJsonAstConfiguration configuration, Diagnostics diagnostics, string path = null)
        {
            this._diagnostics = diagnostics;
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
                Factory service = this._foundry.GetService(item.Name, types, this._diagnostics, context.Start.ToLocation());
                if (service == null)
                {
                    LocalDebug.Stop();
                    AddError(item.Start, string.Empty, $"the service {item.Name} can't be resolved.");
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


            var result = new JsltObject() { Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            var items = context.pair();

            foreach (var item in items)
            {

                var prop = (JsltProperty)item.Accept(this);
                if (prop == null)
                {

                }
                else if (prop.Name.StartsWith("$"))
                {

                    if (prop.Name.ToLower() == "$functions")
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

                    else if (prop.Name.ToLower() == "$assemblies")
                    {

                        var assemblies = new List<string>();

                        if (prop.Value is JsltArray ar)
                            foreach (JsltBase fu in ar.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is string str)
                                        assemblies.Add(str);

                        LoadAssembly(assemblies);

                    }

                    else if (prop.Name.ToLower() == "$imports")
                    {

                        var dll = new List<FileInfo>();

                        if (prop.Value is JsltArray ar)
                            foreach (JsltBase fu in ar.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is Uri u)
                                        CollectLib(u.AbsoluteUri, dll, fu);
                                    else if (v.Value is string str)
                                        CollectLib(str, dll, fu);

                        LoadAssembly(dll);

                    }

                    else if (prop.Name.ToLower() == "$source")
                        result.Source = prop.Value;

                    else if (prop.Name.ToLower() == "$where")
                    {
                        LocalDebug.Stop();
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
            var result = new JsltArray(items.Length) { Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

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
                    LocalDebug.Stop();
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
                    return new JsltConstant() { Value = (Int32)0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

                return new JsltConstant() { Value = o, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
            }

            return new JsltConstant() { Value = 0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

        }

        public override object VisitJsonValueBoolean([NotNull] JsltParser.JsonValueBooleanContext context)
        {
            return new JsltConstant() { Value = context.GetText().ToUpper() == "TRUE", Kind = JsltKind.Boolean, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
        }

        public override object VisitJsonValueNumber([NotNull] JsltParser.JsonValueNumberContext context)
        {

            string value = context.GetText();

            if (!string.IsNullOrEmpty(value))
            {

                if (value.Contains(this._currentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    var p = double.Parse(value, this._currentCulture);
                    return new JsltConstant() { Value = p, Kind = JsltKind.Float, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                }

                var o = Int64.Parse(value);
                return new JsltConstant() { Value = o, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            }

            return new JsltConstant() { Value = 0, Kind = JsltKind.Integer, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

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
                        var c = new JsltConstant() { Value = type, Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                        if (containsVariable)
                        {
                            var d = new JsltTranslateVariable(c);
                            args = new List<JsltBase>() { new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() }, d };

                        }
                        else
                            args = new List<JsltBase>() { new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() }, c };

                        var call = new JsltFunctionCall("convert", args);
                        this._functions.Add(call);
                        result = call;

                    }
                }
                else
                {
                    if (containsVariable)
                        result = new JsltTranslateVariable(new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() });
                    else
                        result = new JsltPath() { Value = txt, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

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
                    result = new JsltTranslateVariable(new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() });
                else
                    result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
            }

            return result;

        }

        private JsltConstant GetConstant(string txt, Type type, JsltParser.JsonValueStringContext context)
        {

            JsltConstant result;

            if (type == typeof(string))
                result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (type == typeof(Uri))
                result = new JsltConstant() { Value = new Uri(txt), Kind = JsltKind.Uri, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (type == typeof(TimeSpan))
                result = new JsltConstant() { Value = TimeSpan.Parse(txt, this._currentCulture), Kind = JsltKind.TimeSpan, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant() { Value = DateTime.Parse(txt, this._currentCulture), Kind = JsltKind.Date, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant() { Value = Guid.Parse(txt), Kind = JsltKind.Guid, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else
                result = new JsltConstant() { Value = txt, Kind = JsltKind.String, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            return result;

        }

        public override object VisitJsonType([NotNull] JsltParser.JsonTypeContext context)
        {

            var txt = context.GetText().Substring(1);

            if (context.URI() != null)
                return new JsltConstant() { Value = typeof(Uri), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.TIME() != null)
                return new JsltConstant() { Value = typeof(TimeSpan), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.DATETIME() != null)
                return new JsltConstant() { Value = typeof(DateTime), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.STRING_() != null)
                return new JsltConstant() { Value = typeof(string), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.GUID() != null)
                return new JsltConstant() { Value = typeof(Guid), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.INTEGER() != null)
                return new JsltConstant() { Value = typeof(Int64), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            else if (context.DECIMAL() != null)
                return new JsltConstant() { Value = typeof(decimal), Kind = JsltKind.Type, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonValueNull([NotNull] JsltParser.JsonValueNullContext context)
        {
            return new JsltConstant() { Value = null, Kind = JsltKind.Null, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
        }

        public override object VisitPair([NotNull] JsltParser.PairContext context)
        {

            var name = context.STRING()?.GetText().Trim().Trim('\"') ?? string.Empty;

            if (!string.IsNullOrEmpty(name))
            {

                JsltBase value = null;

                var _value = context.jsonValue();
                if (_value != null)
                {

                    value = (JsltBase)_value.Accept(this);

                    if (value == null)
                    {
                        AddError(context.Start.ToLocation(), string.Empty, $"invalid value for property {name}");
                        return null;
                    }
                    else
                    {

                        if (name.StartsWith("@"))
                            return new JsltVariable() { Name = name.Substring(1), Value = value, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

                        else if (name.ToLower() == "$culture" && value is JsltConstant culture)
                        {

                            if (culture.Value is string t)
                                this._currentCulture = CultureInfo.GetCultureInfo(t);

                            else if (culture.Value is int i)
                                this._currentCulture = CultureInfo.GetCultureInfo(i);

                        }

                    }

                }
                else
                {
                    //value = new JsltConstant() { Value = null, Kind = JsltKind.Null, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                    AddError(context.Start.ToLocation(), string.Empty, $"missing value for property {name}");
                    return null;
                }

                return new JsltProperty() { Name = name, Value = value, Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };

            }

            AddError(context.Start.ToLocation(), string.Empty, $"missing value for property {name}");
            return null;

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
                if (item != null)
                {
                    if (context.NT() == null)
                        left = item;
                    else
                        left = new JsltOperator(item, OperationEnum.Not) { Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                }

                else
                    return null;
            }

            OperationEnum operation = OperationEnum.Undefined;
            var ope = context.operation();
            if (ope != null)
                operation = (OperationEnum)ope.Accept(this);

            var right_operation = context.jsonLtOperation();
            if (right_operation != null)
            {

                var operationRight = (JsltBase)right_operation.Accept(this);
                if (operationRight == null)
                {
                    AddError(context.Start.ToLocation(), "", "missing binary right expression");
                    return null;
                }
                else
                {
                    if (context.PAREN_LEFT() == null)
                    {

                        return new JsltBinaryOperator(left, operation, operationRight) { Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                    }

                    return left;
                }

            }
            else if (operation != OperationEnum.Undefined)
            {
                AddError(context.Start.ToLocation(), "", "missing binary right expression");
                return null;
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

            else if (context.AND() != null)
                return OperationEnum.And;

            else if (context.AND_EXCLUSIVE() != null)
                return OperationEnum.AndExclusive;

            else if (context.OR() != null)
                return OperationEnum.Or;

            else if (context.OR_EXCLUSIVE() != null)
                return OperationEnum.OrExclusive;

            else if (context.COALESCE() != null)
                return OperationEnum.Coalesce;

            else if (context.CHAIN() != null)
                return OperationEnum.Chain;

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonLtItem([NotNull] JsltParser.JsonLtItemContext context)
        {

            var ctor = context.jsonfunctionCall();
            if (ctor != null)
                return ctor.Accept(this);

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

            var _null = context.jsonValueNull();
            if (_null != null)
                return _null.Accept(this);

            LocalDebug.Stop();

            return null;
        }

        public override object VisitJsonfunctionCall([NotNull] JsltParser.JsonfunctionCallContext context)
        {

            JsltBase result = null;
            JsltObject obj = null;

            var name = context.DOT_ID().ToString().TrimStart('.', ' ');
            List<JsltBase> argumentsJson = new List<JsltBase>();
            var arguments = context.jsonValueList();
            if (arguments != null)
                argumentsJson.AddRange((List<JsltBase>)arguments.Accept(this));


            var o = context.obj();
            if (o != null)
                obj = (JsltObject)o.Accept(this);

            switch (name.ToLower())
            {

                case "when":
                    if (obj == null)
                        AddError(context.Start.ToLocation(), string.Empty, $"missing case");

                    else
                    {
                        if (argumentsJson.Count != 1)
                            AddError(context.Start.ToLocation(), string.Empty, $"function when support only one argument");
                        else
                            result = BuildWhen(context, argumentsJson, obj);
                    }
                    break;

                default:
                    if (obj != null)
                        AddError(context.Start.ToLocation(), string.Empty, $"invalid object argument");

                    else
                    {
                        var call = new JsltFunctionCall(name, argumentsJson) { Start = context.Start.ToLocation(), Stop = context.Stop.ToLocation() };
                        this._functions.Add(call);
                        result = call;
                    }
                    break;
            }

            return result;

        }

        private JsltBase BuildWhen(JsltParser.JsonfunctionCallContext context, List<JsltBase> argumentsJson, JsltObject obj)
        {

            JsltBase d = null;

            var result = new JsltSwitch()
            {
                Expression = argumentsJson[0],
                Default = d,
                Start = context.Start.ToLocation(),
                Stop = context.Stop.ToLocation()
            };

            foreach (var @case in obj.Properties)
            {
                if (@case.Name.ToLower() == "default")
                    result.Default = @case.Value;

                else
                {
                    var expression = new JsltConstant() { Value = @case.Name, Kind = JsltKind.String, Start = @case.Start, Stop = @case.Stop };
                    var c = new JsltCase() { RightExpression = expression, Block = @case.Value, Start = @case.Start, Stop = @case.Stop };
                    result.Cases.Add(c);
                }

            }

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
                    LocalDebug.Stop();
                    var types = ResolveArgumentsTypes(ctor);
                    var service = this._foundry.GetService(ctor.Name, types, this._diagnostics, n.Start);
                    if (service == null)
                    {
                        _diagnostics.AddError(null, n.Start, item.Name, $" service {item.Name} not found");
                    }
                    else
                    {

                        LocalDebug.Stop();

                    }

                }
                else if (item.Value is JsltConstant v)
                    _types.Add(v.Type);

                else if (item.Value is JsltPath p)
                    _types.Add(typeof(JToken));

                else if (item.Value is JsltTranslateVariable t)
                    _types.Add(typeof(JToken));

                else
                {
                    LocalDebug.Stop();

                }
            }

            return _types.ToArray();

        }

        public override object VisitJsonValueList([NotNull] JsltParser.JsonValueListContext context)
        {

            List<JsltBase> result = new List<JsltBase>();
            var items = context.jsonValue();

            foreach (var item in items)
            {
                var r = (JsltBase)item.Accept(this);
                if (r != null)
                    result.Add(r);
            }

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
            EvaluateErrors(tree);
            if (this._diagnostics.Count > 0)
                LocalDebug.Stop();
            var result = base.Visit(tree);

            return result;

        }

        public IEnumerable<ErrorModel> Errors { get => this._diagnostics; }

        public string Filename { get; set; }

        public uint Crc { get; set; }
        public CultureInfo Culture { get => _currentCulture; }

        #region load files

        private void LoadAssemblyFromCs(List<FileInfo> sources)
        {

            var assembly = CSharp.GetAssembly(sources.Select(c => c.FullName).ToArray());

            if (!assembly.Success)
            {

                foreach (DiagnosticResult diagnostic in assembly.Disgnostics)
                {
                    var location = new TokenLocation(diagnostic.Locations.FirstOrDefault()) { };
                    if (diagnostic.IsWarningAsError)
                        AddError(location, diagnostic.Message, diagnostic.Message);

                    else
                    {
                        switch (diagnostic.Severity)
                        {

                            default:
                                LocalDebug.Stop();
                                AddWarning(location, diagnostic.Message, diagnostic.Message);
                                break;

                        }
                    }
                }

                LocalDebug.Stop();

            }

            this._foundry.AddAssembly(assembly.AssemblyFile);

        }

        private void LoadAssembly(List<FileInfo> sources)
        {
            foreach (var file in sources)
                this._foundry.AddAssembly(file.FullName);
        }

        private void LoadAssembly(List<string> sources)
        {
            foreach (var assembly in sources)
                this._foundry.AddAssemblyName(assembly);

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
                    file = this._configuration.ResolveFile(this._scriptPath);

                if (!file.Exists)
                    file = this._configuration.ResolveFile(u);

            }

            return file;

        }

        #endregion load files


        void AddError(TokenLocation start, string txt, string message, string path = null)
        {
            this._diagnostics
                .AddError(
                    path ?? Filename,
                    start.Line,
                    start.StartIndex,
                    start.Column,
                    txt,
                    message
            );
        }

        void AddWarning(TokenLocation start, string txt, string message, string path = null)
        {
            this._diagnostics
                .AddWarning(
                    path ?? Filename,
                    start.Line,
                    start.StartIndex,
                    start.Column,
                    txt,
                    message
            );

        }

        void AddError(ErrorNodeImpl e)
        {
            this._diagnostics
                .AddError(
                    Filename,
                    e.Symbol.Line,
                    e.Symbol.StartIndex,
                    e.Symbol.Column,
                    e.Symbol.Text,
                    $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} '{e.Symbol.Text}'"
            );
        }



        private StringBuilder _initialSource;
        private Diagnostics _diagnostics;
        private readonly FunctionFoundry _foundry;
        private readonly string _scriptPath;
        private TranformJsonAstConfiguration _configuration;
        private CultureInfo _currentCulture;
        private List<JsltFunctionCall> _functions;

    }

}
