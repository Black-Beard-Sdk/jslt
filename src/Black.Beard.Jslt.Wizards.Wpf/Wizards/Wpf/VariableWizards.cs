using Bb.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Bb.Wizards
{

    public class VariableWizards
    {


        public VariableWizards()
        {
            this._variables = new Dictionary<string, VariableWizard>();
        }


        public IEnumerable<VariableWizard> Variables
        {
            get
            {
                foreach (var item in this._variables)
                    yield return item.Value;
            }

        }


        public void Save()
        {

            if (!string.IsNullOrEmpty(Filepath))
            {

                var f = new FileInfo(Filepath);
                if (!f.Directory.Exists)
                    f.Directory.Create();

                var datas = GetVariables();

                var payload = datas.ToString(Bb.Json.Formatting.Indented);

                Filepath.Save(payload);
            }
        }

        public string Filepath { get; set; }

        public void Load()
        {

            if (!string.IsNullOrEmpty(Filepath))
            {

                var f = new FileInfo(Filepath);
                if (f.Exists)
                {
                    var variables = (JObject)Filepath
                    .LoadFromFile()
                    .ConvertToJson()
                    ;

                    foreach (var property in variables.Properties())
                    {
                        var value = ((JValue)property.Value)?.Value;
                        var v = SetVariable(property.Name, value);
                    }
                }

            }

        }


        protected JObject GetVariables()
        {

            var variables = new JObject();

            foreach (var item in this._variables.Values.Where(c => c.IsStored))
            {

                var value = item.Value;

                if (value != null)
                    variables.Add(new JProperty("@" + item.Key, value));
                else
                    variables.Add(new JProperty("@" + item.Key, JValue.CreateNull()));

            }

            return variables;
        }


        public VariableWizard this[string name]
        {
            get
            {
                this._variables.TryGetValue(name, out VariableWizard result);
                return result;
            }
        }


        public VariableWizard SetVariable(string variableName, object? value)
        {

            if (!this._variables.TryGetValue(variableName, out VariableWizard result))
                this._variables.Add(variableName, result = new VariableWizard(variableName)
                {
                    Value = value
                });

            if (value != null && result.Value != value)
                result.Value = value;

            return result;

        }


        public void AppendValidator(string variableName, ValidationAttribute validationAttribute)
        {

            if (!this._variables.TryGetValue(variableName, out VariableWizard variable))
                this._variables.Add(variableName, variable = new VariableWizard(variableName));

            variable.AppendValidator(new RequiredAttribute());

        }


        public bool VariableContainKey(string name)
        {
            return this._variables.ContainsKey(name);
        }


        private Dictionary<string, VariableWizard> _variables;

    }


}
