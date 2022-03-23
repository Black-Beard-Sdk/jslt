using Microsoft.Extensions.CommandLineUtils;
using System.IO;
using System.Reflection;
using Bb;
using System;

namespace Wizards.Commands
{

    public partial class CommandLine : CommandLineApplication
    {

        public CommandLine()
        {


        }

        public Errors Result { get; set; }

    }

    public enum Errors
    {

        None,
        CompilationError,
        MissingAuthentication,
        GitError,
        FailedToDecryptCredential,
        MissingFolder,
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
