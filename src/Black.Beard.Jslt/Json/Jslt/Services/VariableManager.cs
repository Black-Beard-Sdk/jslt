using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Json.Jslt.Services
{

    public class VariableManager
    {


        public VariableManager(Sources sources, EnvironmentVariableTarget target)
        {
            this._target = target;
            this.sources = sources;
            this._datas = new Dictionary<string, object>();
        }


        public void Add(IDictionary<string, JToken>? variables)
        {
            if (variables != null)
                foreach (var item in variables)
                    Add(item.Key, item.Value);
        }

        public void Add(string key, object value)
        {
            this._datas.Add(key, value);
        }

        public void Del(string key)
        {
            if (this._datas.ContainsKey(key))
                this._datas.Remove(key);
        }

        public bool Get(string key, out object resultValue)
        {

            resultValue = null;

            if (!this._datas.TryGetValue(key, out resultValue))
            {
                var items = Environment.GetEnvironmentVariables();
                if (items.Contains(key))
                    resultValue = Environment.GetEnvironmentVariable(key, _target);
                return false;
            }

            return true;

        }


        private readonly EnvironmentVariableTarget _target;
        private readonly Sources sources;
        private Dictionary<string, object> _datas;

    }


}
