using Bb;
using Bb.CommandLines.Outs;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.IO;

namespace Bb.CommandLines.Validators
{


    internal static class ValidatorExtension
    {


        //public static int EvaluateGroupName()
        //{

        //    if (string.IsNullOrEmpty(Helper.Parameters.WorkingGroup))
        //        return ValidatorExtension.Error(ErrorEnum.InvalidName, $"working group must be setted. please considere use '{Constants.RootCommand} group set <groupName>'.");

        //    return 0;

        //}

        public static int EvaluateFileExist(CommandOption option)
        {

            if (option.HasValue())
            {
                FileInfo file = new FileInfo(option.Value());
                if (!file.Exists)
                    return Error(ErrorEnum.FileNotFound, $"file '{file.FullName}' not found");
            }

            return 0;

        }

        public static int EvaluateFileExist(CommandArgument option)
        {

            if (!string.IsNullOrEmpty(option.Value))
            {
                var file = option.Value.GetFilename();
                if (!file.Exists)
                    return Error(ErrorEnum.FileNotFound, $"file '{file.FullName}' not found");
            }

            return 0;

        }

        public static FileInfo GetFilename(this string self)
        {
            var f = self.Trim().Trim('"', '\'');
            FileInfo file = new FileInfo(f);
            return file;
        }

        public static int EvaluateName(CommandArgument command)
        {

            if (command.Value.Contains('.'))
                return Error(ErrorEnum.InvalidName, "name {0} can't contains '.' character", command);

            return 0;

        }

        public static int EvaluateRequired(CommandArgument command)
        {

            if (string.IsNullOrWhiteSpace(command.Value))
                return Error(ErrorEnum.ArgumentRequired, "{0} must be specified", command);

            return 0;

        }

        public static int EvaluateDirectoryPathIsValid(CommandArgument command)
        {

            try
            {
                var o = System.IO.Directory.Exists(command.Value);
            }
            catch (Exception)
            {
                return Error(ErrorEnum.DirectoryPathNotFound, "{0} is not a valid folder path", command);
            }

            return 0;

        }

        public static void Stop()
        {
            System.Diagnostics.Debugger.Launch();
            System.Diagnostics.Debugger.Break();
        }

        public static int Error(this ErrorEnum errorNum, string message)
        {
            Output.WriteLineError();
            Output.WriteLineError(message);
            return (int)errorNum;
        }

        public static int Error(this ErrorEnum errorNum, string message, CommandArgument arg)
        {
            Output.WriteLineError();
            message.Format(arg.Name)
                .WriteLineStandard();
            return (int)errorNum;
        }

        public static int Error(this ErrorEnum errorNum, string message, CommandOption arg)
        {

            Output.WriteLineError();
            Output.Format(message, arg.Template).WriteLineError();
            return (int)errorNum;
        }

        internal static bool CheckToken()
        {

            if (string.IsNullOrEmpty(Helper.Parameters.Token))
                return false;

            return DateTime.Now < Helper.Parameters.TokenExpiration;

        }

    }

}
