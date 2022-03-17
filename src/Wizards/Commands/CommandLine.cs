using Microsoft.Extensions.CommandLineUtils;

namespace Wizards.Commands
{

    public partial class CommandLine : CommandLineApplication
    {

        public Errors Result { get; set; }

    }

    public enum Errors
    {

        None,
        CompilationError,

    }

    public static class EnumHelper
    {

        public static int ToValue<T>(this T self)
            where T : struct
        {

            return (int)(object)self;

        }
    }

}
