using System;
using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Bb.ComponentModel.TypeDescriptors
{

    public class AcceleratedTypeDescriptionProvider : TypeDescriptionProvider
    {

        public AcceleratedTypeDescriptionProvider(Type type)
        {
            _provider = TypeDescriptor.GetProvider(type);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            return base.CreateInstance(provider, objectType, argTypes, args);
        }

        /// <summary>
        /// Gets a per-object cache, accessed as an <see cref="T:System.Collections.IDictionary"></see> of key/value pairs.
        /// </summary>
        /// <param name="instance">The object for which to get the cache.</param>
        /// <returns>
        /// An <see cref="System.Collections.IDictionary"></see> if the provided object supports caching; otherwise, null.
        /// </returns>
        public override IDictionary GetCache(object instance)
        {
            return base.GetCache(instance);
        }

        /// <summary>
        /// Gets an extended custom type descriptor for the given object.
        /// </summary>
        /// <param name="instance">The object for which to get the extended type descriptor.</param>
        /// <returns>
        /// An <see cref="System.ComponentModel.ICustomTypeDescriptor"></see> that can provide extended metadata for the object.
        /// </returns>
        public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance)
        {
            return base.GetExtendedTypeDescriptor(instance);
        }

        /// <summary>
        /// Gets the extender providers for the specified object.
        /// </summary>
        /// <param name="instance">The object to get extender providers for.</param>
        /// <returns>
        /// An array of extender providers for <paramref name="instance">instance</paramref>.
        /// </returns>
        protected override IExtenderProvider[] GetExtenderProviders(object instance)
        {
            return base.GetExtenderProviders(instance);
        }

        /// <summary>
        /// Gets the name of the specified component, or null if the component has no name.
        /// </summary>
        /// <param name="component">The specified component.</param>
        /// <returns>
        /// The name of the specified component.
        /// </returns>
        public override string GetFullComponentName(object component)
        {
            return base.GetFullComponentName(component);
        }

        /// <summary>
        /// Performs normal reflection against the given object with the given type.
        /// </summary>
        /// <param name="objectType">The type of object for which to retrieve the <see cref="T:System.Reflection.IReflect"></see>.</param>
        /// <param name="instance">An instance of the type. Can be null.</param>
        /// <returns>
        /// The type of reflection for this <paramref name="objectType">objectType</paramref>.
        /// </returns>
        public override Type GetReflectionType(Type objectType, object instance)
        {
            return base.GetReflectionType(objectType, instance);
        }

        /// <summary>
        /// Converts a reflection type into a runtime type.
        /// </summary>
        /// <param name="reflectionType">The type to convert to its runtime equivalent.</param>
        /// <returns>
        /// A <see cref="System.Type"></see> that represents the runtime equivalent of <paramref name="reflectionType">reflectionType</paramref>.
        /// </returns>
        public override Type GetRuntimeType(Type reflectionType)
        {
            return base.GetRuntimeType(reflectionType);
        }

        /// <summary>
        /// Gets a value that indicates whether the specified type is compatible with the type description and its chain of type description providers.
        /// </summary>
        /// <param name="type">The type to test for compatibility.</param>
        /// <returns>
        /// true if <paramref name="type">type</paramref> is compatible with the type description and its chain of type description providers; otherwise, false.
        /// </returns>
        public override bool IsSupportedType(Type type)
        {
            return base.IsSupportedType(type);
        }

        /// <summary>
        /// Gets a custom type descriptor for the given type and object.
        /// </summary>
        /// <param name="objectType">The type of object for which to retrieve the type descriptor.</param>
        /// <param name="instance">An instance of the type. Can be null if no instance was passed to the <see cref="T:System.ComponentModel.TypeDescriptor"></see>.</param>
        /// <returns>
        /// An <see cref="System.ComponentModel.ICustomTypeDescriptor"></see> that can provide metadata for the type.
        /// </returns>
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new AcceleratedCustomTypeDescriptor(this, _provider.GetTypeDescriptor(objectType, instance));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        private class AcceleratedCustomTypeDescriptor : CustomTypeDescriptor
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="AcceleratedCustomTypeDescriptor"/> class.
            /// </summary>
            /// <param name="provider">The provider.</param>
            /// <param name="descriptor">The descriptor.</param>
            public AcceleratedCustomTypeDescriptor(AcceleratedTypeDescriptionProvider provider, ICustomTypeDescriptor descriptor)
                  : base(descriptor)
            {
                _provider = provider;
            }

            /// <summary>
            /// Returns a collection of property descriptors for the object represented by this type descriptor.
            /// </summary>
            /// <returns>
            /// A <see cref="System.ComponentModel.PropertyDescriptorCollection"></see> containing the property descriptions for the object represented by this type descriptor. The default is <see cref="System.ComponentModel.PropertyDescriptorCollection.Empty"></see>.
            /// </returns>
            public override PropertyDescriptorCollection GetProperties()
            {
                return GetProperties(null);
            }

//            public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
//            {
//                var properties = new PropertyDescriptorCollection(null);

//                foreach (PropertyDescriptor property in base.GetProperties(attributes))
//                {

//            var m = property.P.GetMethod ?? property.SetMethod;

//            var isStatic = m != null ? (m.Attributes & MethodAttributes.Static) == MethodAttributes.Static : false;


//var getValue =
//                Expression.Lambda<Func<object, object>>
//                (
//                    Expression.Convert
//                    (
//                        Expression.Property
//                        (
//                            isStatic ? null : Expression.Convert(sourceParameterExpr, componentType),
//                            property
//                        ),
//                        typeof(object)
//                    ),
//                    sourceParameterExpr
//                ).Compile();


//                    var prop = new AcceleratedPropertyDescriptor(property, );


//                    properties.Add(prop);
//                }

//                return properties;
//            }

            private readonly AcceleratedTypeDescriptionProvider _provider;

        }

        private readonly TypeDescriptionProvider _provider;

    }

    //public class AcceleratedPropertyManager<TTarget> : IDisposable
    //{

    //    public AcceleratedPropertyManager()
    //    {
    //        Type type = typeof(TTarget);

    //        provider = new AcceleratedTypeDescriptionProvider(type);
    //        TypeDescriptor.AddProvider(provider, type);
    //    }

    //    public AcceleratedPropertyManager(TTarget target)
    //    {
    //        this.target = target;

    //        provider = new AcceleratedTypeDescriptionProvider(typeof(TTarget));
    //        TypeDescriptor.AddProvider(provider, target);
    //    }

    //    public void Dispose()
    //    {
    //        if (ReferenceEquals(target, null))
    //        {
    //            TypeDescriptor.RemoveProvider(provider, typeof(TTarget));
    //        }
    //        else
    //        {
    //            TypeDescriptor.RemoveProvider(provider, target);
    //        }
    //    }

    //    public static AcceleratedPropertyDescriptor<TTargetType, TPropertyType>
    //       CreateProperty<TTargetType, TPropertyType>(
    //           string displayName,
    //           Func<TTargetType, TPropertyType> getter,
    //           Action<TTargetType, TPropertyType> setter,
    //           Attribute[] attributes)
    //    {
    //        return new AcceleratedPropertyDescriptor<TTargetType, TPropertyType>(
    //           displayName, getter, setter, attributes);
    //    }

    //    public static AcceleratedPropertyDescriptor<TTargetType, TPropertyType>
    //       CreateProperty<TTargetType, TPropertyType>(
    //          string displayName,
    //          Func<TTargetType, TPropertyType> getHandler,
    //          Attribute[] attributes)
    //    {
    //        return new AcceleratedPropertyDescriptor<TTargetType, TPropertyType>(
    //           displayName, getHandler, (t, p) => { }, attributes);
    //    }

    //    private readonly AcceleratedTypeDescriptionProvider provider;
    //    private readonly TTarget target;

    //}

}
