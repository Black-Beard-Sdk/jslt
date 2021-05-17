namespace Bb
{
    public static class Constants
    {

        static Constants()
        {
            var n = typeof(Constants).Name.Split('.');
            RootCommand = n[n.Length - 1];
        }


        public const string Name = "Json cli v1";
        public const string ShortVersion = "v1";
        public const string LongVersion = "version 1";

        public const string ProgramHelpDescription = "";
        public const string ExtendedHelpText = "";


        public static string RootCommand; 

    }


}
