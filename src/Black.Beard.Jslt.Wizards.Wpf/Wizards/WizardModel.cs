using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this._variables = new Dictionary<string, object>();
            this._tabs = new List<WizardTabModel>();
            this._index = 0;
        }

        public object this[string name]
        {
            get
            {

                if (this._variables.TryGetValue(name, out object result))
                    return result;

                var result2 = this._tabs.Where(c => c.Title == name).FirstOrDefault();
                if (result2 != null)
                    return result2.Model;

                throw new Exception("missing variable");

            }
        }

        public WizardModel Add(WizardTabModel tab)
        {
            this._tabs.Add(tab);
            tab.Parent = this;
            return this;
        }

        public WizardModel SetTitle(string title)
        {
            this.Title = title;
            return this;
        }

        public WizardModel SetVariable(string variableName, object value)
        {
            this._variables.Add(variableName, value);
            return this;
        }

        public WizardModel Execute(Action<WizardModel> action)
        {
            this._action = action;
            return this;
        }

        public void MoveNext()
        {
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

        public WizardTabModel Current { get => _tabs[this._index]; }

        public void ExecuteTerminate()
        {
            _action(this);
        }

        public object CurrentValue
        {
            get => _tabs[this._index].Model;
            set
            {
                var old = _tabs[this._index].Model;
                if (old != value)
                {
                    _tabs[this._index].Model = value;
                    StateChange();
                }
            }
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

        public string TabDescription { get => this._tabs[this._index].Description; }

        public string TabErrors { get => this._tabs[this._index].Errors; }

        public string Title { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly List<WizardTabModel> _tabs;
        private int _index;
        private Action<WizardModel> _action;
        private Dictionary<string, object> _variables;
    }


}
