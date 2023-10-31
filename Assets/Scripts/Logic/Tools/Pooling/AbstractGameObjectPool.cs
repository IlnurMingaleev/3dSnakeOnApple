using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Infrustructure.Factory;
using Infrustructure.MVC;

namespace Logic.Tools.Pooling
{


    public abstract class AbstractGameObjectPool<T> : IGameObjectPool<T>
    {
        protected readonly List<T> _objects  = new List<T>();

        protected IGameObjectFactory _gameObjectFactory;

        public abstract T Get();
        public List<T> Objects => _objects; 
    }

}