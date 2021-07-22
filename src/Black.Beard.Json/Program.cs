using Bb.CommandLines.Outs;
using Bb.Json.Commands;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using System;


[assembly: System.Reflection.AssemblyMetadata("githubName", "Black-Beard-Sdk/jslt")]
[assembly: System.Reflection.AssemblyMetadata("githubartefact", "cli.zip")]
namespace Bb.Json
{


    public partial class Program
    {

        public static object Result { get; private set; }

        public static void Main(string[] args)
        {

            Action<ConfigurationBuilder> configurationBuilder = (builder) =>
            {

                builder
                    //.AddJsonFile(@"D:\src\option\src\outTests\schemas\Test.json", optional: false, reloadOnChange: true)
                    //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    //.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    //.AddSecureStoreFile(@"D:\src\option\src\outTests\securevault.json", "mypwd")

                    .AddEnvironmentVariables()  
                ;

                //if (isDevelopment) //only add secrets in development
                //{

                //}

            };
                       
            var cmd = Bb.CommandLine.Run<Command, Bb.Json.Commands.CommandLine>(configurationBuilder, args);
            Program.Result = cmd.Result;

        }
    
    }


}
