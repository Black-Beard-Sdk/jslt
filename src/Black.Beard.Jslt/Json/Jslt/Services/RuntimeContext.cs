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
        //public static readonly Func<RuntimeContext, TranformJsonAstConfiguration.Factory<ITransformJsonService>, string, JToken, ITransformJsonService> _mapPropertyService;
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


        public JToken TokenSource { get; }

        public Sources SubSources { get; }

        public JToken TokenResult { get; internal set; }

    }


}
