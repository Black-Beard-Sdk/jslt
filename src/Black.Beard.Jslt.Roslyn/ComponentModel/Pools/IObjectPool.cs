using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Pools
{

    public interface IObjectPool<T>
    {
        PooledObject<T> GetObject();
        void PutObject(PooledObject<T> item);
        int MaxObject { get; }
    }



}
