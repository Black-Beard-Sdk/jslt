using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Analysis.DiagTraces;
using Bb.Compilers;
using Bb.ComponentModel;
using Bb.ComponentModel.Factories;
using Bb.Json.Attributes;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Builds;
using Bb.Json.Jslt.Services;
using Microsoft.CodeAnalysis;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

#pragma warning disable CS3001
#pragma warning disable CS3003

namespace Bb.Json.Jslt.Parser
{

    public class ScriptBuilderVisitor : JsltParserBaseVisitor<object>
    {

        /// <summary>
        /// Create a new instance of <see cref="ScriptBuilderVisitor"/>
        /// </summary>
        /// <param name="culture"></param>
        public ScriptBuilderVisitor(TranformJsonAstConfiguration configuration, JsltParser parser, ScriptDiagnostics diagnostics, string path)
        {
            this._parser = parser;
            this._diagnostics = diagnostics;
            this._scriptPath = path;

            if (!string.IsNullOrEmpty(path))
                this._scriptPathDirectory = new FileInfo(path).Directory.FullName;
            else
                this._scriptPathDirectory = AppDomain.CurrentDomain.BaseDirectory;

            this._configuration = configuration;
            this._currentCulture = _configuration.Culture;
            this._functions = new List<JsltFunctionCall>();
            this._foundry = new ServiceFunctionFoundry(this._configuration);
        }

        public ServiceFunctionFoundry Foundry { get => this._foundry; }

        /// <summary>
        /// Parse tree produced by <see cref="JsltParser.script"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitScript([NotNull] JsltParser.ScriptContext context)
        {

            this._initialSource = new StringBuilder(context.Start.InputStream.ToString());

            // parse document
            var result = context.json().Accept(this);

            // resolve functions
            foreach (var item in this._functions)
            {

                var types = ResolveArgumentsTypes(item);
                Factory service;

                if (this.OutputConfiguration != null && item == this.OutputConfiguration.Function)
                    service = this._foundry.GetService(FunctionKindEnum.Output, item.Name, types, this._diagnostics, context.ToLocation());

                else if (this.OutputConfiguration != null && item == this.OutputConfiguration.Writer)
                    service = this._foundry.GetService(FunctionKindEnum.Writer, item.Name, types, this._diagnostics, context.ToLocation());

                else
                    service = this._foundry.GetService(FunctionKindEnum.FunctionStandard, item.Name, types, this._diagnostics, context.ToLocation());

                if (service == null)
                    AddError(item.Location, string.Empty, $"the service {item.Name} can't be resolved.");

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


            var result = new JsltObject() { Location = context.ToLocation() };

            var items = context.pair();

            foreach (var item in items)
            {

                var prop = (JsltProperty)item.Accept(this);
                if (prop == null)
                {

                }
                else if (prop.Name.StartsWith("$") && prop.Name != "$directives")
                {

                    if (prop.Name.StartsWith("$$"))
                    {
                        prop.Name = prop.Name.Substring(1);

                        if (result.Properties.Any(c => c.Name == prop.Name))
                            AddError(prop.Location, "Semantic error", $"the property name '{prop.Name}' already exists");
                        else
                            result.Append(prop);
                    }

                    else if (prop.Name == "$" || prop.Name.ToLower() == "$source")
                        result.Source = prop.Value;

                    else if (prop.Name.ToLower() == "?" || prop.Name.ToLower() == "$where")
                        result.Where = prop.Value;

                }

                else
                {
                    if (result.Properties.Any(c => c.Name == prop.Name))
                        AddError(prop.Location, "Semantic error", $"the property name '{prop.Name}' already exists");
                    else
                        result.Append(prop);
                }
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
            var result = new JsltArray(items.Length) { Location = context.ToLocation() };

            foreach (var item in items)
            {
                var itemResult = item.Accept(this);

                if (itemResult is JsltBase t)
                    result.Items.Add(t);

                else if (itemResult is string s)
                    result.Items.Add(new JsltConstant(s, JsltKind.String) { Location = item.ToLocation() });

                else if (itemResult is float f)
                    result.Items.Add(new JsltConstant(f, JsltKind.Float) { Location = item.ToLocation() });

                else if (itemResult is double d)
                    result.Items.Add(new JsltConstant(d, JsltKind.Float) { Location = item.ToLocation() });

                else if (itemResult is int i)
                    result.Items.Add(new JsltConstant(i, JsltKind.Integer) { Location = item.ToLocation() });

                else if (itemResult is long l)
                    result.Items.Add(new JsltConstant(l, JsltKind.Integer) { Location = item.ToLocation() });

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
                    return new JsltConstant((Int32)0, JsltKind.Integer) { Location = context.ToLocation() };

                return new JsltConstant(o, JsltKind.Integer) { Location = context.ToLocation() };
            }

            JsltBase result = new JsltConstant(0, JsltKind.Integer) { Location = context.ToLocation() };

            result = GetConverter(context.jsonType(), result, out Type type);

            return result;

        }

        public override object VisitJsonValueBoolean([NotNull] JsltParser.JsonValueBooleanContext context)
        {

            JsltBase result = new JsltConstant(context.GetText().ToUpper() == "TRUE", JsltKind.Boolean) { Location = context.ToLocation() };

            result = GetConverter(context.jsonType(), result, out Type type);

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
                    return new JsltConstant(p, JsltKind.Float) { Location = context.ToLocation() };
                }

                var o = Int64.Parse(value);
                return new JsltConstant(o, JsltKind.Integer) { Location = context.ToLocation() };

            }

            JsltBase result = new JsltConstant(0, JsltKind.Integer) { Location = context.ToLocation() };

            result = GetConverter(context.jsonType(), result, out Type type);

            return result;

        }

