using Bb.ComponentModel.Factories;
using System;
using System.Linq;
using System.Text;

namespace Bb.Json.Attributes
{
    [System.AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false, AllowMultiple = true)]
    sealed class JsltExtensionMethodParameterAttribute : Attribute
    {

        // This is a positional argument
        public JsltExtensionMethodParameterAttribute(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }


        public static MethodDescription Map(MethodDescription method)
        {

            var n = method.Method.GetCustomAttributes(typeof(JsltExtensionMethodParameterAttribute), true).OfType<JsltExtensionMethodParameterAttribute>().ToDictionary(c => c.Name);
            foreach (var item in method.Parameters)
            {
                if (n.TryGetValue(item.Name, out JsltExtensionMethodParameterAttribute pp))
                {
                    item.Description = pp.Description;
                }
            }

            method.Content = GetContent(method);

            return method;

        }

        private static string GetContent(MethodDescription method)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(method.Name);
            sb.Append("(");
            string comma = string.Empty;

            foreach (var item in method.Parameters.Skip(1))
            {
                sb.Append(comma);
                sb.Append(item.Name);

                if (!string.IsNullOrEmpty(item.Description))
                {
                    sb.Append("<");
                    sb.Append(item.Description);
                    sb.Append(">");
                }

                comma = ", ";
            }

            sb.Append(")");

            return sb.ToString();

        }
    }

}
