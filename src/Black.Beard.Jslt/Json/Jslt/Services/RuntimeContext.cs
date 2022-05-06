using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Bb.Json.Jslt.Services
{

    public class RuntimeContext
    {

        static RuntimeContext()
        {
            //_mapPropertyService = RuntimeContext.MapPropertyService;
            _getContentByJPath = RuntimeContext.GetContentByJPath;
            _getContentFromService = RuntimeContext.GetContentFromService;
            _evaluateUnaryOperator = RuntimeContext.EvaluateUnaryOperator;
            _evaluateBinaryOperator = RuntimeContext.EvaluateBinaryOperator;

            _addProperty = typeof(RuntimeContext).GetMethod("AddProperty", new Type[] { typeof(JObject), typeof(JProperty) });
            _convertToBool = typeof(RuntimeContext).GetMethod("ConvertToBool", new Type[] { typeof(JToken) });
            _properties = new Dictionary<Type, Dictionary<string, (PropertyInfo, Action<object, object>)>>();
            _convertToken = RuntimeContext.ConvertTo;
            _translateVariable = RuntimeContext.Translate;

            _setVariable = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.SetVariable), new Type[] { typeof(RuntimeContext), typeof(string), typeof(object), typeof(TokenLocation) });
            _DelVariable = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.DelVariable), new Type[] { typeof(RuntimeContext), typeof(string) });

            _TraceLocation = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.TraceLocation), new Type[] { typeof(RuntimeContext), typeof(string), typeof(int), typeof(int), typeof(int), typeof(int) });
            _ExitLocation = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.ExitLocation), new Type[] { typeof(RuntimeContext), typeof(object) });

            _ScriptProperty = typeof(RuntimeContext).GetProperty(nameof(RuntimeContext.ScriptFile));

        }

        internal RuntimeContext(Sources sources, Diagnostics diagnostic)
        {

            var d = diagnostic ?? new Diagnostics();
            this._watch = new Stopwatch();

            TokenSource = sources.Source.Datas;
            SubSources = sources;
            _diagnostics = d;

            this._stack = new Stack<MethodContext>();

        }


        public static object ExitLocation(RuntimeContext ctx, object result)
        {

            if (ctx._stack.Count > 0)
            {
                var e = ctx._stack.Pop();
                e.Watch.Stop();

                ctx.Diagnostics.AddInformation(ctx.ScriptFile, e.Trace, "Diagnostic", $"Elapsed time in {e.Trace.Function} seconde(s) {Math.Round(e.Watch.Elapsed.TotalSeconds, 4)}");

            }

            if (ctx._stack.Count > 0)
            {
                var p = ctx._stack.Peek();
                p.Watch.Stop();
                p.Watch.Restart();
            }

            return result;

        }


        public static RuntimeContext TraceLocation(RuntimeContext ctx, string functionName, int line, int column, int position, int positionEnd)
        {
            var e = new MethodContext()
            {
                Trace = new TokenLocation(position, positionEnd, line, column)
                {
                    Function = functionName,
                    ScriptFile = ctx.ScriptFile,
                }
            };
            ctx._stack.Push(e);

            e.Watch.Start();

            return ctx;
        }

        public string ScriptFile { get; private set; }

        public TokenLocation GetCurrentLocation()
        {
            if (this._stack.Count > 0)
                return this._stack.Peek().Trace;

            return new TokenLocation(0, 0, 0, 0);

        }

        #region methods called in the expressions

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public void Stop()
        {

            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();

            if (StopIsActivated && System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();

        }

        internal void Break()
        {
            this.MustoBreak = true;
        }

        #region Operators

        public static JToken EvaluateUnaryOperator(RuntimeContext ctx, JToken leftToken, OperationEnum @operator)
        {

            if (leftToken is JValue v)
            {
                if (v.Value is bool value)
                {
                    switch (@operator)
                    {
                        case OperationEnum.Not:
                            return new JValue(!value);

                        case OperationEnum.Equal:
                        case OperationEnum.GreaterThanOrEqual:
                        case OperationEnum.GreaterThan:
                        case OperationEnum.LessThanOrEqual:
                        case OperationEnum.LessThan:
                        case OperationEnum.NotEqual:
                        case OperationEnum.Add:
                        case OperationEnum.Subtract:
                        case OperationEnum.Divide:
                        case OperationEnum.Modulo:
                        case OperationEnum.Multiply:
                        case OperationEnum.Power:
                        case OperationEnum.Chain:
                        case OperationEnum.And:
                        case OperationEnum.AndExclusive:
                        case OperationEnum.Or:
                        case OperationEnum.OrExclusive:

                        default:
                            LocalDebug.Stop();
                            break;
                    }
                }
            }

            return leftToken;
        }

        public static JToken EvaluateBinaryOperator(RuntimeContext ctx, object leftToken, OperationEnum @operator, object rightToken)
        {

            JToken result = null;

            object l = null;
            object r = null;

            if (leftToken == null)
                l = null;

            else if (leftToken is JToken tokenLeft)
                l = GetValue(tokenLeft);

            else
                l = leftToken;

            if (rightToken == null)
                r = null;

            else if (rightToken is JToken tokenRight)
                r = GetValue(tokenRight);

            else
                r = rightToken;

            try
            {

                switch (@operator)
                {

                    case OperationEnum.Equal:
                        result = new JValue(Equal(l, r));
                        break;

                    case OperationEnum.GreaterThanOrEqual:
                        result = new JValue(GreaterThanOrEqual(l, r));
                        break;

                    case OperationEnum.GreaterThan:
                        result = new JValue(GreaterThan(l, r));
                        break;

                    case OperationEnum.LessThanOrEqual:
                        result = new JValue(LessThanOrEqual(l, r));
                        break;

                    case OperationEnum.LessThan:
                        result = new JValue(LessThan(l, r));
                        break;

                    case OperationEnum.NotEqual:
                        result = new JValue(NotEqual(l, r));
                        break;

                    case OperationEnum.Add:
                        result = new JValue(Add(l, r));
                        break;

                    case OperationEnum.Subtract:
                        result = new JValue(Substract(l, r));
                        break;

                    case OperationEnum.Divide:
                        result = new JValue(Divid(l, r));
                        break;

                    case OperationEnum.Modulo:
                        result = new JValue(Modulo(l, r));
                        break;

                    case OperationEnum.Multiply:
                        result = new JValue(Multiply(l, r));
                        break;

                    case OperationEnum.Power:
                        result = new JValue(Power(l, r));
                        break;

                    case OperationEnum.And:
                        result = new JValue(And(l, r));
                        break;

                    case OperationEnum.AndExclusive:
                        result = new JValue(AndExclusive(l, r));
                        break;

                    case OperationEnum.Or:
                        result = new JValue(Or(l, r));
                        break;

                    case OperationEnum.OrExclusive:
                        result = new JValue(OrExclusive(l, r));
                        break;

                    case OperationEnum.Chain:
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return result ?? JValue.CreateNull();

        }

        private static bool Equal(object l, object r)
        {

            if (l == null)
                return r == null;

            else if (l is string str)
                return str == (r?.ToString() ?? string.Empty);

            else if (l is bool bo)
                return bo == Convert.ToBoolean(r);

            else if (l is decimal left_deci)
                return left_deci == Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float == Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double == Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 == Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 == Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 == Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 == Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int == Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long == Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime == Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static bool NotEqual(object l, object r)
        {

            if (l == null)
                return r != l;

            else if (l is bool bo)
                return bo != Convert.ToBoolean(r);

            else if (l is string str)
                return str != (r?.ToString() ?? string.Empty);

            else if (l is decimal left_deci)
                return left_deci != Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float != Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double != Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 != Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 != Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 != Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 != Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int != Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long != Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime != Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static bool GreaterThanOrEqual(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci >= Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float >= Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double >= Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 >= Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 >= Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 >= Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 >= Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int >= Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long >= Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime >= Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Add(object l, object r)
        {

            if (l is string left_string)
                return string.Concat(left_string, r.ToString());

            else if (l is long left_long)
                return left_long + Convert.ToInt64(r);

            else if (l is decimal left_deci)
                return left_deci + Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float + Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double + Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 + Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 + Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 + Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 + Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int + Convert.ToInt64(r);

            //else if (l is DateTime dateTime)
            //    return dateTime..Add(Convert.ToDateTime(r));

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Substract(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci - Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float - Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double - Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 - Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 - Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 - Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 - Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int - Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long - Convert.ToInt64(r);

            //else if (l is DateTime dateTime)
            //    return dateTime..Add(Convert.ToDateTime(r));

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Modulo(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci % Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float % Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double % Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 % Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 % Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 % Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 % Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int % Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long % Convert.ToInt64(r);

            //else if (l is DateTime dateTime)
            //    return dateTime..Add(Convert.ToDateTime(r));

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Multiply(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci * Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float * Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double * Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 * Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 * Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 * Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 * Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int * Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long * Convert.ToInt64(r);

            //else if (l is DateTime dateTime)
            //    return dateTime..Add(Convert.ToDateTime(r));

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Power(object l, object r)
        {

            if (l is Int16 left_int16)
                return left_int16 ^ Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 ^ Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 ^ Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 ^ Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int ^ Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long ^ Convert.ToInt64(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object And(object l, object r)
        {

            if (l is Int16 left_int16)
                return left_int16 & Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 & Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 & Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 & Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int & Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long & Convert.ToInt64(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object AndExclusive(object l, object r)
        {

            if (l is bool left_int16)
                return left_int16 && Convert.ToBoolean(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object OrExclusive(object l, object r)
        {

            if (l is bool left_int16)
                return left_int16 && Convert.ToBoolean(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Or(object l, object r)
        {

            if (l is Int16 left_int16)
                return left_int16 | Convert.ToInt16(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 | Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 | Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 | Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int | Convert.ToInt32(r);

            else if (l is long left_long)
                return left_long | Convert.ToInt64(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static object Divid(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci / Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float / Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double / Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 / Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 / Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 / Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 / Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int / Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long / Convert.ToInt64(r);

            //else if (l is DateTime dateTime)
            //    return dateTime..Add(Convert.ToDateTime(r));

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static bool LessThanOrEqual(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci <= Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float <= Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double <= Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 <= Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 <= Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 <= Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 <= Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int <= Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long <= Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime <= Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static bool GreaterThan(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci > Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float > Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double > Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 > Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 > Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 > Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 > Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int > Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long > Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime > Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        private static bool LessThan(object l, object r)
        {

            if (l is decimal left_deci)
                return left_deci < Convert.ToDecimal(r);

            else if (l is float left_float)
                return left_float < Convert.ToSingle(r);

            else if (l is double left_double)
                return left_double < Convert.ToDouble(r);

            else if (l is Int16 left_int16)
                return left_int16 < Convert.ToInt64(r);

            else if (l is UInt16 left_uint16)
                return left_uint16 < Convert.ToUInt64(r);

            else if (l is UInt32 left_uint32)
                return left_uint32 < Convert.ToUInt64(r);

            else if (l is UInt64 left_uint64)
                return left_uint64 < Convert.ToUInt64(r);

            else if (l is int left_int)
                return left_int < Convert.ToInt64(r);

            else if (l is long left_long)
                return left_long < Convert.ToInt64(r);

            else if (l is DateTime dateTime)
                return dateTime < Convert.ToDateTime(r);

            else
            {
                LocalDebug.Stop();

            }

            return false;

        }

        #endregion Operators

        #region Variables

        public static void SetVariable(RuntimeContext ctx, string name, object value, TokenLocation trace)
        {
            ctx.SubSources.Variables.Add(name, value);
            if (value == null)
                ctx.Diagnostics.AddWarning(string.Empty, trace, name, $"the key '{name}' is setted with null value.");
        }

        public static void DelVariable(RuntimeContext ctx, string name)
        {
            ctx.SubSources.Variables.Del(name);
        }

        public static JToken Translate(RuntimeContext ctx, string text, string[] keys, TokenLocation trace)
        {

            if (text == null)
                return JValue.CreateNull();

            var d = text;
            foreach (var item in keys)
            {

                var t1 = string.IsNullOrEmpty(text.Trim().Replace(item, string.Empty).Trim());

                if (ctx.SubSources.Variables.Get(item.Substring(2), out object r))
                {

                    if (keys.Length == 1 && t1)
                    {

                        if (r is JObject || r is JArray || r is JDictionaryValue)
                            return (JToken)r;

                    }
                    d = d.Replace(item, r?.ToString() ?? String.Empty);
                }

                else
                {
                    ctx.Diagnostics.AddError(string.Empty, trace, d, $"the key '{item}' can't be resolved.");
                    d = d.Replace(item, string.Empty);
                }
            }

            try
            {
                return new JValue(d);
            }
            catch (Exception)
            {
                ctx.Diagnostics.AddError(string.Empty, trace, d, $"'d' can't be converted in jvalue");
                throw;
            }

        }

        #endregion Variables

        private static object GetValue(JToken token)
        {
            if (token is JValue v)
                return v.Value;

            return null;

        }

        public static JToken GetContentFromService(RuntimeContext ctx, JToken token, ITransformJsonService service, TokenLocation trace, string serviceName)
        {

            try
            {
                return service.Execute(ctx, token);
            }
            catch (Exception ex)
            {
                LocalDebug.Stop();
                ctx.Diagnostics.AddError(string.Empty, trace, $"failed to run function {serviceName}", ex.Message);
            }

            return JValue.CreateNull();

        }

        public static JToken GetContentByJPath(RuntimeContext ctx, JToken token, string path, TokenLocation trace)
        {

            JToken result = null;

            try
            {

                if (token == null)
                    ctx.Diagnostics.AddError(string.Empty, trace, String.Empty, $"the token is null. the filter '{path}' can't be apply");

                else
                {

                    if (token is JObject o)
                    {
                        var h = o.SelectTokens(path).ToList();
                        if (h.Count == 0)
                            result = null;

                        else if (h.Count == 1)
                            result = h[0];

                        else
                            result = new JArray(h);

                    }

                    else if (token is JArray a)
                    {

                        var h = a.SelectTokens(path).ToList();
                        if (h.Count == 1)
                            result = h[0];

                        else
                            result = new JArray(h);

                    }
                    else if (token is JValue v)
                        return null;

                    else
                    {

                    }

                }
            }
            catch (Newtonsoft.Json.JsonException e)
            {
                ctx.Diagnostics.AddError(string.Empty, trace, $"invalid json path '{path}'." + e.Message, e.Message);
            }

            return result;

        }

        public static void AddProperty(JObject token, JProperty property)
        {
            token.Add(property);
        }

        public static bool ConvertToBool(JToken token)
        {

            if (token is JValue v)
                return (object.Equals(v.Value, true));

            return false;

        }

        public static object ConvertTo(JToken token, Type targetType)
        {

            object result = token;

            if (token is JValue v)
                result = Convert.ChangeType(v.Value, targetType);

            else
            {
                LocalDebug.Stop();
            }

            return result;

        }


        #endregion methods called in the expressions

        internal static readonly Func<JToken, Type, object> _convertToken;
        internal static readonly Func<RuntimeContext, JToken, Func<RuntimeContext, JToken, JToken>, JToken> _getProjectionFromSource;
        internal static readonly Func<RuntimeContext, JToken, string, TokenLocation, JToken> _getContentByJPath;
        internal static readonly Func<RuntimeContext, JToken, ITransformJsonService, TokenLocation, string, JToken> _getContentFromService;
        internal static readonly Func<RuntimeContext, JToken, OperationEnum, JToken> _evaluateUnaryOperator;
        internal static readonly Func<RuntimeContext, object, OperationEnum, object, JToken> _evaluateBinaryOperator;
        internal static readonly Func<RuntimeContext, string, string[], TokenLocation, object> _translateVariable;

        internal static readonly MethodInfo _addProperty;
        internal static readonly MethodInfo _setVariable;
        internal static readonly MethodInfo _getVariable;
        internal static readonly MethodInfo _DelVariable;
        internal static readonly MethodInfo _TraceLocation;
        internal static readonly MethodInfo _ExitLocation;
        internal static readonly PropertyInfo _ScriptProperty;
        internal static readonly MethodInfo _convertToBool;
        private readonly Stopwatch _watch;

        public JToken TokenSource { get; }

        public Sources SubSources { get; }

        public Diagnostics Diagnostics { get => _diagnostics; }


        public JToken TokenResult { get; set; }

        public TranformJsonAstConfiguration Configuration { get; internal set; }

        public bool StopIsActivated { get; set; } = true;

        public bool MustoBreak { get; private set; }

        public StringBuilder Output { get; internal set; }

        private static readonly Dictionary<Type, Dictionary<string, (PropertyInfo, Action<object, object>)>> _properties;
        private static object _lock = new object();
        private readonly Diagnostics _diagnostics;
        private readonly Stack<MethodContext> _stack;


        private class MethodContext
        {

            public MethodContext()
            {
                this.Watch = new Stopwatch();
            }

            public TokenLocation Trace { get; internal set; }

            public Stopwatch Watch { get; }

        }

    }


}
