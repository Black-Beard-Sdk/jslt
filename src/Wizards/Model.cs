using Bb;
using Bb.Wizards;
using Bb.Wizards.Wpf;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

            var file = Path.GetFileNameWithoutExtension(ModelFile) + ".var";
            var filePath = Path.Combine(ModelDir, file);

            model.Variables.Filepath = filePath;
            model.Variables.Load();

            var wizard = new WizardWindow(model);

            if (wizard.ShowDialog().Value)
            {

                model.Variables.Save();

            }




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

            var file = new FileInfo(Path.Combine(this.ModelDir, "variablesLastRun.json"));
            
            if (file.Exists)
                file.Delete();

            else if (!file.Directory.Exists)
                file.Directory.Create();

            file.FullName.Save(variables.ToString(Newtonsoft.Json.Formatting.Indented));

            return variables;
        }


        private HashSet<Type> _h;

        public HashSet<string> Paths { get; }
        public string ModelFile { get; internal set; }
        public string ModelDir { get; internal set; }

    }

}
