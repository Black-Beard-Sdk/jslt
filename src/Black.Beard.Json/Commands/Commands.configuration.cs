
using Bb.CommandLines;
using Microsoft.Extensions.CommandLineUtils;

namespace Bb.Json.Commands
{

    public partial class Command : Command<CommandLine>
    {

        public CommandLineApplication CommandConnectionString(CommandLine app)
        {
                              
            var cnx = app.Command("config", config =>
            {
                config.Description = "manage configuration";
                config.HelpOption(HelpFlag);
            });

            //var types = cnx.Command("types", config =>
            //{
            //    config.Description = "manage types configurations";
            //    config.HelpOption(HelpFlag);
            //});

            //cnx.Command("new", config =>
            //{

            //    config.Description = "add a new configuration file";
            //    config.HelpOption(HelpFlag);

            //    var validator = new GroupArgument(config);

            //    config.OnExecute(() =>
            //    {

            //        return 0;

            //    });

            //});



            //types.Command("add", config =>
            //{

            //    config.Description = "add a new type to configuration";
            //    config.HelpOption(HelpFlag);

            //    var validator = new GroupArgument(config);

            //    config.OnExecute(() =>
            //    {

            //        return 0;

            //    });

            //});


            return app;

        }

    }
}
