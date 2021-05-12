using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel.Accessors
{

    /// <summary>
    /// Base accessor
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class AccessorItem
    {

        List<Attribute> _attributes;
        private string _displayName = null;
        private string _category = null;
        string _displayDesciption = null;
        private bool? _required = null;
        private dynamic _defaultValue = null;
        /// <summary>
        /// The _accessors
        /// </summary>
        protected static Dictionary<Type, AccessorList> _accessors = new Dictionary<Type, AccessorList>();
        /// <summary>
        /// The _lock
        /// </summary>
        protected static volatile object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorItem"/> class.
        /// </summary>
        /// <param name="memberTypeEnum">The member type enum.</param>
        protected AccessorItem(MemberTypeEnum memberTypeEnum)
        {
            // TODO: Complete member initialization
            this.TypeEnum = memberTypeEnum;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the type enum.
        /// </summary>
        /// <value>
        /// The type enum.
        /// </value>
        public MemberTypeEnum TypeEnum { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether [can write].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can write]; otherwise, <c>false</c>.
        /// </value>
        public bool CanWrite { get { return SetValue != null; } }

        /// <summary>
        /// Gets a value indicating whether [can read].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can read]; otherwise, <c>false</c>.
        /// </value>
        public bool CanRead { get { return GetValue != null; } }

        /// <summary>
        /// Gets a value indicating whether [is clonable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is clonable]; otherwise, <c>false</c>.
        /// </value>
        public bool IsClonable { get { return GetValue != null && SetValue != null; } }

        /// <summary>
        /// Gets or sets the get value method.
        /// </summary>
        /// <value>
        /// The get value.
        /// </value>
        public Func<object, object> GetValue { get; protected set; }

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public T1 GetTypedValue<T1>(object item)
        {
            return (T1)GetValue(item);
        }

        /// <summary>
        /// Gets or sets the set value method.
        /// </summary>
        /// <value>
        /// The set value.
        /// </value>
        public Action<object, object> SetValue { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public Type Type { get; protected set; }

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
        /// Gets or sets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public MemberInfo Member { get; protected set; }

        /// <summary>
        /// Gets or sets the type of the declaring.
        /// </summary>
        /// <value>
        /// The type of the declaring.
        /// </value>
        public Type DeclaringType { get; protected set; }

        /// <summary>
        /// Gets the specified component type.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <param name="withSubType">if set to <c>true</c> [with sub type].</param>
        /// <returns></returns>
        internal static AccessorList Get(Type componentType, bool withSubType = false)
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

        /// <summary>
        /// Gets the attribute's list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Attribute> GetAttributes()
        {
            if (_attributes == null)
                _attributes = TypeDescriptor.GetAttributes(Member).OfType<Attribute>().ToList();
            return _attributes;
        }

        /// <summary>
        /// Gets the validated value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public object GetValidatedValue(object instance, IEnumerable<ValidationAttribute> attributes = null)
        {
            var v1 = GetValue(instance);
            ValidateMember(v1, true, attributes);
            return v1;
        }

        /// <summary>
        /// Validates the member.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="throwException">if set to <c>true</c> [throw exception].</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public ValidationException ValidateMember(object model, bool throwException, IEnumerable<ValidationAttribute> attributes = null)
        {

            var _a = attributes;
            if (_a == null || _a.Count() == 0)
                _a = GetAttributes().OfType<ValidationAttribute>().ToList();

            var _c = GetAttributes().ToList();

            //var r = value.Validate(this.Member, _a);
            ValidationException validationException = GetValidationException(model, _a);

            if (throwException && validationException != null)
                throw validationException;

            return validationException;

        }


        /// <summary>
        /// Gets the validation exception.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="_a">The validationAttributes.</param>
        private ValidationException GetValidationException(object model, IEnumerable<ValidationAttribute> _a)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            bool result = Validator.TryValidateValue(this.GetValue(model), new ValidationContext(new object(), null, null), results, _a);
            ValidationException v1 = null;

            if (!result)
            {
                v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", this.Member.Name));

                foreach (var item in results)
                {
                    ValidationException v = new ValidationException(item.ErrorMessage, null, model);
                    v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                }
            }
            return v1;
        }


        /// <summary>
        /// Determines whether this instance contains attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ContainsAttribute<T>()
            where T : Attribute
        {
            return GetAttributes().OfType<T>().Any();
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
                    _displayName = this.Name;
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
                    _displayDesciption = this.Name;
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

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public dynamic DefaultValue
        {
            get
            {
                if (_defaultValue == null)
                {
                    DefaultValueAttribute a = GetAttributes().OfType<DefaultValueAttribute>().FirstOrDefault();
                    if (a != null)
                    {
                        _defaultValue = a.Value;
                        if (_defaultValue != null)
                        {
                            Type t = _defaultValue.GetType();
                            if (t == typeof(string) && t != Type)
                                _defaultValue = MyConverter.Unserialize(_defaultValue, Type);
                        }
                    }
                }
                return _defaultValue;
            }
        }

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

        #endregion Attributes / validations


        #region Serialize /Unserialize

        /// <summary>
        /// Serializes the specified member for instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public string Serialize(object instance)
        {
            return MyConverter.Serialize(GetValue(instance));
        }

        /// <summary>
        /// Unserializes the value int the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.InvalidCastException"></exception>
        public void Unserialize(object instance, string value)
        {
            try
            {
                dynamic result = MyConverter.Unserialize(value, Type);
                SetValue(instance, result);
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format("invalid cast in the property '{0}'. The value '{1}' can't be casted in '{2}'", Name, value, Type.Name), e);
            }
        }

        #endregion



        /// <summary>
        /// Determines whether [is].
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <returns></returns>
        public bool Is<T1>()
        {
            return Type.IsAssignableFrom(typeof(T1));
        }


    }



    /// <summary>
    /// /// member's type 
    /// </summary>
    public enum MemberTypeEnum
    {
        /// <summary>
        /// The member is of type property
        /// </summary>
        Property,

        /// <summary>
        /// The member is of type field
        /// </summary>
        Field

    }


}
