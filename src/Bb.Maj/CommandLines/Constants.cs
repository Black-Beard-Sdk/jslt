using System.Reflection;

namespace Bb
{
    internal static partial class Constants
    {

        static Constants()
        {
            var n = typeof(Constants).Name.Split('.');
            RootCommand = n[n.Length - 1];

            var assemblyName = typeof(Constants).Assembly.GetName();

            ShortVersion = assemblyName.Version.ToString();
            LongVersion = assemblyName.Version.ToString();
            Name = assemblyName.Name + " cli " + assemblyName.Version.ToString();

        }


        public static string Name = "cli v1";
        public static string ShortVersion = "v1";
        public static string LongVersion = "version 1";

        public const string ProgramHelpDescription = "";
        public const string ExtendedHelpText = "";


        public static string RootCommand; 

    }


}
