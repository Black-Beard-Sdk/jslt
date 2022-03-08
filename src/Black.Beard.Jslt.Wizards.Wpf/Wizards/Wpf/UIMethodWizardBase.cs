
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bb.Wizards.Wpf
{


    public abstract class UIMethodWizardBase : Control, INotifyPropertyChanged
    {

        public UIMethodWizardBase(WizardModel model)
        {
            this.Visible = true;
            this.Model = model;

            this.SuspendLayout();

            InitializeComponent();

            this.Name = GetType().Name;
            this.Resize += ExecuteMethod_Resize;

            if (model.Current.AllowedDrop)
            {
                this.AllowDrop = true;
                this.DragEnter += UIMethodWizardBase_DragEnter;
                this.DragDrop += UIMethodWizardBase_DragDrop;
            }

            this.ResumeLayout(false);
            this.PerformLayout();

            model.PropertyChanged += Model_PropertyChanged;

            //this.BackColor = Color.AliceBlue;

            Datas = Model.CurrentValue;

        }

        private void UIMethodWizardBase_DragDrop(object? sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent("FileName"))
            {

                var d = e.Data.GetData("FileName");
                string[] datas = (string[])e.Data.GetData("FileName");
                var data = datas[0];
                if (!string.IsNullOrEmpty(data))
                {
                    this.Datas = data;
                }

            }
            else if (e.Data.GetDataPresent("Text"))
            {

                var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                if (!string.IsNullOrEmpty(data))
                {
                    this.Datas = data;
                }

            }
            else
            {

            }

        }

        private void UIMethodWizardBase_DragEnter(object? sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent("FileName"))
            {

                var d = e.Data.GetData("FileName");
                string[] datas = (string[])e.Data.GetData("FileName");
                var data = datas[0];
                if (!string.IsNullOrEmpty(data))
                {
                    if (Model.Current.TryValidate(data))
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                }

            }
            else if (e.Data.GetDataPresent("Text"))
            {

                var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                if (!string.IsNullOrEmpty(data))
                {
                    if (Model.Current.TryValidate(data))
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                }

            }
            else
            {

            }

        }



        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Datas)));
        }


        public WizardModel Model { get; }


        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing && (components != null))
            {
                this._ui.DataBindings.Clear();
                components.Dispose();
                Model.PropertyChanged -= Model_PropertyChanged;
            }

            base.Dispose(disposing);

        }

        protected void Map(Control ui, string PropertyName)
        {
            this._ui = ui;
            ui.DataBindings.Add(new Binding(PropertyName, this, "Datas"));
        }


        public object Datas
        {
            get => this.Model.CurrentValue;
            set
            {
                this.Model.CurrentValue = value;
            }
        }


        protected virtual void InitializeComponent()
        {


        }


        protected virtual void ExecuteMethod_Resize(object sender, EventArgs e)
        {

        }


        public void ApplyValueToModel()
        {
            this.Model.CurrentValue = this.Datas;
        }


        private System.ComponentModel.IContainer components = null;
        private Control _ui;

        public event PropertyChangedEventHandler? PropertyChanged;

    }

}
