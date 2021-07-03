using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Bb.Json.Configurations
{

    public class Configuration
    {

        public string Type { get; set; }

        public string Name { get; set; }

        public object GetConfiguration(Configurations configurations)
        {

            object result = null;

            var typeConfig = GetTypeFrom();
            if (typeConfig != null)
            {
                var file = System.IO.Path.Combine(configurations.Path, Name + ".config.json");
                var payload = file.LoadContentFromFile();
                result = JsonConvert.DeserializeObject(payload, typeConfig);
            }

            return result;

        }

        public System.Type GetTypeFrom()
        {
            return Bb.ComponentModel.TypeDiscovery.Instance.ResolveByName(this.Type);
        }


    }


}
