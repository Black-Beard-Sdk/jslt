using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Elastic.Runtimes.Models
{
    public class ServerFieldsStructure
    {

        public ServerFieldsStructure()
        {

        }

        internal ServerFieldStructure Add(string name, string type)
        {

            var field = _items.Where(c => c.Name == name).FirstOrDefault();

            if (field != null)
                field.Type = type;

            else
                _items.Add(field = new ServerFieldStructure() { Name = name, Type = type });

            return field;

        }

        public ServerFieldStructure this[string name]
        {
            get
            {
                var field = _items.Where(c => c.Name == name).FirstOrDefault();
                return field;
            }
        }



        private List<ServerFieldStructure> _items = new List<ServerFieldStructure>();

        public IEnumerable<ServerFieldStructure> Fields { get => _items; }

        internal void Merge(ServerIndiceStructureElastic indiceObject)
        {
            foreach (var item in indiceObject.Fields.Fields)
                Add(item.Name, item.Type);
        }

        public virtual JArray Serialize()
        {

            var a = new JArray();

            foreach (var item in this._items)
            {
                a.Add(item.Serialize());
            }

            return a;

        }

        public void Deserialize(JArray a)
        {
            foreach (var item in a)
            {
                var name = item["Name"].Value<string>();
                var type = item["Type"].Value<string>();
                Add(name, type);
            }
        }


    }
}