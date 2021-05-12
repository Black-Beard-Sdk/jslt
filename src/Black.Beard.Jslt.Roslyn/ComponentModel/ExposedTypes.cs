using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.ComponentModel
{


    /// <summary>
    /// referential of type exposed by <see cref="ExposedTypes"/>
    /// </summary>
    public class ExposedTypes
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposedTypes"/> class.
        /// </summary>
        public ExposedTypes()
        {
            _items = new Dictionary<Type, HashSet<ExposeClassAttribute>>();
            Refresh();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            IEnumerable<KeyValuePair<Type, IEnumerable<ExposeClassAttribute>>> items = TypeWithAttributeReferential<ExposeClassAttribute>.Instance.GetAttributes().ToList();
            Add(items);
        }


        /// <summary>
        /// Gets all the types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetTypes()
        {
            foreach (var item in _items)
                yield return item;
        }

        /// <summary>
        /// Gets the types with specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetTypes(string context)
        {

            foreach (var item1 in _items)
            {

                HashSet<ExposeClassAttribute> _attributes = new HashSet<ExposeClassAttribute>();
                foreach (var item2 in item1.Value)
                    if (item2.Context == context)
                        _attributes.Add(item2);

                if (_attributes.Any())
                    yield return new KeyValuePair<Type, HashSet<ExposeClassAttribute>>(item1.Key, _attributes);

            }

        }

        /// <summary>
        /// Gets the context's list.
        /// </summary>
        /// <returns></returns>
        public string[] GetContexts()
        {

            HashSet<string> results = new HashSet<string>();

            foreach (var item1 in _items)
                foreach (var item2 in item1.Value)
                    results.Add(item2.Context);

            return results.ToArray();

        }

        /// <summary>
        /// Removes the specified type of exposed types.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><see cref="ExposedTypes"/></returns>
        public ExposedTypes Remove(Type type)
        {

            if (_items.ContainsKey(type))
                _items.Remove(type);

            return this;

        }

        /// <summary>
        /// Adds the specified configurations.
        /// </summary>
        /// <param name="configurations">The configurations.</param>
        /// <returns><see cref="ExposedTypes"/></returns>
        public ExposedTypes Add(ExposedTypeConfigurations configurations)
        {

            foreach (ExposedTypeConfiguration configuration in configurations)
            {

                Type type = TypeDiscovery.Instance.ResolveByName(configuration.TypeName)
                    ?? throw new TypeLoadException(configuration.TypeName);

                if (!_items.TryGetValue(type, out HashSet<ExposeClassAttribute> list))
                    _items.Add(type, list = new HashSet<ExposeClassAttribute>());

                foreach (ExposedAttributeTypeConfiguration configurationAttribute in configuration.Attributes)
                {

                    Type exposedType = null;
                    if (configurationAttribute.ExposedType != null)
                    {
                        exposedType = TypeDiscovery.Instance.ResolveByName(configurationAttribute.ExposedType)
                            ?? throw new TypeLoadException(configurationAttribute.ExposedType);
                    }

                    ExposeClassAttribute e = new ExposeClassAttribute(configurationAttribute.Context, configurationAttribute.Name)
                    {
                        LifeCycle = configurationAttribute.LifeCycle,
                        ExposedType = exposedType ?? type
                    };

                    list.Add(e);

                }

            }

            return this;

        }

        /// <summary>
        /// Refreshes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns><see cref="ExposedTypes"/></returns>
        public ExposedTypes Add(IEnumerable<KeyValuePair<Type, IEnumerable<ExposeClassAttribute>>> items)
        {

            foreach (KeyValuePair<Type, IEnumerable<ExposeClassAttribute>> item in items)
            {

                if (!_items.TryGetValue(item.Key, out HashSet<ExposeClassAttribute> list))
                    _items.Add(item.Key, list = new HashSet<ExposeClassAttribute>());

                foreach (var item3 in item.Value)
                    list.Add(item3);

            }

            return this;

        }

        /// <summary>
        /// push the <see cref="ExposeClassAttribute" /> registered types.
        /// </summary>
        /// <returns><see cref="ExposedTypes"/></returns>
        public ExposedTypes AddAttributesInTypeDescriptors()
        {

            foreach (var type in _items)
            {

                var _attributes = new HashSet<ExposeClassAttribute>(TypeDescriptor.GetAttributes(type.Key).OfType<ExposeClassAttribute>().ToList());

                foreach (var attribute in type.Value)
                    if (_attributes.Add(attribute))
                        TypeDescriptor.AddAttributes(type.Key, attribute);

            }

            return this;

        }

        private readonly Dictionary<Type, HashSet<ExposeClassAttribute>> _items;

    }

}
