using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Json.Jslt.CustomServices.MultiCsv
{

    public class JsonVisitor : IVisitor<JToken>
    {


        public JsonVisitor()
        {
            this._hash = new HashSet<Block>();
        }

        public JToken Visit(Block block)
        {

            Dictionary<string, JToken> dic = new Dictionary<string, JToken>();

            foreach (Block subList in block.Subs)
            {

                if (!dic.TryGetValue(subList.Name, out var list))
                    dic.Add(subList.Name, list = new JArray());

                if (this._hash.Add(subList))
                    (list as JArray).Add(subList.Accept(this));

                else
                {

                }

            }


            foreach (var property in block)
            {

                if (!IgnoreEmptyProperties || !string.IsNullOrEmpty(property.Value))

                    dic.Add(property.Key, new JValue(property.Value));

            }


            var result = new JObject();

            foreach (var kv in dic)
                result.Add(new JProperty(kv.Key, kv.Value));


            return result;

        }


        public bool IgnoreEmptyProperties { get; set; }

        private readonly HashSet<Block> _hash;

    }
}
