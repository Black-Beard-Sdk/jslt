using System;

namespace Bb.Jslt.Services.Excels
{

    public class Column
    {

        public int Index { get; set; }

        public string Name { get; set; }

        public bool Trimmed { get; set; } = true;

        public Type Type { get; set; } = typeof(string);

        public bool BypassEmptyValue { get; set; } = true;

    }


}
