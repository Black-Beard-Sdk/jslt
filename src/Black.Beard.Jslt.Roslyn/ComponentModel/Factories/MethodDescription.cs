using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bb.ComponentModel.Factories
{
    public class MethodDescription
    {

        public MethodDescription(string name, MethodBase method)
        {
            Method = method;
            this.Name = name;
            var parameters = method.GetParameters();
            this.Parameters = new List<ArgumentDescription>(parameters.Length);
            foreach (var item in parameters)
            {
                var p = new ArgumentDescription(item.Name, item)
                {
                    Name = item.Name,
                    Parameter = item,
                };
                this.Parameters.Add(p);
            }
        }

        public string Name { get; }

        public string Description { get; set; }

        
        public List<ArgumentDescription> Parameters { get; }
        
        public MethodBase Method { get; set; }
        public string Content { get; set; }

    }
}
