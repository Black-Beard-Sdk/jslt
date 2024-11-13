﻿//-----------------------------------------------------------------------
// <copyright file="PropertyNameHandling.cs" company="NJsonSchema">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/RicoSuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;
using Bb.Json;
using Bb.Json.Serialization;

namespace NJsonSchema.Generation
{
    /// <summary>Defines the property name handling.</summary>
    public enum PropertyNameHandling
    {
        /// <summary>Generates property name using reflection (respecting the <see cref="JsonPropertyAttribute"/> and <see cref="DataMemberAttribute"/>).</summary>
        Default,

        /// <summary>Generates lower camel cased property names using <see cref="CamelCasePropertyNamesContractResolver"/>.</summary>
        CamelCase,

        /// <summary>Generates snake cased property names using <see cref="SnakeCaseNamingStrategy"/>.</summary>
        SnakeCase
    }
}