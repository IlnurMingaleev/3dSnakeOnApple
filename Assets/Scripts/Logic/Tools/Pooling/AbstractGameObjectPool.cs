using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Infrustructure.Factory;
using Infrustructure.MVC;

namespace Logic.Tools.Pooling
{
    public interface IPoolableObject
    {
        void Initialize(View view);

    }

    public abstract class AbstractGameObjectPool<T> : IGameObjectPool<T>
    {
        protected readonly ConcurrentBag<T> _objects  = new ConcurrentBag<T>();

        protected IGameObjectFactory _gameObjectFactory;
        //private readonly Func<T> _createObject;
        
        

        public List<T> GetPoolElementsAsList()
        {
            return _objects.ToList();
        }

        public abstract void Return(T obj, Action OnReturn = null);
        public void ReturnAll()
        {
            foreach (T element in GetPoolElementsAsList())
            {
                Return(element);
            }
        }


        public abstract T Get(Action OnGet = null);
    }

}