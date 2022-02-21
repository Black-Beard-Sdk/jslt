using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bb.JsltEvaluator.Wizards
{

    [System.Diagnostics.DebuggerDisplay("{Title}")]
    public class WizardTabModel
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
                _model = value;
            }
        }


        public TemplateEnum Template { get; private set; }


        public bool Validate()
        {
            bool test = true;
            StringBuilder sb = new StringBuilder();

            if (this.Model != null)
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

            return test;
        }

        private object _model;
        public object Tag { get; private set; }

        public WizardTabModel SetAction(Action<ExecuteMethod, WizardTabModel> action)
        {

            this.Tag = action;

            return this;

        }
    }


}
