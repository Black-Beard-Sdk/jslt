using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

            _setVariable = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.SetVariable), new Type[] { typeof(RuntimeContext), typeof(string), typeof(object) });
            _DelVariable = typeof(RuntimeContext).GetMethod(nameof(RuntimeContext.DelVariable), new Type[] { typeof(RuntimeContext), typeof(string) });


        }

        internal RuntimeContext(Sources sources)
        {
            TokenSource = sources.Source.Datas;
            SubSources = sources;
            _diagnostics = new Diagnostics();
        }

        #region methods called in the expressions

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        public  void Stop()
        {
            if (StopIsActivated)
                System.Diagnostics.Debugger.Break();
        }

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

            if (leftToken is JToken tokenLeft)
                l = GetValue(tokenLeft);
            else
            {
                LocalDebug.Stop();
            }

            if (rightToken is JToken tokenRight)
                r = GetValue(tokenRight);
            else
            {
                LocalDebug.Stop();
                r = rightToken;
            }

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
            catch (Exception e)
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

        private static object GetValue(JToken token)
        {
            if (token is JValue v)
                return v.Value;

            return null;

        }

        public static JToken GetContentFromService(RuntimeContext ctx, JToken token, ITransformJsonService service)
        {
            return service.Execute(ctx, token);
        }

        public static void SetVariable(RuntimeContext ctx, string name, object value)
        {
            ctx.SubSources.Variables.Add(name, value);
        }

        public static void DelVariable(RuntimeContext ctx, string name)
        {
            ctx.SubSources.Variables.Del(name);
        }

        public static JToken Translate(RuntimeContext ctx, string text, string[] keys)
        {

            if (text == null)
                return JValue.CreateNull();

            var d = text;
            foreach (var item in keys)
            {

                var t1 = string.IsNullOrEmpty(text.Trim().Replace(item, string.Empty).Trim());

                var r = ctx.SubSources.Variables.Get(item.Substring(2));

                if (r != null)
                {

                    if (keys.Length == 1 && t1)
                    {
                        
                        if (r is JObject || r is JArray)
                            return (JToken)r;
                    }

                    d = d.Replace(item, r.ToString());

                }

                else
                {
                    ctx.Diagnostics.AddError(string.Empty, null, d, $"the key '{item}' can't be resolved.");
                    d = d.Replace(item, string.Empty);
                }
            }

            try
            {
                return new JValue(d);
            }
            catch (Exception)
            {
                ctx.Diagnostics.AddError(string.Empty, null, d, $"'d' can't be converted in jvalue");
                throw;
            }

        }



        public static JToken GetContentByJPath(RuntimeContext ctx, JToken token, string path)
        {

            JToken result = null;

            try
            {

                if (token == null)
                    Trace.WriteLine($"the token is null. the filter '{path}' can't be apply");

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
                // {"Unexpected character while parsing path query: N"}
            }
            catch (Newtonsoft.Json.JsonException e)
            {
                throw new Exception($"invalid json path '{path}'." + e.Message, e);
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

        public static readonly Func<JToken, Type, object> _convertToken;
        public static readonly Func<RuntimeContext, JToken, Func<RuntimeContext, JToken, JToken>, JToken> _getProjectionFromSource;
        public static readonly Func<RuntimeContext, JToken, string, JToken> _getContentByJPath;
        public static readonly Func<RuntimeContext, JToken, ITransformJsonService, JToken> _getContentFromService;
        public static readonly Func<RuntimeContext, JToken, OperationEnum, JToken> _evaluateUnaryOperator;
        public static readonly Func<RuntimeContext, object, OperationEnum, object, JToken> _evaluateBinaryOperator;
        public static readonly Func<RuntimeContext, string, string[], object> _translateVariable;

        public static readonly MethodInfo _addProperty;
        public static readonly MethodInfo _setVariable;
        public static readonly MethodInfo _getVariable;
        public static readonly MethodInfo _DelVariable;
        public static readonly MethodInfo _convertToBool;


        public JToken TokenSource { get; }

        public Sources SubSources { get; }

        public Diagnostics Diagnostics { get => _diagnostics; }


        public JToken TokenResult { get; internal set; }

        public TranformJsonAstConfiguration Configuration { get; internal set; }

        public bool StopIsActivated { get; set; } = true;


        //private static (PropertyInfo, Action<object, object>) GetWriter(Type componentType, string propertyName)
        //{

        //    if (!_properties.TryGetValue(componentType, out Dictionary<string, (PropertyInfo, Action<object, object>)> properties))
        //        lock (_lock)
        //            if (!_properties.TryGetValue(componentType, out properties))
        //                _properties.Add(componentType, properties = new Dictionary<string, (PropertyInfo, Action<object, object>)>());

        //    if (!properties.TryGetValue(propertyName, out (PropertyInfo, Action<object, object>) action))
        //        lock (_lock)
        //            if (!properties.TryGetValue(propertyName, out action))
        //            {
        //                var ___properties = componentType.GetProperties().Where(c => c.Name.ToLower() == propertyName.ToLower()).ToList();
        //                var property = ___properties.Count == 1
        //                    ? ___properties[0]
        //                    : ___properties.Single(c => c.Name == propertyName)
        //                    ;

        //                if (property != null && property.CanWrite)
        //                {
        //                    var m = property.GetMethod ?? property.SetMethod;
        //                    var isStatic = m != null ? (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static : false;
        //                    var targetObjectParameter = Expression.Parameter(typeof(object), "i");
        //                    var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
        //                    var valueParameter = Expression.Parameter(typeof(object), "value");
        //                    var convertedValueParameter = Expression.ConvertChecked(valueParameter, property.PropertyType);
        //                    var propertyExpression = Expression.Property(isStatic ? null : convertedObjectParameter, property);

        //                    var assignValue = Expression.Lambda<Action<object, object>>
        //                    (
        //                        Expression.Assign
        //                        (
        //                            propertyExpression,
        //                            convertedValueParameter
        //                        ),
        //                        targetObjectParameter,
        //                        valueParameter
        //                    ).Compile();

        //                    properties.Add(propertyName, action = (property, assignValue));

        //                }
        //                else
        //                {
        //                    properties.Add(propertyName, action = (property, (arg1, arg2) => { }));
        //                }

        //            }

        //    return action;

        //}

        private static readonly Dictionary<Type, Dictionary<string, (PropertyInfo, Action<object, object>)>> _properties;

        private static object _lock = new object();

        private readonly Diagnostics _diagnostics;

    }


}
