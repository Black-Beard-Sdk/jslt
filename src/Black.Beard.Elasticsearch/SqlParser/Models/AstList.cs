using Bb.Elastic.Runtimes;
using System.Collections;
using System.Collections.Generic;

namespace Bb.Elastic.SqlParser.Models
{

    public class AstList<T> : AstBase, IList<T>
        where T : AstBase
    {

        public AstList(Locator position) : base(position)
        {
            this._list = new List<T>();
        }

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
                _list.Add(item);
        }


        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public override T1 Accept<T1>(IVisitor<T1> visitor)
        {
            return visitor.VisitList(this);
        }

        private List<T> _list;

    }


}
