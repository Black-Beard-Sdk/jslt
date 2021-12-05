using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Configurations
{

    public class ConfigurationLoader
    {


        static ConfigurationLoader()
        {
            DefaultPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "jslt");
        }

        public ConfigurationLoader()
        {

            this.Configuration = new ConfigurationResolver();

            if (string.IsNullOrEmpty(RootPath))
                Path = "";
            else
                Path = RootPath;
            
            this.Configuration.AddBuilder((builder) =>
            {

                //builder.AddEnvironmentVariables()
                ;

                //if (isDevelopment) //only add secrets in development
                //{

                //}

           });

        }

        public static ConfigurationLoader Instance
        {
            get
            {

                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new ConfigurationLoader();

                return _instance;

            }
        }

        internal void SetProfile(string name)
        {

            var folder = new DirectoryInfo(System.IO.Path.Combine(this.Path, name));

            var files = folder.GetFiles("*.config.json");
            foreach (var file in files)
                this.Configuration.AddBuilder((builder) =>
                {

                    builder
                        .AddJsonFile(file.FullName, optional: false, reloadOnChange: true)
                    //.AddSecureStoreFile(@"D:\src\option\src\outTests\securevault.json", "mypwd")
                    ;

                });

        }

        public string Path { get; }

        public ConfigurationResolver Configuration { get; }


        public static string DefaultPath { get; }

        public static string RootPath { get; set; }

        private static object _lock = new object();
        private static ConfigurationLoader _instance;

    }

}
