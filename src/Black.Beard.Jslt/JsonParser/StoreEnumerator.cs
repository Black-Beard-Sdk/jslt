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
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Bb.JsonParser
{
    public class StoreEnumerator<T> : IEnumerator<T>
    {

        public StoreEnumerator(BigJsonReader reader, Func<IStore, T> converter)
        {
            if (converter == null)
                throw new NullReferenceException(nameof(converter));
            _converter = converter;
            _reader = reader;
            _queue = new ConcurrentQueue<IStore>();
        }

        public T Current => _converter(_current);

        object IEnumerator.Current => _current;

        public bool MoveNext()
        {

            _current = null;
            if (_task == null)
                Reset();

            while (_reader.StateRunning == StatusEnum.Running || _queue.Count > 0)
                if (_queue.TryDequeue(out _current))
                    return true;
                else
                    Thread.Sleep(10);


            return false;

        }

        public void Reset()
        {
            _cancel = new System.Threading.CancellationToken();
            _task = Task.Run(() => _reader.Parse(Add), _cancel).WaitStarted();

            while (_reader.StateRunning == StatusEnum.NotStarted)
                Thread.Sleep(10);

        }

        private void Add(IStore j)
        {
            _queue.Enqueue(j);
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        private readonly Func<IStore, T> _converter;
        private readonly BigJsonReader _reader;
        private readonly ConcurrentQueue<IStore> _queue;
        private CancellationToken _cancel;
        private Task _task;
        private IStore _current;
    }

    public static class TaskHelper
    {

        public static Task WaitStarted(this Task self)
        {
            bool exit = false;
            while (exit)
            {
                switch (self.Status)
                {
                    case TaskStatus.Created:                        // 0
                    case TaskStatus.WaitingForActivation:           // 1
                    case TaskStatus.WaitingToRun:                   // 2
                        break;

                    case TaskStatus.Running:                        // 3
                    case TaskStatus.WaitingForChildrenToComplete:   // 4
                        exit = true;
                        break;

                    case TaskStatus.RanToCompletion:                // 5
                    case TaskStatus.Canceled:                       // 6
                    case TaskStatus.Faulted:                        // 7
                    default:
                        throw new Exception("Failed to start the task");
                }

            }

            return self;

        }

    }

}