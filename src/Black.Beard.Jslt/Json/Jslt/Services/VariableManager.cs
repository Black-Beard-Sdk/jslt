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


        public void Add(string key, object value)
        {
            this._datas.Add(key, value);
        }

        public void Del(string key)
        {
            if (this._datas.ContainsKey(key))
                this._datas.Remove(key);
        }

        public object Get(string key)
        {

            if (!this._datas.TryGetValue(key, out object value))
                value = Environment.GetEnvironmentVariable(key, _target);

            return value;

        }

  
        private readonly EnvironmentVariableTarget _target;
        private readonly Sources sources;
        private Dictionary<string, object> _datas;

    }


}
