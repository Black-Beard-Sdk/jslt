using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Collect all types decorated with attribute <see cref="TAttribute"/>
    /// </summary>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    public class TypeWithAttributeReferential<TAttribute> where TAttribute : Attribute
    {

        /// <summary>
        /// Initializes the <see cref="TypeWithAttributeReferential{TAttribute}"/> class.
        /// </summary>
        static TypeWithAttributeReferential()
        {
            TypeWithAttributeReferential<TAttribute>._instance = new Lazy<TypeWithAttributeReferential<TAttribute>>(() =>
            {
                var i = new TypeWithAttributeReferential<TAttribute>();
                i.Refresh();
                return i;
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeWithAttributeReferential{TAttribute}"/> class.
        /// </summary>
        public TypeWithAttributeReferential()
        {
            _types = new HashSet<Type>();
        }

        /// <summary>
        /// Refreshes internal list with loaded type decorated with attribute <see cref="TAttribute"/>.
        /// </summary>
        public virtual void Refresh()
        {
            var items = TypeDiscovery.Instance.GetTypesWithAttributes(typeof(TAttribute));
            foreach (var item in items)
                _types.Add(item);
        }


        public IEnumerable<KeyValuePair<Type, IEnumerable<TAttribute>>> GetAttributes()
        {
            foreach (var item in Types)
            {
                var items = TypeDescriptor.GetAttributes(item).OfType<TAttribute>().ToList();
                yield return new KeyValuePair<Type, IEnumerable<TAttribute>>(item, items);
            }
        }

        public static TypeWithAttributeReferential<TAttribute> Instance => TypeWithAttributeReferential<TAttribute>._instance.Value;

        public IEnumerable<Type> Types => _types;

        private static readonly Lazy<TypeWithAttributeReferential<TAttribute>> _instance;

        private HashSet<Type> _types;

    }

}
