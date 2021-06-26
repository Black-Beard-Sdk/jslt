using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;

namespace Bb.Expressions.CsharpGenerators
{
    internal sealed class ExposedTabStringIndentedTextWriter : IndentedTextWriter
    {
        public ExposedTabStringIndentedTextWriter(TextWriter writer, string tabString) : base(writer, tabString)
        {
            Debug.Assert(tabString != null, "CodeGeneratorOptions can never have a null TabString");
            TabString = tabString;
        }

        internal void InternalOutputTabs()
        {
            TextWriter inner = InnerWriter;
            for (int i = 0; i < Indent; i++)
            {
                inner.Write(TabString);
            }
        }

        internal string TabString { get; } // IndentedTextWriter doesn't expose this publicly
    }

}