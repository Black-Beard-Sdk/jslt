using Bb.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Helpers
{

    public static class PooledObjectExtension
    {

        public static PooledObject<T> WaitForGet<T>(this IObjectPool<T> self)
        {

            PooledObject<T> result;

            while ((result = self.GetObject()) == null)
            {
                System.Threading.Thread.Sleep(0);
            }

            return result;
        }
    }


}
