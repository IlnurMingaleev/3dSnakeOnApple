using System;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

namespace Infrustructure.Factory
{
    public class GameObjectFactory: IGameObjectFactory 
    {
        private PrefabInject _prefabInject;
        [Inject]
        public PrefabInject PrefabInject
        {
            get => _prefabInject;
            set => _prefabInject = value;
        }
        

        public GameObject Create(string path)
        {
            GameObject prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
            GameObject sceneGo = Object.Instantiate(prefab);
            this._prefabInject.InjectGameObject(sceneGo);
            return sceneGo;
        }
        public GameObject Create(string path, Transform parent, bool worldPositionStays)
        {
            GameObject prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
            GameObject sceneGo = Object.Instantiate(prefab, parent, worldPositionStays);
            this._prefabInject.InjectGameObject(sceneGo);
            return sceneGo;
        }
        


    }
}