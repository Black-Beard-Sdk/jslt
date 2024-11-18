using System;
using System.Collections.Generic;

namespace Bb.Expressions
{

    public class Variables
    {

        public Variables()
        {
            this._variables = new Dictionary<string, Variable>();
        }

        internal Variable Add(Variable variable)
        {

            if (variable.Type == null)
                variable.Type = variable.Instance.Type;

            var variable2 = GetByName(variable.Name);

            if (variable2 == null)
                this._variables.Add(variable.Name, variable);

            else if (variable.Instance != variable2.Instance)
                throw new Exceptions.DuplicatedArgumentNameException($"{variable.Name} already existing");

            return variable;

        }

        internal Variable GetByName(string name)
        {

            if (this._variables.TryGetValue(name, out Variable variable))
            {
                if (variable.Type == null && variable.Instance != null)
                    variable.Type = variable.Instance.Type;

                return variable;

            }

            if (_parent != null)
                return _parent.GetByName(name);

            return null;

        }

        public IEnumerable<Variable> GetVariables()
        {

            foreach (var item in this._variables)
                yield return item.Value;

            if (_parent != null)
                foreach (var item in _parent.GetVariables())
                    yield return item;

        }

        internal string GetNewName(string prefix)
        {
            if (prefix == null)
                throw new InvalidOperationException(nameof(prefix));
            else
            {
                var o = $"{prefix}{PrivatedIndex.GetNewIndex()}";
                return o;
            }

        }

        internal string GetNewName(Type type = null)
        {
            if (type == null)
            {
                return $"var_{PrivatedIndex.GetNewIndex()}";
            }
            else
            {
                var o = $"var_{CleanName(type)}{PrivatedIndex.GetNewIndex()}";
                return o;
            }

        }

        private string CleanName(Type type)
        {

            var result = type.Name;

            result = result.Replace("`", "_");

            return result;

        }

        internal void RemoveByName(string name)
        {
            if (this._variables.ContainsKey(name))
                this._variables.Remove(name);

            if (_parent != null)
                _parent.RemoveByName(name);

        }

        internal IEnumerable<Variable> Items { get => this._variables.Values; }

        internal void Merge(Variables variables)
        {
            if (variables != this)
                foreach (var item in variables.Items)
                    this.Add(item);
        }

        internal void SetParent(Variables variables)
        {

            this._parent = null;

            foreach (var item in variables.GetVariables())
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

            this._parent = variables;

        }


        private readonly Dictionary<string, Variable> _variables;
        private Variables _parent;

    }

}
