using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Extensions.Secures
{

    public class Vault
    {

        public Vault()
        {
            Entries = new List<VaultEntry>();
        }

        public List<VaultEntry> Entries { get; set; }

        public void Add(string key, string value)
        {

            if (Entries.Any(c => c.Key == key))
                throw new Exception($"duplicated key {key}");

            if (string.IsNullOrEmpty(_saltKey))
                InitializeVault();

            var e = new VaultEntry()
            {
                Key = key,
            };

            e.Store(this, value);

            Entries.Add(e);
        }

        public string Get(string key)
        {
            var e = Entries.FirstOrDefault(c => c.Key == key);
            return e.Decode(this);
        }

        public static Vault LoadStore(string path)
        {

            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    return LoadStore(stream);
            }

            return new Vault();

        }

        public static Vault LoadStore(Stream stream)
        {
            var secretsManager = new Vault();
            secretsManager.LoadSecretsStream(stream);
            return secretsManager;
        }

        public void SaveStore(string path)
        {

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
            using (var jwriter = new JsonTextWriter(writer))
            {
                jwriter.Formatting = Formatting.Indented;
                JsonSerializer.Create().Serialize(jwriter, this);
            }
        }


        public Vault Export()
        {

            var vault = new Vault();

            foreach (var item in this.Entries)
            {
                vault.Entries.Add(new VaultEntry()
                {
                    Key = item.Key,
                    Value = item.Decode(this),
                });
            }

            return vault;

        }

        public void Import(Vault vault)
        {

            foreach (var item in vault.Entries)
            {

                var i = Entries.FirstOrDefault(c => c.Key == item.Key);
                if (i == null)
                    this.Entries.Add(i = new VaultEntry()
                    {
                        Key = item.Key,
                    });

                i.Store(this, item.Value);

            }

        }


        private void LoadSecretsStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, new UTF8Encoding(false)))
            using (var jreader = new JsonTextReader(reader))
            {
                JsonSerializer
                    .Create()
                    .Populate(jreader, this);
            }
        }

        internal SymmetricSecure SecureProcessor()
        {
            if (this._processor == null)
            {
                this._processor = SymmetricSecure.Get(SymmetricKindEnum.Rijndael);
                _processor.InitializeFromSalt(this._saltKey);
            }
            return _processor;
        }

        public Vault InitializeVault(string application = null)
        {

            if (!string.IsNullOrEmpty(application))
                _saltKey = application;

            else
            {

                var i = Environment.Is64BitOperatingSystem;
                var osv = Environment.OSVersion;

                _saltKey = string.Concat
                (
                    Environment.MachineName,
                    osv.Platform.ToString(),
                    osv.VersionString,
                    i ? "64" : "x86"

                );
            }

            return this;

        }

        private string _saltKey;
        private SymmetricSecure _processor;

    }

}
