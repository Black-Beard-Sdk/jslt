using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Bb
{
    /// <summary>
    /// Provides helper methods for working with connection strings and mapping arguments to objects.
    /// </summary>
    public static class ConnectionStringHelper
    {
        /// <summary>
        /// Generates a help string for the specified type, describing its properties.
        /// </summary>
        /// <param name="self">The type for which to generate the help string.</param>
        /// <remarks>
        /// This method inspects the properties of the provided type and generates a detailed description
        /// including property names, types, and additional metadata such as whether the property is required.
        /// </remarks>
        /// <returns>
        /// A <see cref="string"/> containing the generated help documentation.
        /// </returns>
        /// <example>
        /// <code lang="C#">
        /// var helpText = ConnectionStringHelper.GenerateHelp(typeof(MyClass));
        /// Console.WriteLine(helpText);
        /// </code>
        /// </example>
        public static string GenerateHelp(Type self)
        {

            Dictionary<string, Property> properties = self.GetPropertiesAccessor();

            StringBuilder sb = new StringBuilder(properties.Count() * 800);
            sb.AppendLine(string.Empty);

            foreach (var item in properties)
            {

                Property property = item.Value;

                if (!property.CanWrite)
                    continue;

                sb.AppendLine(property.Name);
                sb.AppendLine($"\ttype : {property.Type.Name}");

                if (property.Required)
                    sb.AppendLine("\tRequired");

                if (!string.IsNullOrEmpty(property.DisplayDescription))
                    sb.AppendLine($"\tdescription : {property.DisplayDescription}");

                //if (property.DefaultValue != null)
                //    sb.AppendLine($"\tdefault value : {property.DefaultValue}");

                if (property.Type.IsEnum)
                {
                    sb.Append("\tRestricted values (");
                    foreach (var item2 in Enum.GetNames(property.Type))
                        sb.Append($"{item2}, ");
                    sb.Remove(sb.Length - 2, 2);
                    sb.AppendLine(")");
                }

            }

            return sb.ToString();

        }

        /// <summary>
        /// Converts a semicolon-separated string of key-value pairs into a dictionary.
        /// </summary>
        /// <param name="arguments">The semicolon-separated string of key-value pairs.</param>
        /// <remarks>
        /// This method parses the input string and resolves environment variables if the value starts with '@'.
        /// </remarks>
        /// <returns>
        /// A <see cref="Dictionary{TKey, TValue}"/> where the keys and values are strings.
        /// </returns>
        /// <example>
        /// <code lang="C#">
        /// var dictionary = "key1=value1;key2=value2".ToDictionary();
        /// foreach (var kvp in dictionary)
        /// {
        ///     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        /// }
        /// </code>
        /// </example>
        public static Dictionary<string, string> ToDictionary(this string arguments)
        {

            Dictionary<string, string> result = new Dictionary<string, string>();

            var members = arguments.Split(';');

            foreach (var item in members)
            {

                if (string.IsNullOrEmpty(item))
                    continue;

                var ii = item.Split('=');

                var key = ii[0].Trim();
                var valueText = string.Join("=", ii.Skip(1));
                if (string.IsNullOrEmpty(valueText))
                    continue;

                valueText = valueText.Trim();

                if (valueText.StartsWith("@"))
                {
                    var newValueText = Environment.GetEnvironmentVariable(valueText.Substring(1));
                    if (!string.IsNullOrEmpty(newValueText))
                        valueText = newValueText;
                }
                else
                    Trace.WriteLine($"environment variable {valueText} not found", TraceLevel.Warning.ToString());

                result.Add(key, valueText);

            }

            return result;

        }

        /// <summary>
        /// Maps the provided dictionary of arguments to the properties of the specified object.
        /// </summary>
        /// <param name="self">The object to map the arguments to.</param>
        /// <param name="arguments">A dictionary containing the arguments to map.</param>
        /// <param name="respectCase">Indicates whether to respect case sensitivity when matching property names.</param>
        /// <remarks>
        /// This method attempts to map each key-value pair in the dictionary to a writable property on the object.
        /// It supports basic types, value types, and generic lists.
        /// </remarks>
        /// <returns>
        /// A <see cref="bool"/> indicating whether all required properties were successfully mapped.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if a required property is not found in the dictionary or cannot be mapped.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var obj = new MyClass();
        /// var arguments = new Dictionary&lt;string, string&gt; { { "Property1", "Value1" } };
        /// bool success = ConnectionStringHelper.Map(obj, arguments);
        /// Console.WriteLine(success ? "Mapping succeeded" : "Mapping failed");
        /// </code>
        /// </example>
        public static bool Map(object self, Dictionary<string, string> arguments, bool respectCase = false)
        {

            Dictionary<string, Property> properties = self.GetType().GetPropertiesAccessor();

            foreach (var item in arguments)
            {
                var key = item.Key;
                var valueText = item.Value;

                Property property;
                if (respectCase)
                    property = properties[key];
                else
                    property = properties.FirstOrDefault(c => c.Key.ToLower() == key.ToLower()).Value;

                if (property != null)
                {

                    if ((typeof(string) == property.Type || property.Type.IsValueType) && property.CanWrite)
                    {
                        object value = MyConverter.Unserialize(valueText, property.Type);
                        property.Set(self, value);
                    }
                    else if (typeof(IList).IsAssignableFrom(property.Type) && property.Type.IsGenericType)
                    {

                        var p = property.Type.GetGenericArguments();
                        //if (p.Length > 1) { }

                        var type = p[0];

                        object value = property.Get(self);

                        if (value == null)
                        {
                            if (property.CanWrite)
                            {
                                value = Activator.CreateInstance(property.Type);
                                property.Set(self, value);
                            }
                            else
                                continue;
                        }

                        var jj = valueText.Split(',');
                        foreach (var item3 in jj)
                        {

                            string subValueText = item3.Trim();

                            if (item3.StartsWith("@"))
                            {
                                var newValueText = Environment.GetEnvironmentVariable(item3.Substring(1));
                                if (!string.IsNullOrEmpty(newValueText))
                                    subValueText = newValueText;
                                else
                                    Trace.WriteLine($"environment variable {item3} not found", TraceLevel.Warning.ToString());
                            }

                            object value2 = MyConverter.Unserialize(subValueText.Trim(), type);
                            (value as IList).Add(value2);
                        }

                    }

                }

            }

            bool result = true;

            foreach (var item in properties)
            {
                if (item.Value.Required && item.Value.Get(self) == null)
                {
                    Trace.WriteLine($"{item.Value.Name} is required");
                    result = false;
                }
            }

            return result;

        }

    }
}
