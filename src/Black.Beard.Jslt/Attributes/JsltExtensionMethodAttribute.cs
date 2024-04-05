using System;
using System.Linq;
using System.Reflection;

namespace Bb.Attributes
{


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class JsltExtensionMethodAttribute : Attribute
    {


        public JsltExtensionMethodAttribute(string name, string description = null)
        {

            Name = name;
            Description = description;
        }


        public string Name { get; }

        public string Description { get; }

        public FunctionKindEnum ForOutput { get; set; } = FunctionKindEnum.FunctionStandard;

        public static JsltExtensionMethodAttribute GetAttribute(MemberInfo method)
        {
            var n = method.GetCustomAttributes(typeof(JsltExtensionMethodAttribute), true).OfType<JsltExtensionMethodAttribute>().FirstOrDefault();
            return n;

        }


    }


    public enum FunctionKindEnum
    {
        Output,
        Writer,
        FunctionStandard
    }


}
