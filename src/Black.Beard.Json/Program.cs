using Bb.CommandLines.Outs;
using Bb.Json.Commands;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Bb.Json
{

    public partial class Program
    {

        public static int ExitCode { get; private set; }

        public static void Main(params string[] args)
        {

            CommandLineApplication app = null;
            try
            {

                app = new CommandLineApplication()
                    .Initialize()
                    .CommandExecute()
                    .CommandFormat()
                    // .CommandImport()
                    .CommandExport()
                    .CommandLoadCsv()
                ;

                int result = app.Execute(args);

                Output.Flush();

                Environment.ExitCode = Program.ExitCode = result;

            }
            catch (System.FormatException e2)
            {
                FormatException(app, e2);
            }
            //catch (AggregateException e4)
            //{
            //    foreach (var item in e4.InnerExceptions)
            //    {
            //        //if (item is AuthenticationException)
            //        //    AuthorizeException();
            //        //else
            //        //    Exception(item);
            //    }
            //}
            catch (CommandParsingException e)
            {

                Output.WriteLineError(e.Message);
                Output.WriteLineError(e.StackTrace);
                Output.Flush();

                if (e.HResult > 0)
                    Environment.ExitCode = Program.ExitCode = e.HResult;

                app.ShowHelp();

                Environment.ExitCode = Program.ExitCode = 1;

            }
            catch (Exception e)
            {

                Output.WriteLineError(e.Message);
                Output.WriteLineError(e.StackTrace);
                Output.Flush();

                if (e.HResult > 0)
                    Environment.ExitCode = Program.ExitCode = e.HResult;

                Environment.ExitCode = Program.ExitCode = 1;

            }

        }

        private static void FormatException(CommandLineApplication app, FormatException e2)
        {
            Output.WriteLineError(e2.Message);
            Output.Flush();
            app.ShowHelp();
            Environment.ExitCode = Program.ExitCode = 2;
        }

    }

}
