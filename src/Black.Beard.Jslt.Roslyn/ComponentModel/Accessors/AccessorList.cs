using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;


namespace Bb.ComponentModel.Accessors
{

    /// <summary>
    /// list of Accessors
    /// </summary>
    public class AccessorList : IEnumerable<AccessorItem>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorList"/> class.
        /// </summary>
        internal AccessorList()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorList"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public AccessorList(IEnumerable<AccessorItem> list)
        {
            foreach (var item in list)
                _list.Add(item.Name, item);
        }

        private Dictionary<string, AccessorItem> _list = new Dictionary<string, AccessorItem>();

        /// <summary>
        /// The _lock
        /// </summary>
        public volatile object _lock = new object();

        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public bool TryGetValue(string name, out AccessorItem member)
        {
            return _list.TryGetValue(name, out member);
        }

        /// <summary>
        /// Determines whether the specified name contains key.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool ContainsKey(string name)
        {
            return _list.ContainsKey(name);
        }

        /// <summary>
        /// Adds the specified property accessor.
        /// </summary>
        /// <param name="propertyAccessor">The property accessor.</param>
        public void Add(AccessorItem propertyAccessor)
        {
            if (!_list.ContainsKey(propertyAccessor.Name))
                _list.Add(propertyAccessor.Name, propertyAccessor);
        }

        /// <summary>
        /// Removes the specified property accessor.
        /// </summary>
        /// <param name="propertyAccessor">The property accessor.</param>
        public void Remove(AccessorItem propertyAccessor)
        {
            _list.Remove(propertyAccessor.Name);
        }

        /// <summary>
        /// Removes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Remove(string name)
        {
            _list.Remove(name);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<AccessorItem> GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }

        /// <summary>
        /// Gets or sets the <see cref="T:IAccessorItem"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="AccessorItem"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public AccessorItem this[string name]
        {
            get
            {
                if (_list.ContainsKey(name))
                    return _list[name];
                return null;
            }
            set
            {
                if (_list.ContainsKey(name))
                    _list[name] = value as AccessorItem;
                else
                    _list.Add(value.Name, value as AccessorItem);
            }
        }

        /// <summary>
        /// Gets the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns></returns>
        public AccessorItem Get(string memberName, bool respectCase = true)
        {

            var result = this[memberName];

            if (result == null && !respectCase)
                foreach (var item in this)
                    if (item.Name.ToLower() == memberName.ToLower())
                    {
                        result = item;
                        break;
                    }

            return result;

        }

        /// <summary>
        /// Gets or sets the <see cref="AccessorItem"/> with the specified member.
        /// </summary>
        /// <value>
        /// The <see cref="AccessorItem"/>.
        /// </value>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public AccessorItem this[MemberInfo member]
        {
            get => this[member.Name];
            set => this[member.Name] = value as AccessorItem;
        }

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        public void Map(object source, object target)
        {
            foreach (var item in _list)
            {
                var i = item.Value;
                if (i.IsClonable)
                {
                    var data = i.GetValue(source);
                    i.SetValue(target, data);
                }
            }
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <returns></returns>
        internal static IEnumerable<PropertyInfo> GetProperties(Type componentType)
        {
            var type = componentType;
            while (type != null && type != typeof(object))
            {
                foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                    yield return item;

                type = type.BaseType;

            }
        }

        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void Validate(object instance)
        {

            ValidationException e = new ValidationException("Validation exception. Please see the data collection for more informations.");

            foreach (var item in _list)
            {

                var v1 = item.Value.GetValue(instance);
                //var e1 = item.Value.ValidateMember(v1, false);
                var e1 = item.Value.ValidateMember(instance, false);
                if (e1 != null)
                    foreach (var item3 in e1.Data.Values)
                        e.Data.Add("exception" + (e.Data.Count + 1).ToString(), item3);

                var _a = item.Value.GetAttributes().OfType<ValidationAttribute>().ToList();
                var validationException = ValidateMember(v1, item.Value.Member, _a);

                if (validationException != null)
                    foreach (var item3 in validationException.Data.Values)
                        e.Data.Add("exception" + (e.Data.Count + 1).ToString(), item3);

            }

            if (e.Data.Count > 0)
                throw e;

        }

        /// <summary>
        /// Validates the specified dob.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="member">The member.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        private ValidationException ValidateMember(object value, MemberInfo member, IEnumerable<ValidationAttribute> attributes)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            bool result = Validator.TryValidateValue(value, new ValidationContext(new object(), null, null), results, attributes);

            if (!result)
            {

                ValidationException v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", member.Name));

                foreach (var item in results)
                {
                    ValidationException v = new ValidationException(item.ErrorMessage, null, value) { /*HResult = (int)CommonErrorsEnum.ValidationException Source = ExceptionManager.Source */ };
                    v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                }

                return v1;
            }

            return null;

        }



    }

    /// <summary>
    /// Validation Helper
    /// </summary>
    public static class ValidationHelper
    {

        /// <summary>
        /// Validates the specified dob.
        /// </summary>
        /// <param name="dob">The dob.</param>
        /// <param name="member">The member.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public static ValidationException Validate(this object dob, MemberInfo member, IEnumerable<ValidationAttribute> attributes)
        {

            List<ValidationResult> results = new List<ValidationResult>();

            bool result = Validator.TryValidateValue(dob, new ValidationContext(new object(), null, null), results, attributes);

            if (!result)
            {

                ValidationException v1 = new ValidationException(string.Format("Validation exception on the property '{0}'. Please see the Data collection for more informations.", member.Name));

                foreach (var item in results)
                {
                    ValidationException v = new ValidationException(item.ErrorMessage, null, dob) { /*HResult = (int)CommonErrorsEnum.ValidationException Source = ExceptionManager.Source */ };
                    v1.Data.Add("exception" + (v1.Data.Count + 1).ToString(), v);
                }

                return v1;
            }

            return null;

        }
    }


}
