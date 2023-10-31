using System;
using System.Collections.Generic;

namespace Logic.Tools.Pooling
{
    public interface IGameObjectPool<T>
    {
        //List<T> GetPoolElementsAsList();
        T Get();
        public List<T> Objects { get; }

        //void Return(T obj, Action OnReturn = null);

        //void ReturnAll();

    }
}