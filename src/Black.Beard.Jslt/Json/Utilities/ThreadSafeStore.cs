﻿#region License
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

using System;
using System.Collections.Concurrent;

namespace Bb.Json.Utilities
{
    internal class ThreadSafeStore<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, TValue> _concurrentStore;
        private readonly Func<TKey, TValue> _creator;

        public ThreadSafeStore(Func<TKey, TValue> creator)
        {
            ValidationUtils.ArgumentNotNull(creator, nameof(creator));
            _creator = creator;
            _concurrentStore = new ConcurrentDictionary<TKey, TValue>();
        }

        public TValue Get(TKey key)
        {
            return _concurrentStore.GetOrAdd(key, _creator);
        }

    }
}