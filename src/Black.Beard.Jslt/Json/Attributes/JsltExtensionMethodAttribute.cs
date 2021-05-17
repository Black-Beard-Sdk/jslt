using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Json.Attributes
{

    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class JsltExtensionMethodAttribute : Attribute
    {


        public JsltExtensionMethodAttribute(string name)
        {

            this.Name = name;
           
        }

        public string Name { get; }

    }

}
