using System;
using Infrustructure.Factory;
using Logic.Consumables.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.Tools.Pooling
{
    public class ConsuamblesPool : AbstractGameObjectPool<IConsumableView>
    {
        private ConsumablesParentView _consumablesParent;
        private GravityPhysics.Planet _planet;
        private float _radius;

        public ConsuamblesPool(IGameObjectFactory gameObjectFactory, ConsumablesParentView consumablesParent, GravityPhysics.Planet planet)
        {
            _gameObjectFactory = gameObjectFactory;
            _consumablesParent = consumablesParent;
            _planet = planet;
            _radius = _planet.GetComponentInChildren<SphereCollider>().radius;
        }


        public override void Return(IConsumableView obj, Action OnReturn = null)
        {
            obj.Transform.gameObject.SetActive(false);
            
            _objects.Add(obj);
        }

        public override IConsumableView Get(Action actionOnGet = null)
        {
           IConsumableView consumableView = _objects.TryTake(out IConsumableView result)
                ? result
                : _gameObjectFactory.Create(AssetPath._consumable, 
                    _consumablesParent.transform,
                    true).GetComponent<IConsumableView>();
            consumableView.InitConsumable(_planet,_consumablesParent, actionOnGet);
            consumableView.Transform.position = GetRandomPointOnSphereSurface(_radius);
            return consumableView;
        }
        
        public static Vector3 GetRandomPointOnSphereSurface(float radius)
        {
            // Generate random spherical coordinates (azimuth and polar angle)
            float azimuth = Random.Range(0f, 2f * Mathf.PI);
            float polar = Random.Range(0f, Mathf.PI);

            // Convert spherical coordinates to Cartesian coordinates
            float x = radius * Mathf.Sin(polar) * Mathf.Cos(azimuth);
            float y = radius * Mathf.Sin(polar) * Mathf.Sin(azimuth);
            float z = radius * Mathf.Cos(polar);

            return new Vector3(x, y, z);
        }
    }
}