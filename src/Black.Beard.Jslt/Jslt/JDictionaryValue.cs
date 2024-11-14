using Bb.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bb.Jslt
{


    public class JDictionaryValue : JValue
    {

        public JDictionaryValue() : base(string.Empty)
        {
            _dic = new Dictionary<string, JToken>();
        }

        #region ImplementDictionary

        public int Count => _dic.Count;

        public ICollection<string> Keys => _dic.Keys;

        public ICollection<JToken> Values => _dic.Values;

        public bool IsReadOnly => false;

        public override JTokenType Type => throw new System.NotImplementedException();

        public JToken this[string key] { get => _dic[key]; set => _dic[key] = value; }

        public void Add(string key, JToken value)
        {
            _dic.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _dic.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _dic.Remove(key);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out JToken value)
        {
            return _dic.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, JToken> item)
        {
            ((IDictionary<string, JToken>)_dic).Add(item);
        }

        public void Clear()
        {
            _dic.Clear();
        }

        public bool Contains(KeyValuePair<string, JToken> item)
        {
            return ((IDictionary<string, JToken>)_dic).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, JToken>[] array, int arrayIndex)
        {
            ((IDictionary<string, JToken>)_dic).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, JToken> item)
        {
            return ((IDictionary<string, JToken>)_dic).Remove(item);
        }

        public IEnumerator<KeyValuePair<string, JToken>> GetEnumerator()
        {
            return _dic.GetEnumerator();
        }

        #endregion ImplementDictionary


        private readonly Dictionary<string, JToken> _dic;


    }

}