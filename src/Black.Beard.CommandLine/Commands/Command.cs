using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.CommandLines
{

    public partial class Command<T>
        where T : CommandLineApplication

    {

        static Command()
        {
            /// Command._access = "('" + string.Join("','", Enum.GetNames(typeof(AccessModuleEnum))) + "')";
            /// By default, ExcelDataReader throws a NotSupportedException "No data is available for encoding 1252." on.NET Core.
            /// To fix, add a dependency to the package System.Text.Encoding.CodePages and then add code to register the code page provider during application initialization(f.ex in Startup.cs):
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// Initializes the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public T Initialize(T app)
        {

            //Helper.Load();

            AnsiConsole.GetError(true);

            app.HelpOption(HelpFlag);
            app.VersionOption(VersionFlag, Constants.ShortVersion, Constants.LongVersion);

            app.Name = Constants.Name;
            app.Description = Constants.ProgramHelpDescription;
            app.ExtendedHelpText = Constants.ExtendedHelpText;

            var methods = this.GetType().GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var method in methods)
                if (method.Name != nameof(Command<T>.Initialize) && typeof(CommandLineApplication).IsAssignableFrom(method.ReturnType))
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1 && typeof(CommandLineApplication).IsAssignableFrom(parameters[0].ParameterType))
                        method.Invoke(this, new object[] { app });
                }

            return app;

        }

        public const string HelpFlag = "-? |-h |--help";
        public const string VersionFlag = "-v |--version";
        public static string _access;

    }

}
