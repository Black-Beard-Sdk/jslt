﻿using Bb.Elastic.Runtimes.Models;
using Oldtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Bb.Elasticsearch.Configurations
{

    [Category("Configuration")]
    public class ConfigurationList : List<BaseConfiguration>
    {

        static ConfigurationList()
        {

            _setting = new JsonSerializerSettings()
            {

            };

            _setting.Converters.Add(new Oldtonsoft.Json.Converters.StringEnumConverter());
            //  "GCvjqei110If3GmRG26O12YGNwV3ynOCLTDaliWttiwG"

        }

        public static ConfigurationList Load(string path)
        {
            var file = new FileInfo(path);
            var payload = file.LoadFromFile();
            var instance = JsonConvert.DeserializeObject<ConfigurationList>(payload, _setting);
            instance.Filename = file.FullName;
            return instance;
        }

        public void Save()
        {

            if (string.IsNullOrEmpty(this.Filename))
                throw new InvalidDataException(nameof(ConfigurationList.Filename));

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


        [JsonIgnore]
        public string Filename { get; private set; }

        public ElasticConnectionList GetElasticConnections()
        {

            var result = new ElasticConnectionList();

            foreach (var item in this)
                if (item is ElasticConfiguration c)
                    c.Append(result);

            return result;

        }

        private static readonly JsonSerializerSettings _setting;

    }


}
