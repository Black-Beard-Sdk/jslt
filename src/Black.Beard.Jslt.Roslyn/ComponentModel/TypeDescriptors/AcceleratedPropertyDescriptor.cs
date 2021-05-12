using System;
using System.ComponentModel;

namespace Bb.ComponentModel.TypeDescriptors
{
    public class AcceleratedPropertyDescriptor<TTargetType, TPropertyType> : PropertyDescriptor
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceleratedPropertyDescriptor{TTarget, TProperty}"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="getter">The getter.</param>
        /// <param name="setter">The setter.</param>
        /// <param name="attributes">The attributes.</param>
        public AcceleratedPropertyDescriptor(PropertyDescriptor parent, Func<TTargetType, TPropertyType> getter, Action<TTargetType, TPropertyType> setter, Attribute[] attributes)
              : base(parent, attributes ?? new Attribute[] { })
        {
            this.setter = setter;
            this.getter = getter;
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType => typeof(TTargetType);

        public override object GetValue(object component)
        {
            return getter((TTargetType)component);
        }

        public override bool IsReadOnly => setter == null;

        public override Type PropertyType => typeof(TPropertyType);

        public override void ResetValue(object component)
        {

        }

        public override void SetValue(object component, object value)
        {
            setter((TTargetType)component, (TPropertyType)value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        private readonly Func<TTargetType, TPropertyType> getter;
        private readonly Action<TTargetType, TPropertyType> setter;

    }

}
