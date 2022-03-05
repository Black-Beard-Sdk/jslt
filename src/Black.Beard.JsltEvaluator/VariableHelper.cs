using Bb;
using Bb.JsltEvaluator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace AppJsonEvaluator
{
    public class VariableHelper
    {

        public VariableHelper(Parameters parameters)
        {
            this._parameters = parameters;
            this._variables = new Dictionary<string, object>();
        }


        public bool OpenWindow()
        {

            var window = new WindowVariables()
            {
                Code = GetCode()
            };



            if (window.ShowDialog().Value)
            {
                SetCode(window.Code);
                return true;
            }

            return false;

        }

        private void SetCode(string code)
        {
            _parameters.Variables = code.ConvertToBase64();
        }

        private string GetCode()
        {

            if (string.IsNullOrEmpty(_parameters.Variables))
                _parameters.Variables = GetDefaultValue();

            var value = _parameters.Variables.ConvertFromBase64();

            return value;

        }

        private string GetDefaultValue()
        {
            var template = @"{

    ""@var1"": ""My value""

}";
            return template.ConvertToBase64();

        }
               
        public IDictionary<string, object> GetVariables()
        {
            this._variables.Clear();
            var datas = JObject.Parse(GetCode());
            ApplyVariables(datas);
            return this._variables;
        }

        private void ApplyVariables(JObject datas)
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

                TryToApplyChildres(data.Value);

            }

        }

        private void TryToApplyChildres(JToken data)
        {
            
            if (data is JObject o)
                ApplyVariables(o);

            else if (data is JArray a)
                foreach (var item in a)
                    TryToApplyChildres(item);

        }


        private readonly Parameters _parameters;
        private Dictionary<string, object> _variables;


    }

}
