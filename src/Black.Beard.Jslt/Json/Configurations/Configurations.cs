using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Json.Configurations
{

    public class Configurations
    {

        static Configurations()
        {

        }

        public Configurations()
        {
            this._configuration = new Dictionary<string, object>();
            Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "jslt");
        }

        public static Configurations Instance
        {
            get
            {
                
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new Configurations();

                return _instance;

            }
        }

        public List<Configuration> Items { get; set; }
        
        public object GetConfiguration(string name)
        {

            if (!_configuration.TryGetValue(name, out object config))
            {
                var conf = Items.FirstOrDefault(c => c.Name == name);
                if (conf != null)
                    _configuration.Add(name, (config = conf.GetConfiguration(this)));
            }

            return config;

        }
           
        public  string Path { get; }

        private readonly Dictionary<string, object> _configuration;
        private static object _lock = new object();
        private static Configurations _instance;

    }

}
