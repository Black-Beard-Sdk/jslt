using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bb.Configurations
{
    public class ConfigurationResolver
    {

        public ConfigurationResolver()
        {
            Builders = new List<Action<ConfigurationBuilder>>();
        }


        public ConfigurationResolver AddBuilder(Action<ConfigurationBuilder> act)
        {
            if (act != null)
                Builders.Add(act);

            return this;
        }

        public IConfigurationRoot Configuration
        {
            get
            {

                if (_configuration == null)
                {
                    
                    var builder = new ConfigurationBuilder();
                    
                    foreach (var item in Builders)
                        item(builder);

                    _configuration = builder.Build();

                }

                return _configuration;
            }

        }

        public TConfig GetConfiguration<TConfig>(string sectionName) => Configuration.GetSection(sectionName).Get<TConfig>();


        private IConfigurationRoot _configuration;
        private List<Action<ConfigurationBuilder>> Builders = new List<Action<ConfigurationBuilder>>();

    }

}
