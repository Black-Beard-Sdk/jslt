﻿//-----------------------------------------------------------------------
// <copyright file="JsonInheritanceConverter.cs" company="NJsonSchema">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/RicoSuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using Namotion.Reflection;
using Oldtonsoft.Json;
using Oldtonsoft.Json.Linq;
using Oldtonsoft.Json.Serialization;

namespace NJsonSchema.Converters
{
    // TODO: Add caching

    /// <summary>Defines the class as inheritance base class and adds a discriminator property to the serialized object.</summary>
    public class JsonInheritanceConverter : JsonConverter
    {
        /// <summary>Gets the default discriminiator name.</summary>
        public static string DefaultDiscriminatorName { get; } = "discriminator";

        private readonly Type _baseType;
        private readonly string _discriminatorName;
        private readonly bool _readTypeProperty;

        [ThreadStatic]
        private static bool _isReading;

        [ThreadStatic]
        private static bool _isWriting;

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class.</summary>
        public JsonInheritanceConverter()
            : this(DefaultDiscriminatorName, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class.</summary>
        /// <param name="discriminatorName">The discriminator.</param>
        public JsonInheritanceConverter(string discriminatorName)
            : this(discriminatorName, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class.</summary>
        /// <param name="discriminatorName">The discriminator property name.</param>
        /// <param name="readTypeProperty">Read the $type property to determine the type 
        /// (fallback, should not be used as it might lead to security problems).</param>
        public JsonInheritanceConverter(string discriminatorName, bool readTypeProperty)
        {
            _discriminatorName = discriminatorName;
            _readTypeProperty = readTypeProperty;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class which only applies for the given base type.</summary>
        /// <remarks>Use this constructor for global registered converters (not defined on class).</remarks>
        /// <param name="baseType">The base type.</param>
        public JsonInheritanceConverter(Type baseType)
            : this(baseType, DefaultDiscriminatorName, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class which only applies for the given base type.</summary>
        /// <remarks>Use this constructor for global registered converters (not defined on class).</remarks>
        /// <param name="baseType">The base type.</param>
        /// <param name="discriminatorName">The discriminator.</param>
        public JsonInheritanceConverter(Type baseType, string discriminatorName)
            : this(baseType, discriminatorName, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JsonInheritanceConverter"/> class which only applies for the given base type.</summary>
        /// <remarks>Use this constructor for global registered converters (not defined on class).</remarks>
        /// <param name="baseType">The base type.</param>
        /// <param name="discriminatorName">The discriminator.</param>
        /// <param name="readTypeProperty">Read the $type property to determine the type 
        /// (fallback, should not be used as it might lead to security problems).</param>
        public JsonInheritanceConverter(Type baseType, string discriminatorName, bool readTypeProperty)
            : this(discriminatorName, readTypeProperty)
        {
            _baseType = baseType;
        }

        /// <summary>Gets the discriminator property name.</summary>
        public virtual string DiscriminatorName => _discriminatorName;

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Oldtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                _isWriting = true;

                var jObject = JObject.FromObject(value, serializer);
                jObject[_discriminatorName] = JToken.FromObject(GetDiscriminatorValue(value.GetType()));
                writer.WriteToken(jObject.CreateReader());
            }
            finally
            {
                _isWriting = false;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Oldtonsoft.Json.JsonConverter" /> can write JSON.</summary>
        public override bool CanWrite
        {
            get
            {
                if (_isWriting)
                {
                    _isWriting = false;
                    return false;
                }
                return true;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Oldtonsoft.Json.JsonConverter" /> can read JSON.</summary>
        public override bool CanRead
        {
            get
            {
                if (_isReading)
                {
                    _isReading = false;
                    return false;
                }
                return true;
            }
        }

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            if (_baseType != null)
            {
                var type = objectType;
                while (type != null)
                {
                    if (type == _baseType)
                    {
                        return true;
                    }

                    type = type.GetTypeInfo().BaseType;
                }

                return false;
            }

            return true;
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Oldtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = serializer.Deserialize<JObject>(reader);
            if (jObject == null)
            {
                return null;
            }

            var discriminator = jObject.GetValue(_discriminatorName, StringComparison.OrdinalIgnoreCase)?.Value<string>();
            var subtype = GetDiscriminatorType(jObject, objectType, discriminator);

            var objectContract = serializer.ContractResolver.ResolveContract(subtype) as JsonObjectContract;
            if (objectContract == null || objectContract.Properties.All(p => p.PropertyName != _discriminatorName))
            {
                jObject.Remove(_discriminatorName);
            }

            try
            {
                _isReading = true;
                return serializer.Deserialize(jObject.CreateReader(), subtype);
            }
            finally
            {
                _isReading = false;
            }
        }

        /// <summary>Gets the discriminator value for the given type.</summary>
        /// <param name="type">The object type.</param>
        /// <returns>The discriminator value.</returns>
        public virtual string GetDiscriminatorValue(Type type)
        {
            var jsonInheritanceAttributeDiscriminator = GetSubtypeDiscriminator(type);
            if (jsonInheritanceAttributeDiscriminator != null)
            {
                return jsonInheritanceAttributeDiscriminator;
            }

            return type.Name;
        }

        /// <summary>Gets the type for the given discriminator value.</summary>
        /// <param name="jObject">The JSON object.</param>
        /// <param name="objectType">The object (base) type.</param>
        /// <param name="discriminatorValue">The discriminator value.</param>
        /// <returns></returns>
        protected virtual Type GetDiscriminatorType(JObject jObject, Type objectType, string discriminatorValue)
        {
            var jsonInheritanceAttributeSubtype = GetObjectSubtype(objectType, discriminatorValue);
            if (jsonInheritanceAttributeSubtype != null)
            {
                return jsonInheritanceAttributeSubtype;
            }

            if (objectType.Name == discriminatorValue)
            {
                return objectType;
            }

            var knownTypeAttributesSubtype = GetSubtypeFromKnownTypeAttributes(objectType, discriminatorValue);
            if (knownTypeAttributesSubtype != null)
            {
                return knownTypeAttributesSubtype;
            }

            var typeName = objectType.Namespace + "." + discriminatorValue;
            var subtype = objectType.GetTypeInfo().Assembly.GetType(typeName);
            if (subtype != null)
            {
                return subtype;
            }

            if (_readTypeProperty)
            {
                var typeInfo = jObject.GetValue("$type");
                if (typeInfo != null)
                {
                    return Type.GetType(typeInfo.Value<string>());
                }
            }

            throw new InvalidOperationException("Could not find subtype of '" + objectType.Name + "' with discriminator '" + discriminatorValue + "'.");
        }

        private Type GetSubtypeFromKnownTypeAttributes(Type objectType, string discriminator)
        {
            var type = objectType;
            do
            {
                var knownTypeAttributes = type.GetTypeInfo().GetCustomAttributes(false)
                    .Where(a => a.GetType().Name == "KnownTypeAttribute");
                foreach (dynamic attribute in knownTypeAttributes)
                {
                    if (attribute.Type != null && attribute.Type.Name == discriminator)
                    {
                        return attribute.Type;
                    }
                    else if (attribute.MethodName != null)
                    {
                        var method = type.GetRuntimeMethod((string)attribute.MethodName, new Type[0]);
                        if (method != null)
                        {
                            var types = (System.Collections.Generic.IEnumerable<Type>)method.Invoke(null, new object[0]);
                            foreach (var knownType in types)
                            {
                                if (knownType.Name == discriminator)
                                {
                                    return knownType;
                                }
                            }
                            return null;
                        }
                    }
                }
                type = type.GetTypeInfo().BaseType;
            } while (type != null);

            return null;
        }

        private static Type GetObjectSubtype(Type baseType, string discriminatorName)
        {
            var jsonInheritanceAttributes = baseType
                .GetTypeInfo()
                .GetCustomAttributes(true)
                .OfType<JsonInheritanceAttribute>();

            return jsonInheritanceAttributes.SingleOrDefault(a => a.Key == discriminatorName)?.Type;
        }

        private static string GetSubtypeDiscriminator(Type objectType)
        {
            var jsonInheritanceAttributes = objectType
                .GetTypeInfo()
                .GetCustomAttributes(true)
                .OfType<JsonInheritanceAttribute>();

            return jsonInheritanceAttributes.SingleOrDefault(a => a.Type == objectType)?.Key;
        }
    }
}
