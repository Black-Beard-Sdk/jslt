using System.Collections.Generic;

namespace Bb.ComponentModel
{

    public class ExposedTypeConfiguration
    {

        public ExposedTypeConfiguration()
        {
            Attributes = new List<ExposedAttributeTypeConfiguration>();
        }

        public string TypeName { get; set; }

        public List<ExposedAttributeTypeConfiguration> Attributes { get; set; }

    }

}
