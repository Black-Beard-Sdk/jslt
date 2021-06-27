using System;
using System.Diagnostics;
using System.IO;

namespace Bb.CommandLines.Outs
{
    internal static partial class Output
    {

        public static MemoryStream GetStandardRedirection()
        {

            var m = new MemoryStream();
            var standardOutput = new StreamWriter(m);
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);

            return m;

        }

        public static void WriteLine()
        {
            WriteLineStandard(string.Empty);
        }

        public static void WriteLineStandard(this string message)
        {
            Console.Out.WriteLine(message);
        }

        public static void WriteStandard(this string message)
        {
            Console.Out.Write(message);
        }

    }


}
