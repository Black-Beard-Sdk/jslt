using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Pools
{

    public class ObjectPool<T> : IObjectPool<T>
    {
        public int CreatedObject { get; set; }
        public int MaxObject { get; set; }

        #region ctor

        /// <summary>
        /// Create a pool with instances available
        /// </summary>
        /// <param name="instances"></param>
        public ObjectPool(params T[] instances)
            : this(instances.Length)
        {
            foreach (var item in instances)
            {
                CreateBox(item);
            }            
        }        

        /// <summary>
        /// Create a pool with x instances
        /// </summary>
        /// <param name="objectGenerator"></param>
        /// <param name="initCreate"></param>
        public ObjectPool(Func<T> objectGenerator, int initCreate = 0)
            : this(10)
        {

            if (objectGenerator == null)
                throw new ArgumentNullException("objectGenerator");

            _objectGenerator = objectGenerator;
         
            for (int i = 0; i < initCreate; i++)
                CreateBox();

        }

        private ObjectPool(int maxobject = 10)
        {
            MaxObject = maxobject;
            _objects = new BlockingCollection<PooledObject<T>>();
        }

        #endregion ctor

        #region implement IObjectPool

        /// <summary>
        /// Get an PooledObject of <see cref="T"/> with an instance int the property instance.
        /// </summary>
        /// <returns></returns>
        public virtual PooledObject<T> GetObject()
        {
            
            PooledObject<T> item;
            
            if (_objects.TryTake(out item))
                return item;

            if (CreatedObject <= MaxObject && _objectGenerator != null)
                lock (_lock)
                    item = CreateBox();
            
            return item;

        }

        private PooledObject<T> CreateBox()
        {
            var j = new PooledObject<T>(this) { InstanceId = CreatedObject++, Instance = _objectGenerator() };
            _objects.Add(j);
            return j;
        }

        private PooledObject<T> CreateBox(T item)
        {
            var j = new PooledObject<T>(this) { InstanceId = CreatedObject++, Instance = item };
            _objects.Add(j);
            return j;
        }

        /// <summary>
        /// put an object after use
        /// </summary>
        /// <param name="item"></param>
        public void PutObject(T item)
        {
            CreateBox(item);
        }

        /// <summary>
        /// put an object after use
        /// </summary>
        /// <param name="item"></param>
        public void PutObject(PooledObject<T> item)
        {
            _objects.Add(item);
        }

        #endregion implement IObjectPool

        private BlockingCollection<PooledObject<T>> _objects;
        private System.Func<T> _objectGenerator;
        private volatile object _lock = new object();

    }



}
