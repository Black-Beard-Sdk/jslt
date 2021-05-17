using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.CommandLines.Ins
{
    
    public static class Input
    {



        public static MemoryStream GetInputRedirection()
        {
            var m = new MemoryStream();
            var standardinput = new StreamReader(m);
            Console.SetIn(standardinput);
            return m;
        }


        public static StringBuilder ReadInput(Encoding encoding)
        {

            StringBuilder payload = new StringBuilder();
            Console.InputEncoding = encoding;
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding))
            {
                string stdin;
                do
                {
                    StringBuilder stdinBuilder = new StringBuilder();
                    stdin = reader.ReadLine();
                    stdinBuilder.Append(stdin);
                    var lineIn = stdin;
                    if (stdinBuilder.ToString().Trim() != "")
                    {
                        payload.Append(stdinBuilder.ToString());
                    }

                } while (stdin != null);

            }

            return payload;

        }


        public static bool IsPipedInput
        {
            get
            {
                try
                {
                    bool isKey = Console.KeyAvailable;
                    return false;
                }
                catch
                {
                    return true;
                }
            }
        }

    }
}
