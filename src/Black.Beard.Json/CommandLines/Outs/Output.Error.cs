using System;
using System.Diagnostics;
using System.IO;

namespace Bb.CommandLines.Outs
{

    public static partial class Output
    {

        public static MemoryStream GetErrorRedirection()
        {

            var m = new MemoryStream();
            var standardOutput = new StreamWriter(m);
            standardOutput.AutoFlush = true;
            Console.SetError(standardOutput);

            return m;

        }

        public static void WriteLineError()
        {
            WriteLineError(string.Empty);
        }

        public static void WriteLineError(this string message)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(message);
            Console.ForegroundColor = c;
            Console.Error.Flush();
        }


    }


}
