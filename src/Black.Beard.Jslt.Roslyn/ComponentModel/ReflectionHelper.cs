using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{

    public static class ReflectionHelper
    {

        public static IEnumerable<PropertyInfo> GetNamedProperty(this Type componentType, string name)
        {
            return GetAllProperties(componentType).Where(c => c.Name == name);
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this Type componentType)
        {

            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            var type = componentType;

            while (type != null && type != typeof(object))
            {
                foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    yield return item;

                type = type.BaseType;

            }
        }

        public static MethodInfo GetNamedMethod(this Type componentType, string name, params Type[] args)
        {
            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("message", nameof(name));

            var methods = GetAllMethods(componentType)
                //.Where(c => c.IsPublic)
                .ToList();

            foreach (var item in methods.Where(c => c.Name == name))
            {
                var args2 = item.GetParameters();
                if (args.Length == args2.Length)
                {
                    for (int i = 0; i < args.Length; i++)
                        if (args[i] != args2[i].ParameterType)
                            continue;
                    return item;
                }
            }

            return null;

        }

        public static IEnumerable<MethodInfo> GetNamedMethods(this Type componentType, string name)
        {
            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            return GetAllMethods(componentType).Where(c => c.Name == name);
        }

        public static IEnumerable<MethodInfo> GetAllMethods(this Type componentType)
        {

            if (componentType == null)
                throw new ArgumentNullException(nameof(componentType));

            var type = componentType;

            while (type != null && type != typeof(object))
            {
                foreach (var item in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    yield return item;

                type = type.BaseType;

            }
        }

    }

}
