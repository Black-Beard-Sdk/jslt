using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bb.Elasticsearch.Configurations
{

    public class ElasticConfigurations : List<ElasticConfiguration>
    {

        static ElasticConfigurations()
        {

            _setting = new JsonSerializerSettings()
            {

            };

            _setting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            _setting.Converters.Add(new ElasticConfigurationLoginJsonConverter( AsymetricKindEnum.TripleDES, "GCvjqei110If3GmRG26O12YGNwV3ynOCLTDaliWttiwG"));

        }

        public static ElasticConfigurations Load(string path)
        {
            var file = new FileInfo(path);
            var payload = file.LoadContentFromFile();
            var instance = JsonConvert.DeserializeObject<ElasticConfigurations>(payload, _setting);
            instance.Filename = file.FullName;
            return instance;
        }

        public void Save()
        {

            if (string.IsNullOrEmpty(this.Filename))
                throw new InvalidDataException(nameof(ElasticConfigurations.Filename));

            Save(this.Filename);

        }

        public void Save(string filename)
        {

            if (string.IsNullOrEmpty(filename))
                throw new InvalidDataException(nameof(filename));

            var file = new FileInfo(filename);
            var instance = JsonConvert.SerializeObject(this, _setting);

            if (file.Exists)
                file.Delete();

            file.FullName.Save(instance);

        }

        private static readonly JsonSerializerSettings _setting;

        [JsonIgnore]
        public string Filename { get; private set; }

    }


}
