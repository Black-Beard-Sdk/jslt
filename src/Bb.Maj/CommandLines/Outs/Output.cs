using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Bb.CommandLines.Outs
{

    internal static partial class Output
    {


        static Output()
        {
            Debug.AutoFlush = true;
        }

        public static string Format(this string message, params object[] args)
        {
            return string.Format(message, args);
        }

        internal static void Flush()
        {

            Console.Out.Flush();
            Console.Error.Flush();
            Debug.Flush();

        }

    }


}
