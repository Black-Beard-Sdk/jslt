using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards.Commands
{


    /// <summary>
    /// https://github.com/libgit2/libgit2sharp/wiki/git-status
    /// </summary>
    public class Git
    {


        public Git(string workdirPath)
        {
            this._workdirPath = workdirPath;
        }

        public string User { get; set; }

        public string Token { get; set; }


        public CredentialsHandler GetCredential()
        {

            if (!string.IsNullOrEmpty(User))
                return GetUserPwdCredential;

            return null;

        }


        private CredentialsHandler GetUserPwdCredential => (_url, _user, _cred) => new UsernamePasswordCredentials
        {
            Username = User,
            Password = Token
        };

        public string Clone(string sourceUrl)
        {

            //var co = new CloneOptions()
            //{
            //    CredentialsProvider = GetCredential()
            //};

            //return Repository.Clone(sourceUrl, _workdirPath, co);

            return null;

        }

        public MergeResult Fetch()
        {

            var fo = new FetchOptions()
            {
                CredentialsProvider = GetCredential()
            };

            using (var git = new Repository(_workdirPath))
            {

                //var head = git.Head;
                //var remote = git.Network.Remotes[head.RemoteName];

                //var fetch = remote.FetchRefSpecs.Select(rs => rs.Specification).ToList();
                //git.Network.Fetch(head.RemoteName, fetch, fo);

                var mergeOptions = new MergeOptions();
                var pullOptions = new PullOptions { FetchOptions = fo, MergeOptions = mergeOptions };

                var signature = new Signature(new Identity("MERGE_USER_NAME", "MERGE_USER_EMAIL"), DateTimeOffset.Now);

                var result = LibGit2Sharp.Commands.Pull(git, signature, pullOptions);                        

                return result;

            }


        }


        //public bool IsUpToDate()
        //{


        //    using (var repo = new Repository(_workdirPath))
        //    {

        //        var  r = repo.Network.ListReferences("https://PickupServices@dev.azure.com/PickupServices/AMS-PUDO/_git/ToolboxLockerTeam", GetCredential()).ToList();

        //        foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree, DiffTargets.Index | DiffTargets.WorkingDirectory))
        //        {
        //            Console.WriteLine(c);
        //        }
        //    }


        //    using (var git = new Repository(_workdirPath))
        //    {

        //        var head = git.Head;
        //        var remote = git.Network.Remotes[head.RemoteName];
        //        var fo = new FetchOptions()
        //        {
        //            CredentialsProvider = GetCredential(),
        //            TagFetchMode = TagFetchMode.All,
                    
        //        };
        //        var fetch = remote.FetchRefSpecs.Select(rs => rs.Specification).ToList();

        //        git.Network.Fetch(head.RemoteName, fetch, fo);

        //        var o = new StatusOptions() { };
        //        foreach (var item in git.RetrieveStatus(o))
        //        {
        //            Console.WriteLine(item.FilePath);
        //            Console.WriteLine(item.State);
        //        }

        //    }

        //    return true;

        //}



        private readonly string _workdirPath;

    }

}
