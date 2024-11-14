using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.CustomServices
{
    internal static class TypeExtension
    {

        static TypeExtension()
        {
            _method = typeof(TypeExtension).GetMethod(nameof(GetDefaultValueGeneric));
            _dic = new Dictionary<Type, object>();
        }

        public static object GetDefaultValue(this Type type)
        {

            if (!_dic.TryGetValue(type, out object result))
                lock (_lock)
                    if (!_dic.TryGetValue(type, out result))
                        _dic.Add(type, result = _method.MakeGenericMethod(type).Invoke(null, new object[] { }));

            return result;

        }

        public static T GetDefaultValueGeneric<T>()
        {
            return default;
        }

        private static object _lock = new object();
        private static readonly MethodInfo _method;
        private static readonly Dictionary<Type, object> _dic;

    }

}
