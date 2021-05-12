using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
    /// </summary>
    public static class MethodDiscovery
    {

        /// <summary>
        /// Return the list of method from list of types
        /// </summary>
        /// <param name="type">type the declare methods</param>
        /// <param name="returnType">Not evaluated if null. method return type</param>
        /// <param name="parameters">Not evaluated if null. method arguments type</param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(IEnumerable<Type> types, BindingFlags bindings, Type returnType, List<Type> parameters)
        {
            List<MethodInfo> _methods = new List<MethodInfo>();
            foreach (var type in types)
            {
                var methods = type.GetMethods(bindings).ToList()
                    .Where(c => (returnType == null || c.ReturnType == returnType) && (parameters == null || EvaluateMethodParameters(c, parameters))).ToList();
                _methods.AddRange(methods);
            }
            return _methods;
        }

        /// <summary>
        /// Return the list of method
        /// </summary>
        /// <param name="type">type the declare methods</param>
        /// <param name="returnType">Not evaluated if null. method return type</param>
        /// <param name="parameters">Not evaluated if null. method arguments type</param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindings, Type returnType, List<Type> parameters)
        {
            var methods = type.GetMethods(bindings).ToList()
                .Where(c => (returnType == null || c.ReturnType == returnType) && (parameters == null || EvaluateMethodParameters(c, parameters))).ToList();
            return methods;
        }

        private static bool EvaluateMethodParameters(MethodInfo item, List<Type> parameters)
        {

            var _parameters = item.GetParameters();
            if (_parameters.Length != parameters.Count)
                return false;

            for (var i = 0; i < parameters.Count; i++)
            {
                var _p1 = _parameters[i];
                var _p2 = parameters[i];
                if (_p1.ParameterType != _p2)
                    return false;
            }

            return true;

        }


    }

}