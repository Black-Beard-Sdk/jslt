
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bb.Wizards.Wpf
{


    public abstract class UIMethodWizardBase : Control, INotifyPropertyChanged
    {

        public UIMethodWizardBase(WizardTabModel tabModel)
        {

            this._uis = new List<Control>();
            this.Visible = true;
            this.TabModel = tabModel;

            this.SuspendLayout();

            InitializeComponent();

            this.Name = GetType().Name;
            this.Resize += ExecuteMethod_Resize;
            this.Dock = DockStyle.Fill;
                     
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected void VariableToValidate(VariableWizard variable)
        {
            this.TabModel.VariableToValidate(variable);
        }

        public WizardTabModel TabModel { get; }


        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing && (components != null))
            {
                foreach (var ui in this._uis)
                    ui.DataBindings.Clear();

                components.Dispose();               
            }

            base.Dispose(disposing);

        }


        protected void Map(Control ui, string PropertyName, VariableWizard variable)
        {
            this._uis.Add(ui);
            ui.DataBindings.Add(new Binding(PropertyName, variable, "Value"));
        }


        protected virtual void InitializeComponent()
        {
            this.TabModel.Parent.StateChange();
        }


        protected virtual void ExecuteMethod_Resize(object sender, EventArgs e)
        {

        }


        private IContainer components = null;
        private List<Control> _uis;


        public event PropertyChangedEventHandler? PropertyChanged;


    }

}
