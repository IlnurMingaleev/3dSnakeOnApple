using System;
using System.Collections.Concurrent;

namespace Logic.Consumables
{
    public interface IObjectPool<T>
    {
        T Get();
        void Return(T obj);
    }

    public class ObjectPool<T> : IObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T> _createObject;

        public ObjectPool(Func<T> createObject)
        {
            _createObject = createObject;
            _objects = new ConcurrentBag<T>();
        }

        public T Get()
        {
            return _objects.TryTake(out T obj) ? obj : _createObject();
        }

        public void Return(T obj)
        {
            _objects.Add(obj);
        }
    }

}