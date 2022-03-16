using Bb.Wizards;
using Bb.Wizards.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizards
{


    public abstract class Model
    {

        public Model()
        {

            _h = new HashSet<Type>()
            {
                typeof(string),
                typeof(int),
                typeof(DateTime),
                typeof(char),
                typeof(char),
            };

            this.Paths = new HashSet<string>();

        }

        public bool Debug { get; set; }

        public abstract WizardModel Initialize_Impl();

        public void Execute()
        {

            if (Debug)
            {
                if (!System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Launch();
                else
                    System.Diagnostics.Debugger.Break();
            }

            var model = Initialize_Impl();

            foreach (var path in this.Paths)
                model.Paths.Add(path);

            var wizard = new WizardWindow(model);

            wizard.ShowDialog();

        }

        protected JObject GetVariables(WizardModel model)
        {

            var variables = new JObject();

            foreach (var item in model.Variables.Variables)
            {

                var value = item.Value;

                if (value != null)
                {

                    if (_h.Contains(value.GetType()))
                    {

                        variables.Add(new JProperty("@" + item.Key, value));

                    }
                    else
                    {

                    }

                }
                else
                    variables.Add(new JProperty("@" + item.Key, value));

            }

            return variables;
        }


        private HashSet<Type> _h;

        public HashSet<string> Paths { get; }
    }

}
