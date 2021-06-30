
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
    public static partial class Command
    {


        public static CommandLineApplication CommandConnectionString(this CommandLineApplication app)
        {
                  
            app.Command("cnx", config =>
            {

                config.Description = "manage connexion";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                config.OnExecute(() =>
                {

                    var result = typeof(Command).Assembly.RestartForUpdate();

                    if (result.HasExited)
                    {
                        Output.WriteLineStandard("the update process is anormaly quicker");
                        return 1;
                    }

                    return 0;

                });

            });
                      

            return app;

        }

    }
}
