using NJsonSchema;
using NJsonSchema.Generation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Json
{
    
    public class SchemaHelper
    {

        static SchemaHelper()
        {

            _settings = new NJsonSchema.Generation.JsonSchemaGeneratorSettings()
            {
                FlattenInheritanceHierarchy = true,
                GenerateEnumMappingDescription = true,
            };

            _settings.ActualSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

        }

        /// <summary>
        /// Generates JSON schema for a given C# class using Newtonsoft.Json.Schema library.
        /// </summary>
        /// <param name="myType">class type</param>
        /// <returns>a string containing JSON schema for a given class type</returns>
        public static JsonSchema GenerateSchemaForClass(Type myType, string name)
        {

            string id = GetUri(myType.Name);

            var _schema = JsonSchema.FromType(myType, _settings);
            _schema.AllowAdditionalProperties = true;
            _schema.Id = id;

            return _schema;

        }

        public static string GetUri(params string[] names)
        {
            var p = System.IO.Path.Combine(names);
            p = System.IO.Path.Combine(GetRoot(), p).Replace("\\", "/");
            return p;
        }

        public static string GetRoot()
        {
            if (string.IsNullOrEmpty(Root))
                Root = "http://" + System.IO.Path.Combine(SI, "json", "schemas").Replace("\\", "/");
            return Root;
        }

        private static readonly JsonSchemaGeneratorSettings _settings;

        public static string Root { get; private set; }

        public static string SI { get; private set; } = "jslt";

    }
}
