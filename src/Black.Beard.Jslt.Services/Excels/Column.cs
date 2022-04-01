using System;

namespace Bb.Jslt.Services.Excels
{

    [System.Diagnostics.DebuggerDisplay("{Name} {Index}")]
    public class Column
    {

        public int Index { get; set; }

        public string Name { get; set; }

        public bool Trimmed { get; set; } = true;

        public Type Type { get; set; } = typeof(string);

        public bool BypassEmptyValue { get; set; } = true;

    }


}
