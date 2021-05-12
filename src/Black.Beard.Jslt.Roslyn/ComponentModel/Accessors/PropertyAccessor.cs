using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel.Accessors
{


    /// <summary>
    /// Property Accessor 
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class PropertyAccessor : AccessorItem
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAccessor"/> class.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="property">The property.</param>
        internal PropertyAccessor(Type componentType, PropertyInfo property)
            : base(MemberTypeEnum.Property)
        {

            this.Member = property;
            this.Name = property.Name;
            this.DeclaringType = property.DeclaringType;
            var m = property.GetMethod ?? property.SetMethod;
            this.IsStatic = m != null ? (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static : false;
            this.Type = property.PropertyType;

            #region Get

            if (property.CanRead)
            {
                var sourceParameterExpr = Expression.Parameter(typeof(object), "i");

                this.GetValue =
                Expression.Lambda<Func<object, object>>
                (
                    Expression.Convert
                    (
                        Expression.Property
                        (
                            this.IsStatic ? null : Expression.Convert(sourceParameterExpr, componentType),
                            property
                        ),
                        typeof(object)
                    ),
                    sourceParameterExpr
                ).Compile();
            }

            #endregion

            #region Set

            if (property.CanWrite)
            {

                var targetObjectParameter = Expression.Parameter(typeof(object), "i");
                var convertedObjectParameter = Expression.ConvertChecked(targetObjectParameter, componentType);
                var valueParameter = Expression.Parameter(typeof(object), "value");
                var convertedValueParameter = Expression.ConvertChecked(valueParameter, property.PropertyType);
                var propertyExpression = Expression.Property(this.IsStatic ? null : convertedObjectParameter, property);

                SetValue =
                Expression.Lambda<Action<object, object>>
                (
                    Expression.Assign
                    (
                        propertyExpression,
                        convertedValueParameter
                    ),
                    targetObjectParameter,
                    valueParameter
                ).Compile();

            }

            #endregion

        }

        /// <summary>
        /// Gets the specified component type.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static PropertyAccessor GetProperty(Type componentType, string name)
        {
            AccessorList list = null;
            PropertyAccessor accessor = null;

            list = Get(componentType, string.IsNullOrEmpty(name));

            if (list.ContainsKey(name))
                accessor = list[name] as PropertyAccessor;

            else
                lock (list._lock)
                {
                    if (list.ContainsKey(name))
                        accessor = list[name] as PropertyAccessor;
                    else
                    {
                        var property = componentType.GetProperty(name);
                        if (property != null)
                            list.Add((accessor = new PropertyAccessor(componentType, property)));

                    }
                }

            return accessor;

        }

        /// <summary>
        /// Gets the specified component type.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="withSubType">if set to <c>true</c> [with sub type].</param>
        /// <returns></returns>
        public static AccessorList GetProperties(Type componentType, bool withSubType = false)
        {

            AccessorList list = null;

            if (_accessors.ContainsKey(componentType))
                list = _accessors[componentType];

            else
            {
                lock (_lock)
                {

                    if (_accessors.ContainsKey(componentType))
                        list = _accessors[componentType];

                    else
                    {

                        list = new AccessorList();

                        foreach (PropertyInfo item in AccessorList.GetProperties(componentType))
                            if (withSubType || item.DeclaringType == componentType && !list.ContainsKey(item.Name))
                                list.Add(new PropertyAccessor(componentType, item));

                        _accessors.Add(componentType, list);

                    }
                }
            }

            return list;

        }


    }


}
