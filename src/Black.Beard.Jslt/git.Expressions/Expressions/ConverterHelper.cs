using Bb.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Expresssions
{


    /// <summary>
    /// build lanbda and compile for ActionResult 
    /// </summary>
    public static partial class ConverterHelper
    {


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

            var ms = typeof(Convert).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            foreach (var item in ms)
            {
                if (!_names.Contains(item.Name))
                    continue;

                var p = item.GetParameters();
                if ((p.Length == 1 || p.Length == 2) && p[0].ParameterType != item.ReturnType)
                {
                    if (!_dicConverters.TryGetValue(p[0].ParameterType, out Dictionary<Type, MethodBase> dic2))
                        _dicConverters.Add(p[0].ParameterType, dic2 = new Dictionary<Type, MethodBase>());

                    if (!dic2.ContainsKey(item.ReturnType))
                        dic2.Add(item.ReturnType, item);

                    else
                    {

                    }
                }
            }

        }

        public static void AddMethod(Type sourceType, Type targetType, MethodBase methodConverter)
        {

            GetConvertMethod(sourceType, targetType);

            // already registered
            if (_dicConverters.TryGetValue(sourceType, out Dictionary<Type, MethodBase> dicSource))
                if (dicSource.TryGetValue(targetType, out MethodBase method))
                {
                    dicSource[targetType] = methodConverter;
                }
                else
                    dicSource.Add(targetType, methodConverter);

        }

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

            dicSource.TryGetValue(targetType, out method);

            return method;

        }

        private static void registerCtors(Type sourceType, Type targetType)
        {

            var ctor = LookInCtors(sourceType, targetType);
            if (ctor != null)
            {

                if (!_dicConverters.TryGetValue(sourceType, out Dictionary<Type, MethodBase> dicSource))
                    _dicConverters.Add(sourceType, dicSource = new Dictionary<Type, MethodBase>());

                dicSource.Add(targetType, ctor);

            }
        }

        private static void RegisterOperators(Type targetType)
        {

            // Try to looking for in implicit and explicit operators
            foreach (var item in SearchConvertOperator(targetType))
            {

                if (!_dicConverters.TryGetValue(item.Item2, out Dictionary<Type, MethodBase> dicSource1))
                    _dicConverters.Add(item.Item2, (dicSource1 = new Dictionary<Type, MethodBase>()));

                if (!dicSource1.TryGetValue(item.Item1.ReturnType, out MethodBase method))
                    dicSource1.Add(item.Item1.ReturnType, item.Item1);

            }

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
                if (p.Length == 1 || p.Length == 2)
                {
                    var type1 = p[0].ParameterType;
                    var type2 = p[1].ParameterType;
                    if (type1 != sourceType && typeof(IFormatProvider).IsAssignableFrom(type1))
                        test = false;
                    if (type2 != sourceType && typeof(IFormatProvider).IsAssignableFrom(type2))
                        test = false;
                }
                else
                    test = false;

                if (test)
                    return ctor;

            }

            return null;

        }

        private static Dictionary<Type, Dictionary<Type, MethodBase>> _dicConverters = new Dictionary<Type, Dictionary<Type, MethodBase>>();
        private static readonly HashSet<string> _names;
    }

}
