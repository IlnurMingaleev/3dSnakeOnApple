using System;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace Infrustructure.Factory
{
    public class GameObjectFactory : IGameObjectFactory
    {

        public Func<string, GameObject> _create;
        public Func<string, Transform, bool, GameObject> _createUnderParent;

        private PrefabInject _prefabInject;
        
        
        public GameObjectFactory(PrefabInject prefabInject)
        {
            this._prefabInject = prefabInject;
            _create = (string path) =>
            {
                GameObject prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
                GameObject sceneGo = Object.Instantiate(prefab);
                this._prefabInject.InjectGameObject(sceneGo);
                return sceneGo;
            };
            
            _createUnderParent = (string path, Transform parent, bool worldPositionStays ) =>
            {
                GameObject prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
                GameObject sceneGo = Object.Instantiate(prefab, parent, worldPositionStays);
                this._prefabInject.InjectGameObject(sceneGo);
                return sceneGo;
            };
        }

        public GameObject Instantiate(string path)
        {
            return _create?.Invoke(path);
        }
        public GameObject Instantiate(string path, Transform parent, bool worldPositionStays)
        {
            return _create?.Invoke(path);
        }
        


    }
}