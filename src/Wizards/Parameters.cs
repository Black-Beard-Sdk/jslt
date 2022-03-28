using Bb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Wizards.Commands;

namespace Wizards
{
    public class Parameters
    {

        static Parameters()
        {
            _pwd = Environment.MachineName + Environment.UserName + Environment.UserDomainName;
        }

        public Parameters()
        {
            Credentials = new List<Credential>();
        }


        public static Parameters Instance { get { return _instance ?? (_instance = Get()); } }

        private static Parameters Get()
        {

            Parameters Parameters;
            var path = Assembly.GetExecutingAssembly().Location;
            var file = new FileInfo(Path.Combine(new FileInfo(path).Directory.FullName, "parameters.dat"));

            if (file.Exists)
            {
                Parameters = file.LoadFromFile().Deserialize<Parameters>();
                Parameters._file = file;
            }
            else
            {
                Parameters = new Parameters();
                Parameters.Save();
            }

            return Parameters;

        }

        public List<Credential> Credentials { get; set; }

        public string LastClone { get; set; }
        public bool Debug { get; internal set; }

        public void Save()
        {
            this._file.FullName.Save(this.Serialize(Newtonsoft.Json.Formatting.Indented));
        }

        public static string Encrypt(string payload)
        {

            return Convert.ToBase64String(AESThenHMAC.SimpleEncryptWithPassword(System.Text.Encoding.UTF8.GetBytes(payload), _pwd));

        }

        public static string Decrypt(string payload)
        {
            return System.Text.Encoding.UTF8.GetString(AESThenHMAC.SimpleDecryptWithPassword(Convert.FromBase64String(payload), _pwd));
        }


        public static Git GetLocalGit(string dir, string connexionName = null)
        {

            var git = new Git(dir)
            {

            };

            Credential credential = null;
            IEnumerable<Credential> credentials = Instance.Credentials;
            if (!string.IsNullOrEmpty(connexionName))
            {
                connexionName = connexionName.ToLower();
                credentials = credentials.Where(c => c.Name.ToLower() == connexionName);
            }

            if (credentials.Count() == 1)
                credential = credentials.FirstOrDefault();

            if (credential != null)
            {
                git.User = Parameters.Decrypt(credential.User);
                git.Token = Parameters.Decrypt(credential.Token);
            }

            return git;

        }


        private static Parameters _instance;
        private static readonly string _pwd;
        private FileInfo _file;

    }
}
