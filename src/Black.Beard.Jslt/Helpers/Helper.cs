using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb
{

    public static class Helper
    {

        public static string PrintByteArray(this byte[] array)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
                sb.Append($"{array[i]:X2}");
            return sb.ToString();
        }

        /// <summary>
        /// Extract variables from specified object
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IDictionary<string, JToken> ExtractVariables(this JObject self)
        {
            var _variables = new Dictionary<string, JToken>();
            self.ExtractVariables(_variables);
            return _variables;
        }

        private static void ExtractVariables(this JObject datas, IDictionary<string, JToken> _variables)
        {

            foreach (var data in datas.Properties())
            {

                var name = data.Name;

                if (name.StartsWith("@"))
                {
                    name = name.Substring(1);
                    if (_variables.ContainsKey(name))
                        throw new Exception("duplicated variable key");
                    _variables.Add(name, data.Value);
                }

                TryToExtratctFromChildren(data.Value, _variables);

            }

        }

        private static void TryToExtratctFromChildren(JToken data, IDictionary<string, JToken> _variables)
        {

            if (data is JObject o)
                ExtractVariables(o, _variables);

            else if (data is JArray a)
                foreach (var item in a)
                    TryToExtratctFromChildren(item, _variables);

        }



    }


}
