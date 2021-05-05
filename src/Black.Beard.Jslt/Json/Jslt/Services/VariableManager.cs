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
            this._datas.Add(key, _datas);
        }

        public string Translate(string key)
        {

            var d = key;
            var matchs = VariableManagerExtension.Match(key);
            while (matchs.Success)
            {

                var transform = false;
                if (!this._datas.TryGetValue(key, out object value))
                {
                    value = Environment.GetEnvironmentVariable(key, _target);
                    if (value != null)
                    {
                        this._datas.Add(key, value);
                        transform = true;
                    }
                }
                else
                    transform = true;

                if (transform)
                    d.Replace(matchs.Value, value.ToString());

                matchs = matchs.NextMatch();

            }


            return d;
        }

        private readonly EnvironmentVariableTarget _target;
        private readonly Sources sources;
        private Dictionary<string, object> _datas;

    }


}
