using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Expressions
{

    /// <summary>
    /// build lambda and compile for ActionResult 
    /// </summary>
    public static partial class ConverterHelper
    {

        /// <summary>
        /// Cosntructor
        /// </summary>
        static ConverterHelper()
        {

            _names = new HashSet<string>()
            {
                "ToBoolean",
                "ToByte",
                "ToChar",
                "ToDateTime",
                "ToDecimal",
                "ToDouble",
                "ToInt16",
                "ToInt32",
                "ToInt64",
                "ToSByte",
                "ToSingle",
                "ToString",
                "ToUInt16",
                "ToUInt32",
                "ToUInt64",
                "ChangeType",
            };

            var ms = typeof(Convert).GetMethods(BindingFlags.Static | BindingFlags.Public);

            foreach (var item in ms)
                if (_names.Contains(item.Name))
                {
                    var p = item.GetParameters();
                    if ((p.Length == 1 || p.Length == 2) && p[0].ParameterType != item.ReturnType)
                        Register(p[0].ParameterType, item.ReturnType, item);
                }

            ms = typeof(NullableConverter).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var item in ms)
                {
                    var p = item.GetParameters();
                    if ((p.Length == 1 || p.Length == 2) && p[0].ParameterType != item.ReturnType)
                        Register(p[0].ParameterType, item.ReturnType, item);
                }
        }

        /// <summary>
        /// Convert a value to another type
        /// </summary>
        /// <param name="self"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object ToObject(object self, Type targetType)
        {

            if (self == null)
                return null;

            var sourceType = self.GetType();

            if (!_dic.TryGetValue(sourceType, out var dic2))
                _dic.Add(sourceType, dic2 = new Dictionary<Type, Func<object, object>>());

            if (!dic2.TryGetValue(targetType, out var function))
            {

                var source = Expression.Parameter(typeof(object));

                var e = source.ConvertIfDifferent(sourceType);
                e = e.ConvertIfDifferent(targetType);
                e = e.ConvertIfDifferent(typeof(object));

                var lbd = Expression.Lambda<Func<object, object>>(e, source);

                dic2.Add(targetType, function = lbd.Compile());

            }

            var result = function(self);

            return result;

        }

        /// <summary>
        /// Resolve the method to convert sourceType to targetType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="toOverride"></param>
        public static void ResolveConverter(Type type, Func<MethodInfo, bool> toOverride)
        {

            MethodInfo[] ms = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var item in ms)
            {

                var p = item.GetParameters();
                if ((p.Length == 1 || p.Length == 2) && p[0].ParameterType != item.ReturnType)
                    Register(p[0].ParameterType, item.ReturnType, item);

            }

        }

        /// <summary>
        /// Append method to the convert sourceType to targetType
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <param name="methodConverter"></param>
        public static void AddMethod(Type sourceType, Type targetType, MethodBase methodConverter)
        {

            GetConvertMethod(sourceType, targetType);
            // already registered
            Register(sourceType, targetType, methodConverter);

        }

        /// <summary>
        /// Get the method to convert sourceType to targetType
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static MethodBase GetConvertMethod(Type sourceType, Type targetType)
        {

            MethodBase method;

            // already registered
            if (!_dicConverters.TryGetValue(sourceType, out Dictionary<Type, MethodBase> dicSource))
                _dicConverters.Add(sourceType, dicSource = new Dictionary<Type, MethodBase>());

            if (dicSource.TryGetValue(targetType, out method))
                return method;

            RegisterIConvertible(sourceType, dicSource);
            RegisterOperators(targetType);
            registerCtors(sourceType, targetType);

            if (!dicSource.TryGetValue(targetType, out method))
            {
                if (sourceType == typeof(Oldtonsoft.Json.Linq.JObject) && targetType.IsClass)
                {
                    var o = typeof(ConverterHelper).GetMethod(nameof(ConverterHelper.ConvertToObject), BindingFlags.Static | BindingFlags.NonPublic);
                    method = o.MakeGenericMethod(targetType);
                    Register(sourceType, targetType, method);
                }
                else if (sourceType == typeof(Oldtonsoft.Json.Linq.JArray) && targetType.IsArray)
                {
                    var o = typeof(ConverterHelper).GetMethod(nameof(ConverterHelper.ConvertToObject), BindingFlags.Static | BindingFlags.NonPublic);
                    method = o.MakeGenericMethod(targetType);
                    Register(sourceType, targetType, method);
                }
            }

            return method;

        }

        private static object ConvertToObject<T>(Oldtonsoft.Json.Linq.JToken self)
        {
            var result = self.ToObject<T>();
            return result;
        }

        private static void registerCtors(Type sourceType, Type targetType)
        {

            var ctor = LookInCtors(sourceType, targetType);

            if (ctor != null)
                Register(sourceType, targetType, ctor);

        }

        private static void RegisterOperators(Type targetType)
        {

            // Try to looking for in implicit and explicit operators
            foreach (var item in SearchConvertOperator(targetType))
                Register(item.Item2, targetType, item.Item1);

        }

        private static void RegisterIConvertible(Type sourceType, Dictionary<Type, MethodBase> dicSource)
        {
            if (typeof(IConvertible).IsAssignableFrom(sourceType))
            {

                var ms = sourceType.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                foreach (var item in ms)
                {

                    if (!_names.Contains(item.Name))
                        continue;

                    var parameter = item.GetParameters();
                    if ((parameter.Length == 1) && parameter[0].ParameterType == typeof(IFormatProvider))
                    {

                        if (!dicSource.ContainsKey(item.ReturnType))
                            dicSource.Add(item.ReturnType, item);

                    }
                }

            }
        }

        private static IEnumerable<(MethodInfo, Type)> SearchConvertOperator(Type sourceType)
        {
            var m = sourceType.GetMethods().Where(c => c.IsStatic & c.IsPublic & (c.Name == "op_Explicit" | c.Name == "op_Implicit")).ToList();
            foreach (var method in m)
            {
                var parameters = method.GetParameters();
                if (parameters.Length == 1)
                {
                    var parameter = parameters[0];
                    yield return (method, parameter.ParameterType);
                }
            }
        }

        private static ConstructorInfo LookInCtors(Type sourceType, Type targetType)
        {

            var ctors = targetType.GetConstructors();
            foreach (var ctor in ctors)
            {

                bool test = true;
                var p = ctor.GetParameters();
                if (p.Length == 1)
                {

                    var type1 = p[0].ParameterType;
                    if (type1 == sourceType)
                    {

                    }
                    else if (!typeof(IFormatProvider).IsAssignableFrom(type1))
                        test = false;

                }
                else if (p.Length == 2)
                {

                    var type1 = p[0].ParameterType;
                    if (type1 == sourceType)
                    {

                    }
                    else if (!typeof(IFormatProvider).IsAssignableFrom(type1))
                        test = false;

                    var type2 = p[1].ParameterType;
                    if (!typeof(IFormatProvider).IsAssignableFrom(type2))
                        test = false;

                }
                else
                    test = false;

                if (test)
                    return ctor;

            }

            return null;

        }

        private static void Register(Type sourceType, Type targetType, MethodBase methodConverter)
        {

            if (!_dicConverters.TryGetValue(sourceType, out Dictionary<Type, MethodBase> dicSource))
                _dicConverters.Add(sourceType, dicSource = new Dictionary<Type, MethodBase>());

            if (dicSource.ContainsKey(targetType))
                dicSource[targetType] = methodConverter;

            else
                dicSource.Add(targetType, methodConverter);

        }

        private static Dictionary<Type, Dictionary<Type, Func<object, object>>> _dic = new Dictionary<Type, Dictionary<Type, Func<object, object>>>();
        private static Dictionary<Type, Dictionary<Type, MethodBase>> _dicConverters = new Dictionary<Type, Dictionary<Type, MethodBase>>();
        private static readonly HashSet<string> _names;
    
    }

}
