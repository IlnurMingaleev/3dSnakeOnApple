using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrustructure.Factory
{
    public class PrefabInject
    {
        public readonly IObjectResolver _objectResolver;
        
        [Inject]
        public PrefabInject(IObjectResolver container)
        {
            _objectResolver = container;
        }
        
        public void InjectGameObject(GameObject go) => _objectResolver.InjectGameObject(go);
    }
}