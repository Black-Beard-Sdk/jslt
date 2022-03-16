using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

            if (result.Value != value)
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
