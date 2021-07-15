using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Bb.Elasticsearch.Configurations
{

    public class ElasticConfigurationLoginJsonConverter : JsonConverter
    {

        static ElasticConfigurationLoginJsonConverter()
        {
            _setting = new JsonSerializerSettings()
            {

            };
            _setting.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

        }

        public ElasticConfigurationLoginJsonConverter(AsymetricKindEnum algoKind, string key)
        {
            var algo = Bb.AsymetricSecure.Get(algoKind);
            algo.Initialize(key);
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(ElasticConfigurationLogin);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            var result = serializer.Deserialize<ElasticConfigurationLogin>(reader);

            return result;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            var v = value as ElasticConfigurationLogin;

            writer.WriteStartObject();

            writer.WritePropertyName(nameof(ElasticConfigurationLogin.Kind));
            writer.WriteValue(v.Kind);

            writer.WritePropertyName(nameof(ElasticConfigurationLogin.Key1));
            writer.WriteValue(v.Key1);

            writer.WritePropertyName(nameof(ElasticConfigurationLogin.Key2));
            writer.WriteValue(v.Key2);

            writer.WriteEndObject();

        }

        private static readonly JsonSerializerSettings _setting;


    }

}
