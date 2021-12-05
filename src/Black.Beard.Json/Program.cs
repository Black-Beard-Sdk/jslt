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
            var cmd = Bb.CommandLine.Run<Command, Bb.Json.Commands.CommandLine>(args);
            Program.Result = cmd.Result;

        }
    
    }


}
