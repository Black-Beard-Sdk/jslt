using Bb.Contracts;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Jslt.Services
{

    public class VariableManager : VariableResolver
    {

        public VariableManager(IVariableResolver next)
            : base(next)
        {
            this._datas = new Dictionary<string, object>();
        }


        /// <summary>
        /// Add variable dictionary
        /// </summary>
        /// <param name="variables"></param>
        public void Add(IDictionary<string, object>? variables)
        {
            if (variables != null)
                foreach (var item in variables)
                    Add(item.Key, item.Value);

        }

        /// <summary>
        /// Add variable by the name
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            this._datas.Add(key, value);
        }

        /// <summary>
        /// Remove the variable
        /// </summary>
        /// <param name="key"></param>
        public void Del(string key)
        {
            if (this._datas.ContainsKey(key))
                this._datas.Remove(key);
        }

        /// <summary>
        /// Variable implementation
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resultValue"></param>
        /// <returns></returns>
        protected override bool GetImpl(string key, out object resultValue)
        {
            return this._datas.TryGetValue(key, out resultValue);
        }

        private Dictionary<string, object> _datas;

    }

}
