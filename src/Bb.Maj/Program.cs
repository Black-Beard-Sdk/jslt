using Bb.CommandLines.Outs;
using Bb.Maj.Commands;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.Maj
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
                    .CommandVersions()
                    
                ;

                int result = app.Execute(args);

                Output.Flush();

                Environment.ExitCode = Program.ExitCode = result;

            }
            catch (System.FormatException e2)
            {
                FormatException(app, e2);
            }
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

        public static void RunUpdate(Assembly callingAssembly)
        {

            var attributes = callingAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().ToDictionary(c => c.Key);
            string packageNameArgument = attributes["githubName"].Value;
            string artefactNameArgument = attributes["githubartefact"].Value;
            string targetDirArgument = new FileInfo(callingAssembly.Location).Directory.FullName;


            var file = new FileInfo(typeof(Program).Assembly.Location);
            file = new FileInfo(Path.Combine(file.Directory.FullName, Path.GetFileNameWithoutExtension(file.Name) + ".exe"));

            var process = Process.GetCurrentProcess();

            var info = new ProcessStartInfo()
            {
                FileName = file.FullName,
                Arguments = $"install \"{packageNameArgument}\" \"{artefactNameArgument}\" \"{targetDirArgument}\" --p {process.Id}"
            };

            var process1 = Process.Start(info);

        }
    }
         

}
