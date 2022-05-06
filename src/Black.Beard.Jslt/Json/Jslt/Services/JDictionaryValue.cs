using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bb.Json.Jslt.Services
{


    public class JDictionaryValue : JValue
    {

        public JDictionaryValue() : base(string.Empty)
        {
            this._dic = new Dictionary<string, JToken>();
        }

        #region ImplementDictionary

        public int Count => this._dic.Count;

        public ICollection<string> Keys => this._dic.Keys;

        public ICollection<JToken> Values => this._dic.Values;

        public bool IsReadOnly => false;

        public override JTokenType Type => throw new System.NotImplementedException();

        public JToken this[string key] { get => this._dic[key]; set => this._dic[key] = value; }

        public void Add(string key, JToken value)
        {
            this._dic.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return this._dic.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return this._dic.Remove(key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out JToken value)
        {
            return this._dic.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, JToken> item)
        {
            ((IDictionary<string, JToken>)this._dic).Add(item);
        }

        public void Clear()
        {
            this._dic.Clear();
        }

        public bool Contains(KeyValuePair<string, JToken> item)
        {
            return ((IDictionary<string, JToken>)this._dic).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, JToken>[] array, int arrayIndex)
        {
            ((IDictionary<string, JToken>)this._dic).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, JToken> item)
        {
            return ((IDictionary<string, JToken>)this._dic).Remove(item);
        }

        public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator()
        {
            return this._dic.GetEnumerator();
        }

        #endregion ImplementDictionary


        private readonly Dictionary<string, JToken> _dic;


    }

}