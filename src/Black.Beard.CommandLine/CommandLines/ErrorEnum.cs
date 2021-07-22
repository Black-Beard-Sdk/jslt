using System;

namespace Bb.CommandLines
{

    // This exception is thrown instead of calling Enivornment.Exit to ensure RAII cleanup
    public class ExitCodeException : Exception
    {
        internal int ExitCode;

        public ExitCodeException(int exitCode, string msg = "")
            : base(msg)
        {
            ExitCode = exitCode;
        }
    }


    public enum ErrorEnum
    {

        None = 0,
        SyntaxtError = 1,
        ErrorUnspecified = 2,
        ArgumentRequired = 3,
        InvalidName = 4,
        FileNotFound = 5,
        DirectoryPathNotFound = 6,

        MissingSource = 7,
    }


}
