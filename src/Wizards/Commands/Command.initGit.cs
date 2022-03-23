using Bb.Builds;
using Bb.CommandLines;
using Bb.CommandLines.Outs;
using Bb.CommandLines.Validators;
using LibGit2Sharp;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Wizards.Commands
{

    /// <summary>
    /// 
    /// </summary>
    public partial class Command : Command<CommandLine>
    {

        public CommandLineApplication CommandCredentials(CommandLine app)
        {

            // The syntax start with template.
            var cmd = app.Command("credentials", config =>
            {

                config.Description = "inti git credentils";
                config.HelpOption(HelpFlag);

                var validator = new GroupArgument(config);


                // Add argument
                var argName = validator.Argument("<git name>", "name"
                    , ValidatorExtension.EvaluateRequired
                );

                // Add argument
                var argGitUser = validator.Argument("<git user>", "user"
                    , ValidatorExtension.EvaluateRequired
                );


                var argGitToken = validator.Argument("<git token>", "token"
                    , ValidatorExtension.EvaluateRequired
                );

                config.OnExecute(() =>
                {


                    CloneOptions co = new CloneOptions();
                    string gitName = argName.Value;
                    string gitUser = argGitUser.Value;
                    string gitToken = argGitToken.Value;

                    Parameters.Instance.Credentials.Add(new Credential()
                    {
                        Name = gitName,
                        User = Parameters.Encrypt(gitUser),
                        Token = Parameters.Encrypt(gitToken)
                    });

                    Parameters.Instance.Save();

                    //co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = gitUser, Password = gitToken };

                    return app.Result.ToValue();

                });


            });

            return app;

        }
      
    }

}
