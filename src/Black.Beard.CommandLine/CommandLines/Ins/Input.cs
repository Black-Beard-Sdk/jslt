using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.CommandLines.Ins
{

    public static class Input
    {


        public static bool Confirm(string message = null)
        {
            while (true)
            {

                if (!string.IsNullOrEmpty(message))
                    Console.WriteLine(message);

                var cmd = Console.ReadLine().ToLower();
                switch (cmd)
                {
                    case "y":
                    case "yes": 
                        return true;
                    
                    case "n":
                    case "no":
                        return false;

                    default: continue;
                }

            }
        }

        public static string GetPassword(string message = null)
        {

            if (!string.IsNullOrEmpty(message))
                Console.WriteLine(message);

            var password = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return password.ToString();
        }


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
