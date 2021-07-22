using Bb.CommandLines;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using System;

namespace Bb
{
    public class CommandLine
    {

        public static T Run<TCommandLine, T>(Action<ConfigurationBuilder> configurationBuilder, string[] args)
            where TCommandLine : Command<T>, new()
            where T : CommandLineApplication, new()
        {


            var builder = new ConfigurationBuilder();
            configurationBuilder(builder);

            var configuration = builder.Build();

            CommandLineProgram<TCommandLine, T>.Main(configuration, args);
            return CommandLineProgram<TCommandLine, T>.Result;

        }

    }

}
