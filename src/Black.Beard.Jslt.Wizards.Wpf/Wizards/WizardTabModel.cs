using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bb.Wizards
{


    [System.Diagnostics.DebuggerDisplay("{Title}")]
    public class WizardTabModel
    {

        internal WizardTabModel(string title, string description = null)
        {
            this.Title = title;
            this.Description = description;
            this._variables = new Dictionary<string, VariableWizard>();
        }

        public WizardTabModel HasDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public WizardTabModel InitializeUI(Action<UIBlock> action)
        {

            if (action == null)
                action = (t) => { };

            this._configure = action;

            return this;

        }

        public WizardTabModel ExecuteBeforeGoNext(Action<UIBlock> action)
        {

            if (action == null)
                throw new NullReferenceException(nameof(action));

            this._executeBeforeNext = action;

            return this;

        }

        internal void ExecuteBeforeGoNext(UIBlock child)
        {
            if (this._executeBeforeNext != null)
                this._executeBeforeNext(child);
        }

        internal void Configure(UIBlock child)
        {
            if (this._configure != null)
                this._configure(child);
        }

        internal bool Validate()
        {
            StringBuilder resultSb = new StringBuilder();
            bool result = true;
            foreach (var variable in this._variables)
            {
                if (!variable.Value.Validate(resultSb))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        internal void VariableToValidate(VariableWizard variable)
        {
            if (this._variables.TryGetValue(variable.Key, out var value))
            {
                if (value != variable)
                    throw new InvalidOperationException(variable.Key);
            }
            else
            {
                this._variables.Add(variable.Key, variable);
                variable.PropertyChanged += Variable_PropertyChanged;
            }
            
        }

        private void Variable_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            this.Parent.StateChange();
        }

        public WizardTabModel InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, out VariableWizard variable)
        {
            variable = this.Parent.Variables.SetVariable(variableName, null);
            if (actionInitializer != null)
                actionInitializer(variable);
            return this;
        }

        public WizardTabModel InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer)
        {
            var variable = this.Parent.Variables.SetVariable(variableName, null);
            if (actionInitializer != null)
                actionInitializer(variable);
            return this;
        }

        public WizardTabModel InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, object value, out VariableWizard variable)
        {
            variable = this.Parent.Variables.SetVariable(variableName, value);
            if (actionInitializer != null)
                actionInitializer(variable);
            return this;
        }

        public WizardTabModel InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, object value)
        {
            var variable = this.Parent.Variables.SetVariable(variableName, value);
            if (actionInitializer != null)
                actionInitializer(variable);
            return this;
        }

        internal bool Validate(string variableName, StringBuilder resultSb)
        {   
            var v = this.Parent.Variables[variableName];
            return v.Validate(resultSb);
        }

        internal bool Validate(string variableName, string data, StringBuilder resultSb)
        {            
            var v = this.Parent.Variables[variableName];
            return v.Validate(data, resultSb);
        }

        public List<ValidationAttribute> Validators { get; }


        public WizardModel Parent { get; internal set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string Errors { get; set; }


        private Action<UIBlock> _configure;
        private Action<UIBlock> _executeBeforeNext;
        private Dictionary<string, VariableWizard> _variables;

    }

}
