using System.Reflection;

namespace Bb
{
    internal static class Constants
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


        public static string Name;
        public static string ShortVersion;
        public static string LongVersion;

        public const string ProgramHelpDescription = "";
        public const string ExtendedHelpText = "";

        public static string RootCommand; 

    }


}
