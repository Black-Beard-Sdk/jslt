using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{

    public class MethodDiscoveryAssembly : IMethodDiscovery
    {

        public MethodDiscoveryAssembly(ITypeReferential typeReferential, string startWith, Type inheritFrom)
        {
            _typeReferential = typeReferential;
            _startWith = startWith;
            _inheritFrom = inheritFrom;
        }


        public string Context { get; set; }

        /// <summary>
        /// Return list of method for the specified arguments
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnType"></param>
        /// <param name="methodSign"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">returnType</exception>
        /// <exception cref="ArgumentNullException">methodSign</exception>
        public virtual IEnumerable<BusinessAction<T>> GetActions<T>(BindingFlags bindings, Type returnType, List<Type> methodSign) //where T : Context
        {

            this.methodSign = methodSign;
            this.returnType = returnType;

            Type[] types = GetTypes();
            var actions = GetActions_Impl<T>(bindings, types);

            if (!string.IsNullOrEmpty(_startWith))
                return actions.Where(c => c.RuleName.StartsWith(_startWith)).ToList();

            return actions;

        }

        public virtual Type[] GetTypes()
        {

            var t = _inheritFrom ?? typeof(object);

            var types = !string.IsNullOrEmpty(Context)
                ? _typeReferential.GetTypesWithAttributes<ExposeClassAttribute>(t, attribute => attribute.Context == Context)
                : _typeReferential.GetTypesWithAttributes(typeof(ExposeClassAttribute));

            return types.ToArray();

        }

        /// <summary>
        /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        private IEnumerable<BusinessAction<T>> GetActions_Impl<T>(BindingFlags bindings, params Type[] types)
        {

            var _result = new List<BusinessAction<T>>();

            var _types = new ExposedTypes()
               .GetTypes()
               .Where(c => types.Contains(c.Key))
               .ToList();

            foreach (var u in _types)
            {

                var type = u.Key;

                foreach (ExposeClassAttribute attribute in u.Value)
                {

                    string name = attribute.Name ?? type.Name;

                    var items = MethodDiscovery.GetMethods(type, bindings, returnType, methodSign);

                    foreach (var method in items)
                    {

                        RegisterMethodAttribute attribute2 = TypeDescriptor.GetAttributes(method).OfType<RegisterMethodAttribute>().FirstOrDefault();
                        if (attribute2 != null && (string.IsNullOrEmpty(Context) || attribute2.Context == Context))
                            _result.Add(new BusinessAction<T>
                            {
                                Name = $"{name}.{attribute2.DisplayName}",
                                Method = method,
                                Type = type,
                                RuleName = attribute2.DisplayName,
                                Origin = $"Assembly {type.AssemblyQualifiedName}",
                                Context = attribute2.Context,
                            });
                    }
                }

            }

            return _result;
        }

        private Type returnType;
        private List<Type> methodSign;
        private readonly ITypeReferential _typeReferential;
        private readonly string _startWith;
        private readonly Type _inheritFrom;
    }
}
