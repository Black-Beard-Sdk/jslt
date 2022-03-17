using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Json.Jslt.CustomServices
{



    public static partial class Services
    {


        [JsltExtensionMethod("group")]
        [JsltExtensionMethodParameter("source", "Json source.")]
        [JsltExtensionMethodParameter("groupPath", "json array of string. every item is a json path")]
        public static JToken ExecuteGroup(RuntimeContext ctx, JArray source, JArray groupPath)
        {

            var resultValue = new JArray();

            if (source != null)
            {
                if (groupPath != null)
                {

                    HashSet<string> _h = new HashSet<string>();
                    foreach (JToken item in groupPath)
                        if (item is JValue v)
                            _h.Add(v.Value?.ToString());

                    var dic = new GroupIndexes();

                    foreach (JToken token in source)
                        dic.Sort(token, _h.ToList(), 0);

                    resultValue = dic.Collect();

                }
                else
                {

                }
            }

            return resultValue;

        }



    }

    internal class GroupIndexes
    {

        public GroupIndexes()
        {
            this._dic = new Dictionary<string, GroupIndex>();
        }

        public GroupIndex Add(string label)
        {

            if (!this._dic.TryGetValue(label, out GroupIndex groupIndex))
                this._dic.Add(label, groupIndex = new GroupIndex(label));

            return groupIndex;

        }

        internal void Sort(JToken token, List<string> list, int index)
        {

            var match = list[index];
            var item = token.SelectToken(match);

            if (item != null && item is JValue v)
            {
                var i = v.Value?.ToString();
                GroupIndex d = Add(i);
                d.Sort(token, list, index);
            }
            else
            {

            }

        }

        internal JArray Collect()
        {

            var result = new JArray();

            foreach (var item in this._dic)
                result.Add(new JObject
                    (
                        new JProperty("Label", item.Key),
                        new JProperty("Items", item.Value.Collect())
                    )
                );

            return result;

        }

        private readonly Dictionary<string, GroupIndex> _dic;

    }

    internal class GroupIndex : List<JToken>
    {

        public GroupIndex(string label)
        {
            this.Label = label;
            this.GroupIndexes = new GroupIndexes();
        }

        public string Label { get; }
        public GroupIndexes GroupIndexes { get; }

        internal JArray Collect()
        {
            JArray result = new JArray();

            foreach (var item in this)
                result.Add(item);

            var r = GroupIndexes.Collect();
            if (r.Count > 0)
            {
                foreach (var item in r)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        internal void Sort(JToken token, List<string> list, int index)
        {

            if (list.Count - 1 == index)
                this.Add(token);

            else
                GroupIndexes.Sort(token, list, ++index);

        }

    }

}
