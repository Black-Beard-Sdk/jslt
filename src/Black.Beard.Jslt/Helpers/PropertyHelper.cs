using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb
{

    internal static class PropertyHelper
    {

        /// <summary>
        /// Return optimized properties accessors
        /// </summary>
        /// <param name="self"> type where the properties must found</param>
        /// <param name="flags">By default (Instance Public)</param>
        /// <returns></returns>
        public static Dictionary<string, Property> GetPropertiesAccessor(this Type self, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
        {

            Dictionary<string, Property> result = new Dictionary<string, Property>();
            var properties = self.GetProperties(flags);

            foreach (var item in properties)
                result.Add(item.Name, item.GetPropertyAccessor(self));

            return result;

        }

        /// <summary>
        /// Return optimized property accessor
        /// </summary>
        /// <param name="property"></param>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public static Property GetPropertyAccessor(this PropertyInfo property, Type componentType)
        {

            var Member = property;
            var Name = property.Name;
            var DeclaringType = property.DeclaringType;
            var m = property.GetMethod ?? property.SetMethod;
            var IsStatic = m != null ? (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static : false;
            var Type = property.PropertyType;

            Action<object, object> SetValue = null;
            Func<object, object> GetValue = null;

            #region Get

            if (property.CanRead)
            {
                var sourceParameterExpr = Expression.Parameter(typeof(object), "i");

                GetValue =
                Expression.Lambda<Func<object, object>>
                (
                    Expression.Convert
                    (
                        Expression.Property
                        (
                            IsStatic ? null : Expression.Convert(sourceParameterExpr, componentType),
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
                var propertyExpression = Expression.Property(IsStatic ? null : convertedObjectParameter, property);

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

            return new Property(property, GetValue, SetValue);

        }

    }

    [DisplayName("{Name}")]
    public class Property
    {

        internal Property(PropertyInfo property, Func<object, object> @get, Action<object, object> @set)
        {
            Member = property;
            Get = @get;
            Set = @set;
        }

        public string Name => Member.Name;

        public bool CanRead => Member.CanRead;

        public bool CanWrite => Member.CanWrite;

        public Type Type => Member.PropertyType;

        public Func<object, object> Get { get; }

        public Action<object, object> Set { get; }

        public PropertyInfo Member { get; }

        /// <summary>
        /// Gets a value indicating whether [is clonable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is clonable]; otherwise, <c>false</c>.
        /// </value>
        public bool IsClonable => Set != null && Get != null;

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public T1 GetTypedValue<T1>(object item)
        {
            return (T1)Get(item);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is static].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is static]; otherwise, <c>false</c>.
        /// </value>
        public bool IsStatic { get; protected set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the type of the declaring.
        /// </summary>
        /// <value>
        /// The type of the declaring.
        /// </value>
        public Type DeclaringType { get; protected set; }


        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Attribute> GetAttributes()
        {
            if (_attributes == null)
                _attributes = Attribute.GetCustomAttributes(Member).ToList();
            return _attributes;
        }


        /// <summary>
        /// Displays the name.
        /// </summary>
        /// <returns></returns>
        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    _displayName = Name;
                    DisplayNameAttribute a = GetAttributes().OfType<DisplayNameAttribute>().FirstOrDefault();
                    if (a != null)
                        _displayName = a.DisplayName;
                    DisplayAttribute b = GetAttributes().OfType<DisplayAttribute>().FirstOrDefault();
                    if (b != null)
                        _displayName = b.Name;
                }

                return _displayName;
            }
        }

        /// <summary>
        /// Displays the description.
        /// </summary>
        /// <returns></returns>
        public string DisplayDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_displayDesciption))
                {
                    _displayDesciption = Name;
                    DescriptionAttribute a = GetAttributes().OfType<DescriptionAttribute>().FirstOrDefault();
                    if (a != null)
                        _displayDesciption = a.Description;
                }

                return _displayDesciption;
            }
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category
        {
            get
            {
                if (string.IsNullOrEmpty(_category))
                {
                    _category = string.Empty;
                    CategoryAttribute a = GetAttributes().OfType<CategoryAttribute>().FirstOrDefault();
                    if (a != null)
                        _category = a.Category;
                }

                return _category;
            }
        }

        ///// <summary>
        ///// Gets the default value.
        ///// </summary>
        ///// <value>
        ///// The default value.
        ///// </value>
        //public object DefaultValue
        //{
        //    get
        //    {
        //        if (_defaultValue == null)
        //        {
        //            DefaultValueAttribute a = GetAttributes().OfType<DefaultValueAttribute>().FirstOrDefault();
        //            if (a != null)
        //            {
        //                _defaultValue = a.Value;
        //                if (_defaultValue != null)
        //                {
        //                    Type t = _defaultValue.GetType();
        //                    if (t == typeof(string) && t != Type)
        //                        _defaultValue = MyConverter.Unserialize(_defaultValue, Type);
        //                }
        //            }
        //        }
        //        return _defaultValue;
        //    }
        //}

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:IAccessorItem" /> is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if required; otherwise, <c>false</c>.
        /// </value>
        public bool Required
        {
            get
            {

                if (!_required.HasValue)
                {
                    _required = false;
                    RequiredAttribute a = GetAttributes().OfType<RequiredAttribute>().FirstOrDefault();
                    if (a != null)
                        _required = true;
                }

                return _required.Value;

            }
        }

        private List<Attribute> _attributes;
        private bool? _required;
        //private object _defaultValue;
        private string _category;
        private string _displayDesciption;
        private string _displayName;
    }

}
