using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bb.ConvertToDatables
{
    internal class SourceMappingProperty
    {

        public SourceMappingProperty()
        {
            this.TargetColumns = new List<TargetMappingProperty>();
        }


        public string Name { get; set; }


        public List<TargetMappingProperty> TargetColumns { get; set; }



        internal void AppendTargetPath(string value, string name, StructureSchema schema)
        {
            var path = value.ToLower();
            var valuePath = path.Split('.');
            var column = schema.Get<StructureColumn>(path);
            TargetColumns.Add(new TargetMappingProperty(column));
        }


    }

}
