using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Bb.Wizards
{


    public class VariableWizard : INotifyPropertyChanged
    {


        public VariableWizard(string key)
        {
            this.Key = key;
            this.Validators = new List<ValidationAttribute>();
        }


        public string Key { get; }


        public object? Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }


        public bool Validate(StringBuilder result)
        {
            var value = this.Value;
            return Validate(value, result);
        }


        public bool Validate(object? value, StringBuilder result)
        {

            bool test = true;
            bool hasValidators = this.Validators.Count > 0;

            if (hasValidators)
                foreach (ValidationAttribute attribute in this.Validators)
                    if (!attribute.IsValid(value))
                        try
                        {
                            attribute.Validate(value, this.Key);
                        }
                        catch (Exception ex)
                        {
                            test = false;
                            result.AppendLine(ex.Message);
                        }

            return test;

        }


        public void IsRequired()
        {
            this.AppendValidator(new RequiredAttribute());
        }


        internal void AppendValidator(ValidationAttribute validationAttribute)
        {

            var type = validationAttribute.GetType();

            if (!Validators.Any(c => c.GetType() == type))
                Validators.Add(validationAttribute);

        }


        public event PropertyChangedEventHandler? PropertyChanged;


        private object? _value;
        private List<ValidationAttribute> Validators;

    }


}
