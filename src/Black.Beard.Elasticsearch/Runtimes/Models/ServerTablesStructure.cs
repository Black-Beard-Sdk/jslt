using Bb;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

namespace Bb.Elastic.Runtimes.Models
{
    public class ServerTablesStructure
    {

        public ServerTablesStructure()
        {
            this._items = new List<ServerTableStructure>();
        }

        public ServerTableStructure this[string key] { get => _items.Where(c => c.TableName == key).FirstOrDefault(); }

        public bool Contains(string key)
        {
            return _items.Any(c => c.TableName == key);
        }

        public ServerTableStructure Add(string key)
        {
            var resultAlias = _items.Where(c => c.TableName == key).FirstOrDefault();
            if (resultAlias == null)
            {
                resultAlias = Creator();
                resultAlias.TableName = key;
                _items.Add(resultAlias);
            }
            return resultAlias;
        }

        public void Deserialize(JArray a)
        {
            foreach (var item in a)
            {
                var c = Creator();
                c.Deserialize(item as JObject);
            }
        }

        public JArray Serialize()
        {
            JArray a = new JArray();
            foreach (var item in _items)
            {
                a.Add(item.Serialize());
            }

            return a;
        }

        public void Load()
        {

            if (string.IsNullOrEmpty(this.Filename))
                throw new InvalidOperationException("missing name for loading");

            var sb = ContentHelper.LoadContentFromFile(this.Filename);
            JArray a = JArray.Parse(sb.ToString());
            this.Deserialize(a);
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(this.Filename))
                throw new InvalidOperationException("missing name for saving");

            var sb = this.Serialize().ToString();
            if (File.Exists(this.Filename))
                File.Delete(this.Filename);
            File.AppendAllText(this.Filename, sb);
        }

        private List<ServerTableStructure> _items;

        public Func<ServerTableStructureElastic> Creator { get; set; }
        public string Filename { get; internal set; }
        public string ConnectionName { get; internal set; }
    }


}