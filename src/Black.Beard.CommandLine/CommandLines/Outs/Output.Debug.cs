using System;
using System.Diagnostics;
using System.IO;

namespace Bb.CommandLines.Outs
{
    public static partial class Output
    {

        public static void WriteLineDebug()
        {
            Console.Out.WriteLine(string.Empty);
        }

        public static void WriteLineDebug(this string message)
        {
            Console.Out.WriteLine(message);
        }

        public static void WriteDebug(string message)
        {
            Console.Out.Write(message);
        }

    }


}
