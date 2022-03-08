using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bb.Wizards
{

    [System.Diagnostics.DebuggerDisplay("{Title}")]
    public class WizardTabModel : INotifyPropertyChanged
    {


        public WizardTabModel(string title, string description = null)
        {
            this.Title = title;
            this.Description = description;
            this.Validators = new List<ValidationAttribute>();
        }

        public WizardTabModel()
        {
            this.Validators = new List<ValidationAttribute>();
        }

        public WizardTabModel IsRequired()
        {
            this.Validators.Add(new RequiredAttribute());
            return this;

        }

        public WizardTabModel SetModel(object model)
        {
            this.Model = model;
            this.Errors = String.Empty;
            return this;

        }

        public WizardTabModel SetTemplate(TemplateEnum template)
        {
            this.Template = template;
            return this;

        }

        public WizardTabModel SetAllowed()
        {
            this.AllowedDrop = true;
            return this;
        }

        public bool AllowedDrop { get; private set; }



        public List<ValidationAttribute> Validators { get; }


        public WizardModel Parent { get; internal set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string Errors { get; set; }


        public object Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    PropertyHasChanged();
                }
            }
        }


        private void PropertyHasChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Model)));
        }


        public TemplateEnum Template { get; private set; }


        public bool Validate()
        {

            bool test = true;
            StringBuilder sb = new StringBuilder();

            if (this.Model != null)
            {
                foreach (var attribute in this.Validators)
                {

                    var validationContext = new ValidationContext(this.Model, null, null)
                    {
                        MemberName = this.Title,
                    };

                    var result = attribute.GetValidationResult(this.Model, validationContext);

                    if (result != null)
                    {
                        sb.AppendLine(result.ErrorMessage);
                        test = false;
                    }
                }

                this.Errors = sb.ToString();

            }
            else test = false;

            return test;

        }

        public bool TryValidate(object data)
        {

            bool test = true;

            foreach (var attribute in this.Validators)
            {

                var validationContext = new ValidationContext(data, null, null)
                {
                    MemberName = this.Title,
                };

                var result = attribute.GetValidationResult(data, validationContext);

                if (result != null)
                    test = false;
            }

            return test;

        }

        private object _model;

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Tag { get; private set; }


        public WizardTabModel SetAction(Action<UIExecuteMethod, WizardTabModel> action)
        {

            this.Tag = action;

            return this;

        }
    }


}
