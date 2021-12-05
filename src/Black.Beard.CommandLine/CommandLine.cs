using Bb.CommandLines;
using Bb.CommandLines.Outs;
using Bb.Configurations;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Bb
{
    public class CommandLine
    {

        public static T Run<TCommandLine, T>(string[] args)
            where TCommandLine : Command<T>, new()
            where T : CommandLineApplication, new()
        {

            var dir = new DirectoryInfo("configs");
            var file = new FileInfo("local.config");

            if (file.Exists)
            {

                var txt = File.ReadAllText(file.FullName).Trim();                
                
                if (dir.Exists)
                {
                    var dir2 = new DirectoryInfo( System.IO.Path.Combine( dir.FullName, txt) );
                    if (dir2.Exists)
                        ConfigurationLoader.RootPath = dir.FullName;
                }
                else
                {
                    var dir2 = new DirectoryInfo(System.IO.Path.Combine(ConfigurationLoader.DefaultPath, txt));
                    if (dir2.Exists)
                        ConfigurationLoader.RootPath = dir.FullName;
                }

                ConfigurationLoader.Instance.SetProfile(txt);

            }

            CommandLineProgram<TCommandLine, T>.Main(args);
            return CommandLineProgram<TCommandLine, T>.Result;
        }

    }

}