        public override object VisitVariable([NotNull] JsltParser.VariableContext context)
        {

            var txt = context.VARIABLE_NAME().GetText();
            
            JsltBase result = new JsltVariable() { Name = txt.Substring(1), Location = context.ToLocation() };

            var jsonType = context.jsonType();
            if (jsonType != null)
            {
                var type = ((JsltConstant)jsonType.Accept(this)).Value as Type;

                result = GetConverter(context.jsonType(), result, out Type type2);

            }

            //var result = new JsltTranslateVariable(GetConstant(txt, type, context));
            return result;

        }

        public override object VisitString([NotNull] JsltParser.StringContext context)
        {
            ITerminalNode str = context.STRING();
            if (str != null)
            {
                var txt = str.GetText()?.Trim() ?? string.Empty;
                return txt;
            }

            var str2 = context.STRING2();
            if (str2 != null)
            {
                var txt = str2.GetText()?.Trim() ?? string.Empty;
                return txt;
            }

            return string.Empty;

        }

        public override object VisitJsonValueString([NotNull] JsltParser.JsonValueStringContext context)
        {

            JsltBase result = null;
            Type type = typeof(string);
            bool forceText = false;

            #region 

            var txt = (string)VisitString(context.@string());

            if (txt.StartsWith(@"$"""))
            {
                txt = txt.Substring(1, txt.Length - 1);
                forceText = true;
            }

            if (txt.StartsWith(@"""") && txt.EndsWith(@""""))
                txt = txt.Substring(1, txt.Length - 2);

            StringBuilder sb = new StringBuilder(txt.Length + 10);
            for (int i = 0; i < txt.Length; i++)
            {

                var c = txt[i];

                if (c == '\\')
                {
                    c = txt[++i];
                    switch (c)
                    {

                        case '\\':
                            sb.Append(c);
                            break;

                        case '\"':
                            sb.Append(c);
                            break;

                        case '\t':
                            LocalDebug.Stop();
                            sb.Append(c);
                            break;

                        case '\n':
                            LocalDebug.Stop();
                            sb.Append(c);
                            break;

                        case '\r':
                            LocalDebug.Stop();
                            sb.Append(c);
                            break;

                        default:
                            LocalDebug.Stop();
                            break;
                    }

                }
                else
                    sb.Append(c);

            }

            txt = sb.ToString();

            #endregion 

            var containsVariable = txt.Contains("@@");

            var jsonType = context.jsonType();
            if (jsonType != null)
                type = ((JsltConstant)jsonType.Accept(this)).Value as Type;

            if (!forceText && txt.StartsWith("$")) // Convert text in jsonpath
            {

                result = new JsltPath() { Value = txt, Location = context.ToLocation() };

                if (type != typeof(string))
                {

                    List<JsltBase> args = null;
                    var c = new JsltConstant(type, JsltKind.Type) { Location = context.ToLocation() };

                    if (containsVariable)
                        args = new List<JsltBase>() { result, new JsltTranslateVariable(c) };
                    else
                        args = new List<JsltBase>() { result, c };

                    var call = new JsltFunctionCall("convert", args) { Location = context.ToLocation() };
                    this._functions.Add(call);
                    result = call;

                }
                else if (containsVariable) // Path without conversion
                {
                    result = new JsltTranslateVariable(result);
                }

            }

            else
            {
                // Text with conversion
                if (containsVariable)
                    result = new JsltTranslateVariable(GetConstant(txt, type, context));
                else
                    result = GetConstant(txt, type, context);
            }

            return result;

        }

        private JsltConstant GetConstant(string txt, Type type, ParserRuleContext context)
        {

            JsltConstant result;

            if (type == typeof(string))
                result = new JsltConstant(txt, JsltKind.String) { Location = context.ToLocation() };

            else if (type == typeof(Uri))
                result = new JsltConstant(new Uri(txt), JsltKind.Uri) { Location = context.ToLocation() };

            else if (type == typeof(TimeSpan))
                result = new JsltConstant(TimeSpan.Parse(txt, this._currentCulture), JsltKind.TimeSpan) { Location = context.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant(DateTime.Parse(txt, this._currentCulture), JsltKind.Date) { Location = context.ToLocation() };

            else if (type == typeof(DateTime))
                result = new JsltConstant(Guid.Parse(txt), JsltKind.Array) { Location = context.ToLocation() };

            else if (type == typeof(bool))
                result = new JsltConstant(InternalConverters.ToBoolean(txt), JsltKind.Guid) { Location = context.ToLocation() };

            else
                result = new JsltConstant(txt, JsltKind.String) { Location = context.ToLocation() };

            return result;

        }

        public override object VisitJsonType([NotNull] JsltParser.JsonTypeContext context)
        {

            var lowcase = context.IDLOWCASE();
            if (lowcase != null)
            {

                LocalDebug.Stop();

            }

            var txt = context.GetText().Substring(1);

            if (context.URI_TYPE() != null)
                return new JsltConstant(typeof(Uri), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.TIME_TYPE() != null)
                return new JsltConstant(typeof(TimeSpan), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.DATETIME_TYPE() != null)
                return new JsltConstant(typeof(DateTime), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.STRING_TYPE() != null)
                return new JsltConstant(typeof(string), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.GUID_TYPE() != null)
                return new JsltConstant(typeof(Guid), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.INTEGER_TYPE() != null)
                return new JsltConstant(typeof(Int64), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.DECIMAL_TYPE() != null)
                return new JsltConstant(typeof(decimal), JsltKind.Type) { Location = context.ToLocation() };

            else if (context.BOOLEAN_TYPE() != null)
                return new JsltConstant(typeof(bool), JsltKind.Type) { Location = context.ToLocation() };

            throw new NotImplementedException(context.GetText());

        }

        public override object VisitJsonValueNull([NotNull] JsltParser.JsonValueNullContext context)
        {
            return new JsltConstant(null, JsltKind.Null) { Location = context.ToLocation() };
        }

        public override object VisitPair([NotNull] JsltParser.PairContext context)
        {

            var txt = (string)VisitString(context.@string());
            var name = txt?.Trim().Trim('\"');

            if (!string.IsNullOrEmpty(name))
            {

                Dictionary<string, JsltMetadata> metadatas = BuildMetadatas(context, ref name);

                JsltBase value = null;

                var _value = context.jsonValue();
                if (_value != null)
                {

                    value = (JsltBase)_value.Accept(this);

                    if (value == null)
                    {
                        AddError(context.ToLocation(), string.Empty, $"invalid value for property {name}");
                        return null;
                    }
                    else
                    {

                        if (name.StartsWith("@"))
                            return new JsltVariable() { Name = name.Substring(1), Value = value, Location = context.ToLocation() };


                        else if (name.ToLower() == "$directives" && value is JsltObject directives)
                        {
                            ParseDirectives(directives);
                            return new JsltDirectives() { Value = value, Location = context.ToLocation() };
                        }
                        else if (name.StartsWith("$") && name != "$" && name != "$where")
                        {
                            AddWarning(value.Location, "syntax", $"{name} is not recognized.");
                        }
                    }

                }
                else
                {
                    AddError(context.ToLocation(), string.Empty, $"missing value for property {name}");
                    return null;
                }

                var result = new JsltProperty() { Name = name, Value = value, Location = context.ToLocation() };

                foreach (var item in metadatas)
                    result.AddMetadata(item.Key, item.Value);

                return result;

            }

            AddError(context.ToLocation(), string.Empty, $"missing value for property {name}");
            return null;

        }

        private Dictionary<string, JsltMetadata> BuildMetadatas(JsltParser.PairContext context, ref string name)
        {
            Dictionary<string, JsltMetadata> metadatas = new Dictionary<string, JsltMetadata>();
            if (name.Contains(";"))
            {

                var start = context.Start;
                var startIndex = start.StartIndex;

                var array = name.Split(';');
                name = array[0];
                startIndex += name.Length + 2;

                for (int i = 1; i < array.Length; i++)
                {

                    var lastIndex = startIndex;

                    var payload = array[i].Split(":");

                    if (metadatas.TryGetValue(payload[0], out var v))
                    {
                        var location = TextLocation.Create((start.Line, start.Column, startIndex), payload.Length);
                        AddError(location, string.Empty, $"duplicated value on metadata key {payload[0]}");
                    }
                    else
                    {

                        var metaKey = payload[0];
                        JToken prop = null;

                        if (payload.Length == 1)
                        {
                            var location = TextLocation.Create((start.Line, start.Column, startIndex), startIndex + payload.Length);
                            AddError(location, "Failed to parse json", $"The conversion of {metaKey} in Json value failed.The charset separator is ':'");
                        }
                        else
                        {

                            startIndex += metaKey.Length;
                            var payloadValue = payload[1].Replace("'", @"""");
                            try
                            {
                                prop = JToken.Parse(payloadValue);
                            }
                            catch (Exception)
                            {
                                var location = TextLocation.Create((start.Line, start.Column, startIndex), startIndex + payload.Length);
                                AddError(location, "Failed to parse json", $"The conversion of {payloadValue} in Json value failed");
                            }
                            startIndex += payloadValue.Length;
                            if (prop != null)
                            {
                                var location = TextLocation.Create((start.Line, start.Column, startIndex), lastIndex);
                                metadatas.Add(metaKey, new JsltMetadata(prop) { Location = location });
                            }
                        }

                    }

                    startIndex += payload.Length + 1;

                }

            }

            return metadatas;
        }


        #region Jsonslt

        public override object VisitJsonLtOperation([NotNull] JsltParser.JsonLtOperationContext context)
        {

            JsltBase left = null;

            var subOperation = context.jsonLtOperation();

            var ltItem = context.jsonLtItem();
            if (ltItem != null)
                left = (JsltBase)ltItem.Accept(this);

            else if (subOperation != null)
                left = (JsltBase)subOperation.Accept(this);

            if (context.NT() != null)
                left = new JsltOperator(left, OperationEnum.Not) { Location = context.ToLocation() };

            var typeConverter = context.jsonType();
            left = GetConverter(typeConverter, left, out Type type);

            return left;

        }

        public override object VisitJsonLtOperations([NotNull] JsltParser.JsonLtOperationsContext context)
        {

            var subOperations = context.jsonLtOperation();
            var operations = context.operation();

            Queue<JsltBase> _subs = new Queue<JsltBase>(subOperations.Length);
            foreach (var item in subOperations)
                _subs.Enqueue((JsltBase)item.Accept(this));

            Queue<OperationEnum> _opss = new Queue<OperationEnum>(operations.Length);
            foreach (var ope in operations)
                _opss.Enqueue((OperationEnum)ope.Accept(this));

            JsltBase left = null;
            JsltBase l = _subs.Dequeue();

            Stack<JsltBase> _pile = new Stack<JsltBase>(_subs.Count);
            Stack<OperationEnum> _pile2 = new Stack<OperationEnum>(_opss.Count);

            _pile.Push(l);

            while (_opss.Count > 0)
            {

                if (_subs.Count == 0)
                {
                    AddError(context.ToLocation(), string.Empty, "missing binary right expression");
                    return null;
                }

                var right = _subs.Dequeue();
                OperationEnum operation = _opss.Dequeue();

                if (operation == OperationEnum.Chain)
                {
                    if (right is JsltFunctionCall f)
                    {
                        f.Inject(left, 0);
                        left = right;
                    }
                    else
                    {
                        LocalDebug.Stop();
                        left = new JsltBinaryOperator(left, operation, right) { Location = context.ToLocation() };
                    }
                }
                else
                {

                    if (_opss.Count % 2 == 0)
                    {
                        l = _pile.Pop();
                        l = new JsltBinaryOperator(l, operation, right) { Location = context.ToLocation() };
                        _pile.Push(l);

                        if (_pile.Count % 2 == 0)
                        {

                            l = _pile.Pop();
                            operation = _pile2.Pop();
                            right = _pile.Pop();

                            l = new JsltBinaryOperator(l, operation, right) { Location = context.ToLocation() };

                            _pile.Push(l);

                        }

                    }
                    else
                    {
                        _pile.Push(right);
                        _pile2.Push(operation);
                    }

                }


            }

            left = _pile.Pop();

            if (context.NT() != null)
                left = new JsltOperator(left, OperationEnum.Not) { Location = context.ToLocation() };

            var typeConverter = context.jsonType();
            left = GetConverter(typeConverter, left, out Type type);

            return left;

        }

        private JsltBase GetConverter(JsltParser.JsonTypeContext jsonType, JsltBase left, out Type type)
        {

            type = typeof(void);

            if (jsonType != null)
            {

                type = ((JsltConstant)jsonType.Accept(this)).Value as Type;

                if (type == null)
                    LocalDebug.Stop();

                var c = new JsltConstant(type, JsltKind.Type) { Location = jsonType.ToLocation() };
                var call = new JsltFunctionCall("convert", new List<JsltBase>() { left, c }) { Location = jsonType.ToLocation() };
                this._functions.Add(call);
                left = call;
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

            var _jsonpath = context.jsltJsonpath();
            if (_jsonpath != null)
                return _jsonpath.Accept(this);

            var _variable = context.variable();
            if (_variable != null)
                return _variable.Accept(this);

            LocalDebug.Stop();

            return null;
        }

        public override object VisitJsonfunctionName([NotNull] JsltParser.JsonfunctionNameContext context)
        {
            return context.ID().ToString();
        }

        public override object VisitJsonfunctionCall([NotNull] JsltParser.JsonfunctionCallContext context)
        {

            JsltBase result = null;
            JsltObject obj = null;

            var name = (string)VisitJsonfunctionName(context.jsonfunctionName());
            List<JsltBase> argumentsJson = new List<JsltBase>();
            var arguments = context.jsonValueList();
            if (arguments != null)
                argumentsJson.AddRange((List<JsltBase>)arguments.Accept(this));

            var o = context.obj();
            if (o != null)
                obj = (JsltObject)o.Accept(this);

            switch (name.ToLower())
            {

                case "switch":
                case "when":
                    if (obj == null)
                        AddError(context.ToLocation(), string.Empty, $"missing case");

                    else
                    {
                        if (argumentsJson.Count != 1)
                            AddError(context.ToLocation(), string.Empty, $"function when support only one argument");
                        else
                            result = BuildWhen(context, argumentsJson, obj);
                    }
                    break;

                default:

                    if (obj != null)
                        AddError(context.ToLocation(), string.Empty, $"invalid object argument");

                    else
                    {
                        var call = new JsltFunctionCall(name, argumentsJson) { Location = context.ToLocation() };
                        this._functions.Add(call);

                        var type = context.jsonType();
                        if (type != null)
                        {
                            var c = new JsltConstant(type, JsltKind.Type) { Location = type.ToLocation() };
                            call = new JsltFunctionCall("convert", new List<JsltBase>() { call, c });
                            this._functions.Add(call);
                        }

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
                Location = context.ToLocation()
            };

            foreach (var @case in obj.Properties)
            {
                if (@case.Name.ToLower() == "default")
                    result.Default = @case.Value;

                else
                {
                    var expression = new JsltConstant(@case.Name, JsltKind.String) { Location = @case.Location };
                    var c = new JsltCase() { RightExpression = expression, Block = @case.Value, Location = @case.Location };
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
                    var types = ResolveArgumentsTypes(ctor);
                    var service = this._foundry.GetService(FunctionKindEnum.FunctionStandard, ctor.Name, types, this._diagnostics, n.Location);
                    if (service == null)
                    {
                        _diagnostics.AddError(n.Location, item.Name, $" service {item.Name} not found");
                    }
                    else
                    {
                        _types.Add(typeof(JToken));
                    }

                }
                else if (item.Value is JsltConstant v)
                    _types.Add(v.Type);

                else if (item.Value is JsltPath)
                    _types.Add(typeof(JToken));

                else if (item.Value is JsltVariable)
                    _types.Add(typeof(JToken));

                else if (item.Value is JsltTranslateVariable)
                    _types.Add(typeof(JToken));

                else if (item.Value is JsltBinaryOperator)
                    _types.Add(typeof(JToken));
                
                else if (item.Value is JsltObject)
                    _types.Add(typeof(JToken));
                
                else if (item.Value is JsltArray)
                    _types.Add(typeof(JArray));
                
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

        #endregion Jsonslt


        #region Jsonpath

        public override object VisitJsltJsonpath([NotNull] JsltParser.JsltJsonpathContext context)
        {

            var result = (JsltBase)context.jsonpath().Accept(this);

            var jsonType = context.jsonType();
            if (jsonType != null)
                result = GetConverter(jsonType, result, out Type type);

            var variable = context.VARIABLE_NAME();
            if (variable != null)
            {
                var variable_name = variable.GetText();
                variable_name = variable_name.Substring(1);
                result.Source = new JsltVariable(variable_name) { Location = context.ToLocation() };

            }

            return result;

        }

        public override object VisitJsonpath([NotNull] JsltParser.JsonpathContext context)
        {

            var txt = context.GetText();

            JsltBase result = new JsltPath() { Value = txt, Location = context.ToLocation() };

            var containsVariable = txt.Contains("@@");

            if (containsVariable)
                result = new JsltTranslateVariable(result);

            return result;


        }
             
        #endregion Jsonpath

        public void EvaluateErrors(IParseTree item)
        {

            if (item != null)
            {

                if (item is ErrorNodeImpl e)
                    AddError(e);

                else if (item is ParserRuleContext r)
                {

                    if (r.exception != null)
                    {
                        AddError(r);
                    }

                }

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
            //if (this._diagnostics.Count > 0)
            //    LocalDebug.Stop();
            var result = base.Visit(tree);

            return result;

        }

        public IEnumerable<ScriptDiagnostic> Errors { get => this._diagnostics; }

        public string Filename { get; set; }

        public uint Crc { get; set; }
        public CultureInfo Culture { get => _currentCulture; }
        public OutputModelConfiguration OutputConfiguration { get; private set; }


        #region load files

        private void LoadAssemblyFromCs(List<FileInfo> sources)
        {

            AssemblyResult assemblyDescription = CSharp.GetAssembly(sources.Select(c => c.FullName).ToArray());

            if (!assemblyDescription.Success)
            {

                foreach (ScriptDiagnostic diagnostic in assemblyDescription.Diagnostics)
                {

                    if (diagnostic.IsSeverityAsError)
                        AddError(diagnostic.Location, diagnostic.Message, diagnostic.Message);

                    else
                    {
                        switch (diagnostic.Severity)
                        {

                            default:
                                LocalDebug.Stop();
                                AddWarning(diagnostic.Location, diagnostic.Message, diagnostic.Message);
                                break;

                        }
                    }
                }

                LocalDebug.Stop();

            }

            // Add assembly to the service discovery for explore service to adding
            Assembly assembly = AssemblyLoader.Instance.LoadAssembly(assemblyDescription.AssemblyFile, System.Diagnostics.Debugger.IsAttached);
            var discovery = this._configuration.Services.ServiceDiscovery;
            discovery.AddAssembly(assembly);

        }

        private void LoadAssembly(List<FileInfo> sources)
        {

            var discovery = this._configuration.Services.ServiceDiscovery;

            foreach (var file in sources)
            {
                Assembly assembly = AssemblyLoader.Instance.LoadAssembly(file.FullName, System.Diagnostics.Debugger.IsAttached);
                discovery.AddAssembly(assembly);
            }

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
                AddError(item.Location, u, $"Failed : {item.ToString()} : '{u}'");

        }

        private void CollectPackages(JsltConstant rootUrl, List<FileInfo> packages, JsltConstant package)
        {

            var p = this._scriptPathDirectory;
            string packageName = package.Value as string;
            string url = rootUrl.Value as string;

            var folderLib = Packages
                    .EnsurePackageIsLoaded(url, packageName,
                        Path.Combine(this._scriptPathDirectory, "packages")
                    );

            foreach (var item in folderLib.GetFiles("*.dll"))
                packages.Add(item);

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
                AddError(item.Location, u, $"Failed : {item.ToString()} : '{u}'");

        }

        private FileInfo ResolveFile(string u)
        {
            var file = new FileInfo(u);

            if (!file.Exists)
                file = this._configuration.ResolveFile(u);

            return file;

        }

        #endregion load files


        void AddError(TextLocation start, string txt, string message, string path = null)
        {
            this._diagnostics.AddError(start.InDocument(path ?? Filename), txt, message);
        }

        void AddWarning(TextLocation start, string txt, string message, string path = null)
        {
            this._diagnostics.AddWarning(start.InDocument(path ?? Filename), txt, message);
        }

        void AddError(ParserRuleContext r)
        {

            int stateId = r.invokingState;

            if (stateId == -1)
                stateId = r.exception.OffendingState;

            ATNState state = this._parser.Atn.states[stateId];
            string o0 = this._parser.RuleNames[state.ruleIndex];
            string o1 = this._parser.RuleNames[r.RuleIndex];

            this._diagnostics.AddError(r.Start.ToLocation(Filename), r.Start.Text, $"Failed to parse script. '{o0}' expect '{o1}'");

        }

        void AddError(ErrorNodeImpl e)
        {
            this._diagnostics.AddError(e.Symbol.ToLocation(Filename), e.Symbol.Text,
                    $"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} '{e.Symbol.Text}'"
            );
        }

        #region directives

        private void ParseDirectives(JsltObject directives)
        {

            foreach (JsltProperty prop in directives.Properties)
            {

                switch (prop.Name.ToLower())
                {

                    case "output":
                        if (prop.Value is JsltObject output)
                        {

                            JsltFunctionCall modeFormat = null;
                            JsltPath filter = null;
                            JsltBase writer = null;

                            foreach (JsltProperty prop1 in output.Properties)
                                switch (prop1.Name.ToLower())
                                {
                                    case "mode":
                                        modeFormat = prop1.Value as JsltFunctionCall;
                                        break;

                                    case "write":
                                        writer = prop1.Value;
                                        break;

                                    case "filter":
                                        filter = prop1.Value as JsltPath;
                                        break;

                                    default:
                                        AddWarning(prop1.Location, "syntax", $"Not reconized property '{prop1.Name}' of $edirectives.");
                                        break;
                                }

                            if (modeFormat == null)
                                AddError(prop.Location, "syntax", $"The property 'mode' is required and expecte a function (to_json(), ...).");

                            this.OutputConfiguration = new OutputModelConfiguration()
                            {
                                Function = modeFormat,
                                Filter = filter,
                                Writer = writer,
                            };

                        }

                        break;

                    case "culture":
                        var _culture = prop.Value as JsltConstant;
                        if (_culture != null)
                        {
                            try
                            {

                                if (_culture.Value is string t)
                                    this._currentCulture = CultureInfo.GetCultureInfo(t);

                                else if (_culture.Value is int i)
                                    this._currentCulture = CultureInfo.GetCultureInfo(i);

                            }
                            catch (Exception)
                            {
                                AddError(prop.Location, "syntax", $"Culture can't be resolved. https://docs.microsoft.com/fr-fr/dotnet/api/system.globalization.cultureinfo.getcultureinfo");
                            }

                        }
                        break;

                    case "functions":
                        var cs = new List<FileInfo>();
                        if (prop.Value is JsltArray ar1)
                        {
                            foreach (JsltBase fu in ar1.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is Uri u)
                                        CollectCs(u.AbsoluteUri, cs, fu);
                                    else if (v.Value is string str && !string.IsNullOrEmpty(str))
                                        CollectCs(str, cs, fu);
                        }
                        else
                            AddError(prop.Location, "syntax", $"'functions' must to have an array of string with the filenames of scripts.");
                        LoadAssemblyFromCs(cs);
                        break;

                    case "assemblies":
                        var assemblies = new List<string>();
                        if (prop.Value is JsltArray ar2)
                        {
                            foreach (JsltBase fu in ar2.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is string str && !string.IsNullOrEmpty(str))
                                        assemblies.Add(str);
                        }
                        else
                            AddError(prop.Location, "syntax", $"'assemblies' must to have an array of string with the assemblies referenced in the Gac.");
                        LoadAssembly(assemblies);
                        break;

                    case "imports":
                        var dll1 = new List<FileInfo>();
                        if (prop.Value is JsltArray ar3)
                        {
                            foreach (JsltBase fu in ar3.Items)
                                if (fu is JsltConstant v)
                                    if (v.Value is Uri u)
                                        CollectLib(u.AbsoluteUri, dll1, fu);
                                    else if (v.Value is string str)
                                        CollectLib(str, dll1, fu);
                        }
                        else
                            AddError(prop.Location, "syntax", $"'imports' must to have an array of string with the filenames of libraries.");
                        LoadAssembly(dll1);
                        break;

                    case "packages":
                        var dll2 = new List<FileInfo>();
                        if (prop.Value is JsltArray ar4)
                        {
                            foreach (JsltBase fu in ar4.Items)
                            {
                                if (fu is JsltConstant packageName)
                                    CollectPackages(new JsltConstant(@"https://www.nuget.org/api/v2/package/", JsltKind.String) { }, dll2, packageName);

                                else if (fu is JsltArray ar5)
                                {
                                    if (ar5.Items.Count != 2)
                                        this._diagnostics.AddError(null, String.Empty, "the directives packages must to have two strings");

                                    else
                                    {
                                        CollectPackages(ar5.Items[0] as JsltConstant, dll2, ar5.Items[1] as JsltConstant);
                                    }
                                }
                                else
                                    this._diagnostics.AddError(null, String.Empty, "the directives packages accepts only array of string or an array of array of two strings.");
                            }
                        }
                        else
                            AddError(prop.Location, "syntax", $"'packages' must to have an array of string with the package names.");

                        LoadAssembly(dll2);
                        break;

                    default:
                        AddWarning(prop.Location, "syntax", $"Not recognized property '{prop.Name}' of $directives.");
                        break;
                }

            }

        }

        #endregion directives

        private StringBuilder _initialSource;
        private readonly JsltParser _parser;
        private ScriptDiagnostics _diagnostics;
        private readonly ServiceFunctionFoundry _foundry;
        private readonly string _scriptPath;
        private readonly string _scriptPathDirectory;
        private TranformJsonAstConfiguration _configuration;
        private CultureInfo _currentCulture;
        private List<JsltFunctionCall> _functions;

    }

}


