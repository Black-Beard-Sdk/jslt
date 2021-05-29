using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Json.Attributes
{


    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class JsltExtensionMethodAttribute : Attribute
    {


        public JsltExtensionMethodAttribute(string name, string description = null)
        {

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }


        public static JsltExtensionMethodAttribute GetAttribute(MemberInfo method)
        {
            var n = method.GetCustomAttributes(typeof(JsltExtensionMethodAttribute), true).OfType<JsltExtensionMethodAttribute>().FirstOrDefault();
            return n;

        }


    }

}
