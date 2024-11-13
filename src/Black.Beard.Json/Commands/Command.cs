using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Validators;
using Bb.ConvertToDatables;
using Microsoft.Extensions.CommandLineUtils;
using Bb.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace Bb.Json.Commands
{

    public partial class Command : Command<CommandLine>
    {

        static Command()
        {
            /// Command._access = "('" + string.Join("','", Enum.GetNames(typeof(AccessModuleEnum))) + "')";
            /// By default, ExcelDataReader throws a NotSupportedException "No data is available for encoding 1252." on.NET Core.
            /// To fix, add a dependency to the package System.Text.Encoding.CodePages and then add code to register the code page provider during application initialization(f.ex in Startup.cs):
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        }


        private static char GetSeparator(CommandOption optSeparator)
        {
            char separator = ';';

            if (optSeparator.HasValue())
            {
                string se = optSeparator.Value();
                if (se.Length > 1)
                    se = se.Trim(se[0]);
                separator = se[0];
            }

            return separator;

        }

        private static char GetQuote(CommandOption optQuote)
        {

            char quote = '"';

            if (optQuote.HasValue())
            {
                string se = optQuote.Value();
                if (se.Length > 1)
                    se = se.Trim(se[0]);
                quote = se[0];
            }

            return quote;

        }

        private static (int, string, JToken) ReadSource(CommandLineApplication app, CommandOption argSource, CommandOption argTargetName)
        {
            string targetName = string.Empty;
            JToken source = null;

            var inPipe = Input.IsPipedInput;

            if (argSource.HasValue())
            {

                var s = argSource.Value();
                source = s.TrimPath()
                         .LoadFromFile()
                         .ConvertToJson();

                targetName = Path.GetFileNameWithoutExtension(s);

            }
            else
            {

                if (!inPipe)
                {
                    app.ShowHelp();
                    return (ErrorEnum.MissingSource.Error("no source specified"), string.Empty, null);
                }

                source = Input.ReadInput(Encoding.UTF8)
                    .ConvertToJson();

                if (argTargetName.HasValue())
                    targetName = Path.GetFileNameWithoutExtension(argTargetName.Value().TrimPath());
                else
                    targetName = Guid.NewGuid().ToString()
                        .Replace("-", "")
                        .Trim(' ', '{', '}')
                        ;

            }

            return (0, targetName, source);

        }

        private static Parser GenerateParser(CommandArgument argTemplatePath)
        {
            var builder = new BuildSchema();

            var template = argTemplatePath.Value.TrimPath()
                .LoadFromFile()
                .ConvertToJson();

            var parser = builder.ParseTemplate(template);
            return parser;
        }

    }


}
