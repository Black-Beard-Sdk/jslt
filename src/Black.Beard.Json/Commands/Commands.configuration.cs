
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using Bb.Maj;
using Bb.Sdk.Csv;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Json.Commands
{




    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {

        public CommandLineApplication CommandConnectionString(CommandLineApplication app)
        {

                  
            var cnx = app.Command("config", config =>
            {
                config.Description = "manage configuration";
                config.HelpOption(HelpFlag);
            });

            var types = cnx.Command("types", config =>
            {
                config.Description = "manage types configurations";
                config.HelpOption(HelpFlag);
            });

            types.Command("add", config =>
            {

                config.Description = "add a new type configuration";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                config.OnExecute(() =>
                {

                    return 0;

                });

            });


            return app;

        }

    }
}
