using System;
using System.Collections.Generic;

namespace Logic.Tools.Pooling
{
    public interface IGameObjectPool<T>
    {
        List<T> GetPoolElementsAsList();
        T Get(Action OnGet = null);
        void Return(T obj, Action OnReturn = null);

        void ReturnAll();

    }
}