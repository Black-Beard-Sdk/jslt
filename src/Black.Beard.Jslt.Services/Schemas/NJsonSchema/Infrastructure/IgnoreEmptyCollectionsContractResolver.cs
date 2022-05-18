﻿//-----------------------------------------------------------------------
// <copyright file="IgnoreEmptyCollectionsContractResolver.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Collections;
using System.Reflection;
using Namotion.Reflection;
using Oldtonsoft.Json;
using Oldtonsoft.Json.Serialization;

namespace NJsonSchema.Infrastructure
{
    internal sealed class IgnoreEmptyCollectionsContractResolver : PropertyRenameAndIgnoreSerializerContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if ((property.Required == Required.Default || property.Required == Required.DisallowNull) &&
                property.PropertyType != typeof(string) &&
                typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(property.PropertyType.GetTypeInfo()))
            {
                property.ShouldSerialize = instance =>
                {
                    var enumerable = instance != null ? property.ValueProvider.GetValue(instance) as IEnumerable : null;
                    if (enumerable != null)
                    {
                        return enumerable.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        return true;
                    }
                };
            }

            return property;
        }
    }
}