using Bb.Json.Jslt.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Json.Jslt.Services
{

    public class RuntimeContext
    {

        static RuntimeContext()
        {
            _addLikeProperty = RuntimeContext.AddLikeProperty;
            //_mapPropertyService = RuntimeContext.MapPropertyService;
            _getContentByJPath = RuntimeContext.GetContentByJPath;
            _getContentFromService = RuntimeContext.GetContentFromService;
            _evaluateUnaryOperator = RuntimeContext.EvaluateUnaryOperator;
            _evaluateBinaryOperator = RuntimeContext.EvaluateBinaryOperator;

            _addProperty = typeof(RuntimeContext).GetMethod("AddProperty", new Type[] { typeof(JObject), typeof(JProperty) });
            _convertToBool = typeof(RuntimeContext).GetMethod("ConvertToBool", new Type[] { typeof(JToken) });
            _properties = new Dictionary<Type, Dictionary<string, (PropertyInfo, Action<object, object>)>>();
        }

        internal RuntimeContext(Sources sources)
        {
            TokenSource = sources.Source.Datas;
            SubSources = sources;
        }

        #region methods called in the expressions

        public static JToken AddLikeProperty(
            RuntimeContext ctx,
            JToken tokenSource,
            JToken value,
            JToken tokenTarget,
            string propertyName
            )
        {

            if (tokenSource != null)
            {

                if (tokenTarget is JObject o)
                    AddProperty(o, new JProperty(propertyName, value));

                else if (tokenTarget is JArray a)
                {


                }

            }

            return tokenTarget;

        }

        //public static ITransformJsonService MapPropertyService(RuntimeContext ctx, TranformJsonAstConfiguration.Factory<ITransformJsonService> factory, string propertyName, JToken value)
        //{

        //    ITransformJsonService service = factory.Creator();

        //    (PropertyInfo, Action<object, object>) writer = GetWriter(service.GetType(), propertyName);

        //    if (writer.Item1 != null)
        //    {

        //        var type = writer.Item1.PropertyType;
        //        if (type == typeof(string))
        //            writer.Item2(service, value.ToString());

        //        else if (type.IsValueType)
        //            writer.Item2(service, Convert.ChangeType(value.ToString(), type));

        //        else if (value is JObject o)
        //            writer.Item2(service, o.ToObject(type));

        //        else
        //        {
        //            writer.Item2(service, value);
        //        }

        //    }

        //    return service;

        //}

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
                            Stop();
                            break;
                    }
                }
            }

            return leftToken;
        }

        public static JToken EvaluateBinaryOperator(RuntimeContext ctx, JToken leftToken, OperationEnum @operator, JToken rightToken)
        {
            var l = GetValue(leftToken);
            var r = GetValue(rightToken);

            switch (@operator)
            {

                case OperationEnum.Equal:
                    return new JValue(object.Equals(l, r));

                case OperationEnum.GreaterThanOrEqual:
                    return new JValue(GreaterThanOrEqual(l, r));

                case OperationEnum.GreaterThan:
                    return new JValue(GreaterThan(l, r));

                case OperationEnum.LessThanOrEqual:
                    return new JValue(LessThanOrEqual(l, r));

                case OperationEnum.LessThan:
                    return new JValue(LessThan(l, r));

                case OperationEnum.NotEqual:
                    return new JValue(!object.Equals(l, r));

                case OperationEnum.Add:
                    return new JValue(Add(l, r));

                case OperationEnum.Subtract:
                    return new JValue(Substract(l, r));

                case OperationEnum.Divide:
                    return new JValue(Divid(l, r));

                case OperationEnum.Modulo:
                    return new JValue(Modulo(l, r));

                case OperationEnum.Multiply:
                    return new JValue(Multiply(l, r));

                case OperationEnum.Power:
                    return new JValue(Power(l, r));

                case OperationEnum.And:
                    return new JValue(And(l, r));

                case OperationEnum.AndExclusive:
                    return new JValue(AndExclusive(l, r));

                case OperationEnum.Or:
                    return new JValue(Or(l, r));

                case OperationEnum.OrExclusive:
                    return new JValue(OrExclusive(l, r));

                case OperationEnum.Chain:
                    break;

                default:
                    break;
            }

            return leftToken;

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

            }

            return false;

        }

        private static object AndExclusive(object l, object r)
        {

            if (l is bool left_int16)
                return left_int16 && Convert.ToBoolean(r);

            else
            {
                Stop();

            }

            return false;

        }

        private static object OrExclusive(object l, object r)
        {

            if (l is bool left_int16)
                return left_int16 && Convert.ToBoolean(r);

            else
            {
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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
                Stop();

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

        public static JToken GetContentByJPath(RuntimeContext ctx, JToken token, string path)
        {

            JToken result = null;

            if (token == null)
            {
                //Trace.WriteLine($"the token is null. the filter '{path}' can't be apply");
            }
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

        #endregion methods called in the expressions

        public static readonly Func<RuntimeContext, JToken, Func<RuntimeContext, JToken, JToken>, JToken> _getProjectionFromSource;
        public static readonly Func<RuntimeContext, JToken, string, JToken> _getContentByJPath;
        public static readonly Func<RuntimeContext, JToken, ITransformJsonService, JToken> _getContentFromService;
        public static readonly Func<RuntimeContext, JToken, OperationEnum, JToken> _evaluateUnaryOperator;
        public static readonly Func<RuntimeContext, JToken, OperationEnum, JToken, JToken> _evaluateBinaryOperator;
        public static readonly Func<RuntimeContext, JToken, JToken, JToken, string, JToken> _addLikeProperty;
        public static readonly MethodInfo _addProperty;

        public static readonly MethodInfo _convertToBool;

        private static (PropertyInfo, Action<object, object>) GetWriter(Type componentType, string propertyName)
        {

            if (!_properties.TryGetValue(componentType, out Dictionary<string, (PropertyInfo, Action<object, object>)> properties))
                lock (_lock)
                    if (!_properties.TryGetValue(componentType, out properties))
                        _properties.Add(componentType, properties = new Dictionary<string, (PropertyInfo, Action<object, object>)>());

            if (!properties.TryGetValue(propertyName, out (PropertyInfo, Action<object, object>) action))
                lock (_lock)
                    if (!properties.TryGetValue(propertyName, out action))
                    {
                        var ___properties = componentType.GetProperties().Where(c => c.Name.ToLower() == propertyName.ToLower()).ToList();
                        var property = ___properties.Count == 1
                            ? ___properties[0]
                            : ___properties.Single(c => c.Name == propertyName)
                            ;

                        if (property != null && property.CanWrite)
                        {
                            var m = property.GetMethod ?? property.SetMethod;
                            var isStatic = m != null ? (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static : false;
                            var targetObjectParameter = Expression.Parameter(typeof(object), "i");
                            var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
                            var valueParameter = Expression.Parameter(typeof(object), "value");
                            var convertedValueParameter = Expression.ConvertChecked(valueParameter, property.PropertyType);
                            var propertyExpression = Expression.Property(isStatic ? null : convertedObjectParameter, property);

                            var assignValue = Expression.Lambda<Action<object, object>>
                            (
                                Expression.Assign
                                (
                                    propertyExpression,
                                    convertedValueParameter
                                ),
                                targetObjectParameter,
                                valueParameter
                            ).Compile();

                            properties.Add(propertyName, action = (property, assignValue));

                        }
                        else
                        {
                            properties.Add(propertyName, action = (property, (arg1, arg2) => { }));
                        }

                    }

            return action;

        }

        private static readonly Dictionary<Type, Dictionary<string, (PropertyInfo, Action<object, object>)>> _properties;

        private static object _lock = new object();

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private static void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }


        public JToken TokenSource { get; }

        public Sources SubSources { get; }

        public JToken TokenResult { get; internal set; }

    }


}
