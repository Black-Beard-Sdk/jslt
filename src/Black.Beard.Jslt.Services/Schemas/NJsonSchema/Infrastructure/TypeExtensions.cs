//-----------------------------------------------------------------------
// <copyright file="XmlDocumentationExtensions.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using Namotion.Reflection;
using Bb.Json;
using NJsonSchema.Generation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NJsonSchema.Infrastructure
{
    /// <summary>Provides extension methods for reading contextual type names and descriptions.</summary>
    public static class TypeExtensions
    {

        private static Dictionary<ContextualMemberInfo, string> _names = new Dictionary<ContextualMemberInfo, string>();
        private static readonly object _lock = new object();

        /// <summary>Gets the name of the property for JSON serialization.</summary>
        /// <returns>The name.</returns>
        internal static string GetName(this ContextualAccessorInfo accessorInfo)
        {
            if (!_names.ContainsKey(accessorInfo))
            {
                lock (_lock)
                {
                    if (!_names.ContainsKey(accessorInfo))
                    {
                        _names[accessorInfo] = GetNameWithoutCache(accessorInfo);
                    }
                }
            }
            return _names[accessorInfo];
        }

        private static string GetNameWithoutCache(ContextualAccessorInfo accessorInfo)
        {
            var jsonPropertyAttribute = accessorInfo.AccessorType.GetContextAttribute<JsonPropertyAttribute>();
            if (jsonPropertyAttribute != null && !string.IsNullOrEmpty(jsonPropertyAttribute.PropertyName))
            {
                return jsonPropertyAttribute.PropertyName;
            }

            var dataMemberAttribute = accessorInfo.AccessorType.GetContextAttribute<DataMemberAttribute>();
            if (dataMemberAttribute != null && !string.IsNullOrEmpty(dataMemberAttribute.Name))
            {
                var dataContractAttribute = accessorInfo.MemberInfo.DeclaringType.ToCachedType().GetInheritedAttribute<DataContractAttribute>();
                if (dataContractAttribute != null)
                {
                    return dataMemberAttribute.Name;
                }
            }

            return accessorInfo.Name;
        }

        /// <summary>Gets the description of the given member (based on the DescriptionAttribute, DisplayAttribute or XML Documentation).</summary>
        /// <param name="type">The member info</param>
        /// <param name="xmlDocsSettings">The XML Docs settings.</param>
        /// <returns>The description or null if no description is available.</returns>
        public static string GetDescription(this CachedType type, IXmlDocsSettings xmlDocsSettings)
        {
            var attributes = type is ContextualType contextualType ? contextualType.ContextAttributes : type.InheritedAttributes;

            var description = GetDescription(attributes);
            if (description != null)
            {
                return description;
            }

            if (xmlDocsSettings.UseXmlDocumentation)
            {
                var summary = type.GetXmlDocsSummary(xmlDocsSettings.ResolveExternalXmlDocumentation);
                if (summary != string.Empty)
                {
                    return summary;
                }
            }

            return null;
        }

        /// <summary>Gets the description of the given member (based on the DescriptionAttribute, DisplayAttribute or XML Documentation).</summary>
        /// <param name="accessorInfo">The accessor info.</param>
        /// <param name="xmlDocsSettings">The XML Docs settings.</param>
        /// <returns>The description or null if no description is available.</returns>
        public static string GetDescription(this ContextualAccessorInfo accessorInfo, IXmlDocsSettings xmlDocsSettings)
        {
            var description = GetDescription(accessorInfo.AccessorType.Attributes);
            if (description != null)
            {
                return description;
            }

            if (xmlDocsSettings.UseXmlDocumentation)
            {
                var summary = accessorInfo.MemberInfo.GetXmlDocsSummary(xmlDocsSettings.ResolveExternalXmlDocumentation);
                if (summary != string.Empty)
                {
                    return summary;
                }
            }

            return null;
        }

        /// <summary>Gets the description of the given member (based on the DescriptionAttribute, DisplayAttribute or XML Documentation).</summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="xmlDocsSettings">The XML Docs settings.</param>
        /// <returns>The description or null if no description is available.</returns>
        public static string GetDescription(this ContextualParameterInfo parameter, IXmlDocsSettings xmlDocsSettings)
        {
            var description = GetDescription(parameter.ContextAttributes);
            if (description != null)
            {
                return description;
            }

            if (xmlDocsSettings.UseXmlDocumentation)
            {
                var summary = parameter.GetXmlDocs(xmlDocsSettings.ResolveExternalXmlDocumentation);
                if (summary != string.Empty)
                {
                    return summary;
                }
            }

            return null;
        }

        private static string GetDescription(IEnumerable<Attribute> attributes)
        {
            dynamic descriptionAttribute = attributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DescriptionAttribute");
            if (descriptionAttribute != null && !string.IsNullOrEmpty(descriptionAttribute.Description))
            {
                return descriptionAttribute.Description;
            }
            else
            {
                dynamic displayAttribute = attributes.FirstAssignableToTypeNameOrDefault("System.ComponentModel.DataAnnotations.DisplayAttribute");
                if (displayAttribute != null)
                {
                    // GetDescription returns null if the Description property on the attribute is not specified.
                    var description = displayAttribute.GetDescription();
                    if (description != null)
                    {
                        return description;
                    }
                }
            }

            return null;
        }
    }
}