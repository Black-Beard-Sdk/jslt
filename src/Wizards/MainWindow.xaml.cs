using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Wizards.Commands;

namespace Wizards
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string[] args = GetArguments();

            var cmd = Bb.CommandLine.Run<Command, CommandLine>(args);

            // Program.Result = cmd.Result;
            Environment.Exit(cmd.Result.ToValue());

        }

        private static string[] GetArguments()
        {

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 0)
            {

                var arg1 = args[0];

                var a = Assembly.GetExecutingAssembly();
                var assemblyName = a.GetName().Name;

                if (arg1 != null && File.Exists(arg1))
                    if (System.IO.Path.GetFileNameWithoutExtension(arg1) == assemblyName)
                        args = args.Skip(1).ToArray();

            }

            return args;
        }
    }

}


// https://github.com/toddams/RazorLight

