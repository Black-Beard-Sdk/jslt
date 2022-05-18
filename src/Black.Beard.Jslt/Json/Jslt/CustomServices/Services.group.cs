using Bb.Json.Attributes;
using Bb.Json.Jslt.Services;
using Oldtonsoft.Json.Linq;
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

        [JsltExtensionMethod("union")]
        [JsltExtensionMethodParameter("source", "array that contains all sources to merge.")]
        public static JToken ExecuteUnion(RuntimeContext ctx, JArray source)
        {

            var resultValue = new List<JToken>(500);

            if (source != null)
            {

                foreach (JToken token in source)
                    if (token is JArray a1)
                    {
                        foreach (var token2 in a1)
                            resultValue.Add(token2);
                    }
                    else
                        resultValue.Add(token);

            }

            return new JArray(resultValue);

        }

        [JsltExtensionMethod("join")]
        [JsltExtensionMethodParameter("sourceLeft", "array that contains left items")]
        [JsltExtensionMethodParameter("keyLeft", "Key of the left object that must matches with the rights items.")]
        [JsltExtensionMethodParameter("rights", "List of right that fetch on the left objects")]
        public static JToken ExecuteJoin(RuntimeContext ctx, JArray sourceLeft, string keyLeft, bool cleanSource, RightJoins rights)
        {

            var list = new List<JToken>(sourceLeft.Count);

            if (sourceLeft != null)
            {

                List<KeyValuePair<string, JToken>> _items = new List<KeyValuePair<string, JToken>>(sourceLeft.Count);

                foreach (var item in sourceLeft)
                {

                    list.Add(item);

                    var k = item.SelectToken(keyLeft);
                    if (k is JValue v)
                    {
                        string keyValue = v.Value?.ToString();
                        _items.Add(new KeyValuePair<string, JToken>(keyValue, item));
                    }

                }

                foreach (var right in rights)
                {

                    ExecuteJoin(ctx, _items, right);

                    if (cleanSource)
                    {
                        right.Source = null;
                        GC.Collect();
                    }
                }

                _items.Clear();
                rights.Clear();

                return sourceLeft;

            }

            rights.Clear();
            return JValue.CreateNull();

        }


        private static void ExecuteJoin(RuntimeContext ctx, List<KeyValuePair<string, JToken>> left, RightJoin right)
        {

            if (right.Source != null)
            {

                var i = ExecuteGroup(right.Source, right.Key);

                foreach (var item in left)
                {

                    var l1 = i[item.Key].ToList();

                    var l = new List<JToken>(l1.Count);
                    foreach (var item2 in l1)
                    {
                        var item3 = item2.CloneToken();
                        var p = item3.SelectToken(right.Key);
                        if (p.Parent is JProperty p2)
                            p.Parent.Parent.RemoveItem(p.Parent);

                        else
                        {

                        }

                        l.Add(item3);
                    }
                    l1.Clear();

                    if (l.Any())
                    {

                        var d = new JArray(l);

                        if (item.Value is JObject o)
                        {
                            if (o.ContainsKey(right.Name))
                                o[right.Name] = d;
                            else
                                o.Add(new JProperty(right.Name, d));
                        }
                    }
                 
                    l.Clear();

                }

                i = null;

            }

        }

        private static ILookup<string, JToken> ExecuteGroup(JArray source, string groupPath)
        {

            List<KeyValuePair<string, JToken>> _list = new List<KeyValuePair<string, JToken>>(source.Count);

            foreach (JToken item in source)
            {
                JToken k = item.SelectToken(groupPath);
                var key = k.Value<string>();
                _list.Add(new KeyValuePair<string, JToken>(key, item));
            }

            var result = _list.ToLookup(c => c.Key, c => c.Value);
            _list.Clear();

            return result;

        }


        [JsltExtensionMethod("group")]
        [JsltExtensionMethodParameter("source", "Json array source.")]
        [JsltExtensionMethodParameter("groupPath", "json array of string. every item is a json path")]
        public static JToken ExecuteGroup(RuntimeContext ctx, JArray source, JArray groupPath)
        {

            var resultValue = new List<JObject>();

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
                    {
                        var result = dic.Sort(token, _h.ToList(), 0);
                    }

                    resultValue = dic.Collect();

                    if (!resultValue.Any())
                    {

                        HashSet<string> _hh = new HashSet<string>();
                        foreach (JToken token in source)
                        {
                            foreach (var item in token)
                            {
                                if (item is JProperty p)
                                    _hh.Add(p.Name.ToString());

                            }
                        }

                        string properties = string.Join(", ", _hh);

                        ctx.Diagnostics.AddWarning(ctx.ScriptFile, ctx.GetCurrentLocation(), "empty result", $"the source no matches datas with filter. Please check the properties names ({properties})");

                    }

                }
                else
                {

                }
            }

            return new JArray(resultValue);

        }

        [JsltExtensionMethod("createindex")]
        [JsltExtensionMethodParameter("name", "name of the index.")]
        [JsltExtensionMethodParameter("source", "Json source")]
        [JsltExtensionMethodParameter("objectPath", "json path that split the source")]
        [JsltExtensionMethodParameter("key", "json path that identify the key of the index")]
        public static JToken ExecuteCreateIndex(RuntimeContext ctx, JToken source, string objectPath, string key)
        {

            var dic = new JDictionaryValue();

            if (source != null)
            {

                if (!source.Any())
                {
                    ctx.Diagnostics.AddWarning(ctx.ScriptFile, ctx.GetCurrentLocation(), String.Empty, $"the sources is empty");
                    return dic;
                }

                IEnumerable<JToken> src = source;

                if (!string.IsNullOrEmpty(objectPath))
                {
                    src = source.SelectTokens(objectPath);

                    if (!src.Any())
                        ctx.Diagnostics.AddWarning(ctx.ScriptFile, ctx.GetCurrentLocation(), objectPath, $"the sources no matches item with the filter '{objectPath}'");
                }

                foreach (var item in src)
                {
                    var k = item.SelectToken(key);
                    string keyValue = null;

                    if (k is JValue v)
                        keyValue = v.Value?.ToString();

                    else
                    {
                        LocalDebug.Stop();
                    }

                    if (keyValue != null)
                    {

                        if (dic.ContainsKey(keyValue))
                            ctx.Diagnostics.AddWarning(ctx.ScriptFile, ctx.GetCurrentLocation(), keyValue, $"Duplicated key '{keyValue}'");

                        else
                            dic.Add(keyValue, item);

                    }
                    else
                    {
                        ctx.Diagnostics.AddWarning(ctx.ScriptFile, ctx.GetCurrentLocation(), item.ToString(Oldtonsoft.Json.Formatting.None), $"no key '{key}' resolved.");
                    }

                }

            }

            return dic;

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

        internal bool Sort(JToken token, List<string> list, int index)
        {

            var match = list[index];
            var item = token.SelectToken(match);

            if (item != null && item is JValue v)
            {
                var i = v.Value?.ToString();
                GroupIndex d = Add(i);
                return d.Sort(token, list, index);
            }
            else
            {
                return false;
            }

        }

        internal List<JObject> Collect()
        {

            var r = new List<JObject>();

            foreach (var item in this._dic)
                r.Add(new JObject
                    (
                        new JProperty("Label", item.Key),
                        new JProperty("Items", item.Value.Collect())
                    )
                );

            return r;

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

            var r2 = GroupIndexes.Collect();

            List<JToken> r = new List<JToken>(this.Count + r2.Count);

            r.AddRange(this);

            if (r.Count > 0)
                r.AddRange(r2);

            JArray result = new JArray(r);
            r.Clear();

            return result;

        }

        internal bool Sort(JToken token, List<string> list, int index)
        {

            if (list.Count - 1 == index)
            {
                this.Add(token);
                return true;
            }

            else
                return GroupIndexes.Sort(token, list, ++index);

        }

    }

    public class RightJoins : List<RightJoin>
    {

        public RightJoins()
        {

        }

        public RightJoins(JArray array)
        {

            foreach (var item in array)
            {
                if (item is JObject o)
                {

                    var p = new RightJoin();

                    if (o.ContainsKey(nameof(RightJoin.Name)))
                        p.Name = o[nameof(RightJoin.Name)].Value<string>();

                    if (o.ContainsKey(nameof(RightJoin.Key)))
                        p.Key = o[nameof(RightJoin.Key)].Value<string>();

                    if (o.ContainsKey(nameof(RightJoin.Source)))
                        p.Source = (JArray)o[nameof(RightJoin.Source)];

                    this.Add(p);

                }
            }

        }


    }

    public class RightJoin
    {

        public string Name { get; set; }

        public JArray Source { get; set; }

        public string Key { get; set; }

    }


}
