
using Bb.CommandLines;
using Bb.CommandLines.Ins;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
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


        public static CommandLineApplication CommandMaj(this CommandLineApplication app)
        {

            var dataCmd = app.Command("update", config =>
            {

                config.Description = "update version of json cli";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);

                config.OnExecute(() =>
                {

                    Bb.Maj.Program.RunUpdate(typeof(Command).Assembly);

                    return 0;

                });

            });

            return app;

        }

    }
}
