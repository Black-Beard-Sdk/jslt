using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace Bb.ConvertToDatables
{
    public class StructureSchema
    {


        public StructureSchema(DataSet dataSet)
        {
            this.DataSet = dataSet;
        }

        public List<StructureTable> Tables { get; set; } = new List<StructureTable>();

        public void Populate(JToken payload)
        {

            using (var sr = payload.CreateReader())
                JsonSerializer.CreateDefault().Populate(sr, this); // Uses the system default JsonSerializerSettings

            DatasetBuilder.Build(this);

        }

        public T Get<T>(string name)
        {

            if (_index.TryGetValue(name, out object value))
                return (T)value;

            return default;

        }

        internal void ReferenceObject(string name, object instance)
        {
            _index.Add(name, instance);
        }

        private Dictionary<object, object> _index = new Dictionary<object, object>();

        public DataSet DataSet { get; }


    }


}
