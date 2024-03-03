using System.Collections.Generic;
using System.Linq;

namespace Bb.Expressions
{


    public class Labels
    {

        public Labels()
        {
            this._labels = new Dictionary<string, Label>();
        }

        internal void Add(Label label)
        {

            if (label.Kind != KindLabelEnum.Default && this._labels.Values.Any(c => c.Kind == label.Kind))
                throw new Exceptions.DuplicatedArgumentNameException($"the bloc contains already label of type {label.Kind.ToString()}");

            this._labels.Add(label.Name, label);

        }

        internal Label GetByName(string name)
        {

            if (!this._labels.TryGetValue(name, out Label label))
                if (_parent != null)
                    label = _parent.GetByName(name);

            return label;
        }

        internal static string GetNewName()
        {
            return $"label_{PrivatedIndex.GetNewIndex()}";
        }

        internal void RemoveByName(string name)
        {

            if (this._labels.ContainsKey(name))
                this._labels.Remove(name);

            if (_parent != null)
                _parent.RemoveByName(name);

        }

        internal IEnumerable<Label> Items { get => this._labels.Values; }

        internal void Merge(Labels labels)
        {
            foreach (var item in labels.Items)
                this.Add(item);
        }

        public IEnumerable<Label> GetLabels()
        {

            foreach (var item in this._labels)
                yield return item.Value;

            if (_parent != null)
                foreach (var item in _parent.GetLabels())
                    yield return item;

        }
        
        internal void SetParent(Labels labels)
        {

            this._parent = null;

            foreach (var item in labels.GetLabels())
            {
                var item2 = this.GetByName(item.Name);
                if (item2 != null)
                {
                    if (item2.Instance == item.Instance)
                        RemoveByName(item.Name);
                    else
                        throw new Exceptions.DuplicatedArgumentNameException($"{item.Name} already existings");
                }
            }

            this._parent = labels;

        }

        private readonly Dictionary<string, Label> _labels;
        private Labels _parent;

    }

}
