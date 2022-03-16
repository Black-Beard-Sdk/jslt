using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Wizards
{


    [System.Diagnostics.DebuggerDisplay("{Current}")]
    public class WizardModel : INotifyPropertyChanged
    {


        public WizardModel()
        {
            this.Paths = new HashSet<string>();
            this.Variables = new VariableWizards();
            this._tabs = new List<WizardTabModel>();
            this._index = 0;
        }

        #region Properties

        public HashSet<string> Paths { get; set; }


        public object Index { get => this._index; }


        public object Count { get => this._tabs.Count; }

        public string TabDescription { get => this._tabs[this._index].Description; }

        public string TabErrors { get => this._tabs[this._index].Errors; }

        public string Title { get; private set; }

        public UIBlock CurrentUI { get; internal set; }

        public WizardTabModel Current { get => _tabs[this._index]; }

        public VariableWizards Variables { get; }

        #endregion Properties

        public WizardModel Add(string title, Action<WizardTabModel> configuration)
        {

            string description = null;

            var tab = new WizardTabModel(title, description);
            this._tabs.Add(tab);
            tab.Parent = this;

            configuration(tab);

            return this;

        }

        public WizardModel SetTitle(string title)
        {
            this.Title = title;
            return this;
        }

        public WizardModel Execute(Action<WizardModel> action)
        {
            this._action = action;
            return this;
        }

        public void MoveNext()
        {
            this.Current.ExecuteBeforeGoNext(CurrentUI);
            _index++;
            StateChange();
        }

        internal void CleanError()
        {
            this._tabs[_index].Errors = String.Empty;
        }

        public void MovePrevious()
        {
            _index--;
            StateChange();
        }

        public void StateChange()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanMovePrevious)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanMoveNext)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanTerminate)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Current)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TabDescription)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TabErrors)));
            }
        }

        public void ExecuteTerminate()
        {
            _action(this);
        }

        public bool CanMoveNext
        {
            get
            {

                if (_index < this._tabs.Count - 1)
                    if (this._tabs[_index].Validate())
                        return true;
                
                return false;

            }
        }

        public bool CanTerminate
        {
            get
            {

                if (_index + 1 == this._tabs.Count)
                    if (this._tabs[_index].Validate())
                        return true;

                return false;

            }
        }

        public bool CanMovePrevious
        {
            get
            {
                if (this._index > 0)
                {

                    return true;

                }

                return false;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private readonly List<WizardTabModel> _tabs;
        private int _index;
        private Action<WizardModel> _action;

    }


}
