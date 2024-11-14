#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Bb.Json.Linq;
using System;

namespace Bb.JsonParser
{
    public class StoreEnumerator<T> : IEnumerator<T>
    {

        public StoreEnumerator(BigJsonReader items, Func<IStore, T> converter)
        {
            if (converter == null)
                throw new NullReferenceException(nameof(converter));
            _converter = converter;
            _reader = items;
            _queue = new Queue<IStore>();
        }

        public T Current => _converter(_current);

        object IEnumerator.Current => _current;

        public bool MoveNext()
        {

            _current = null;

            if (TryToDequeue())
                return true;

            while (!_task.IsCompleted && _queue.Count == 0)
                Task.Yield();

            if (TryToDequeue())
                return true;

            return false;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool TryToDequeue()
        {
            if (_queue.Count > 0)
            {
                lock (_lock)
                    _current = _queue.Dequeue();
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _task = _reader.Read(Add);
        }

        private void Add(IStore j)
        {
            _queue.Enqueue(j);
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        private volatile object _lock = new object();
        private readonly Func<IStore, T> _converter;
        private readonly BigJsonReader _reader;
        private readonly Queue<IStore> _queue;
        private Task _task;
        private IStore _current;
    }

}