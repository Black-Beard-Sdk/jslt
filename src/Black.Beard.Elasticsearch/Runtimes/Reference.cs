using Bb.Elastic.SqlParser.Models;
using System.Collections.Generic;

namespace Bb.Elastic.Runtimes
{
    public class Reference
    {

        public Reference()
        {
        }

        public string Name { get; set; }

        public AstBase Value { get; set; }

        public ReferenceKindEnum Kind { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }


}