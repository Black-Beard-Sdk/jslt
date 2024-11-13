using Bb;
using Bb.JsltEvaluator;
using Bb.Json;
using Bb.Json.Linq;
using System;
using System.Collections.Generic;

namespace AppJsonEvaluator
{
    public class VariableHelper
    {

        public VariableHelper(Parameters parameters)
        {
            this._parameters = parameters;
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
               
        public IDictionary<string, JToken> GetVariables()
        {
            try
            {
                var datas = JObject.Parse(GetCode());
                return datas.ExtractVariables();
            }
            catch (Exception)
            {


            }

            return null;

        }
               
        private readonly Parameters _parameters;

    }

}
