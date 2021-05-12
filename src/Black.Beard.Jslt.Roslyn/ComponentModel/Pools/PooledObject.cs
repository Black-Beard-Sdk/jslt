using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Pools
{

    /// <summary>
    /// Box for the embedded instance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PooledObject<T> : IDisposable
    {

        internal PooledObject(ObjectPool<T> pool)
        {
            this._pool = pool;
        }

        public void Release()
        {
            _pool.PutObject(this);
        }

        public int InstanceId { get; internal set; }

        public T Instance { get; internal set; }

        public void Dispose(bool disposing)
        {
            if (disposing)
                Release();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~PooledObject()
        {
            Dispose(false);
        }

        private ObjectPool<T> _pool;

    }

}
