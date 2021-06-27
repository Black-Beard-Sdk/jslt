using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Maj.Commands
{

    public static partial class Command
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
        public static CommandLineApplication Initialize(this CommandLineApplication app)
        {

            //Helper.Load();

            AnsiConsole.GetError(true);

            app.HelpOption(HelpFlag);
            app.VersionOption(VersionFlag, Constants.ShortVersion, Constants.LongVersion);

            app.Name = Constants.Name;
            app.Description = Constants.ProgramHelpDescription;
            app.ExtendedHelpText = Constants.ExtendedHelpText;

            return app;

        }

       

        // public static BbClientHttp Client => new BbClientHttp(new Uri(Helper.Parameters.ServerUrl));

        public static object Result { get; internal set; }

        public const string HelpFlag = "-? |-h |--help";
        public const string VersionFlag = "-v |--version";
        public static string _access;


    }


}
