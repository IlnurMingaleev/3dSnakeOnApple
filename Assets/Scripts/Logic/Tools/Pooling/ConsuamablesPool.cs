using System;
using System.Collections.Generic;
using Infrustructure.Factory;
using Logic.Consumables.Views;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Logic.Tools.Pooling
{
    public class ConsuamablesPool 
    {
        private ConsumablesParentView _consumablesParent;
        private GravityPhysics.Planet _planet;
        private IGameObjectFactory _gameObjectFactory;
        private IConsumableView _consumedApple;
        private List<IConsumableView> _allConsumables;
        private const int _consumablesCount = 25;
        public IConsumableView CurrentConsumable { get =>_consumedApple; }
        private float _radius = 27.0f;

        public ConsuamablesPool(IGameObjectFactory gameObjectFactory, ConsumablesParentView consumablesParent, GravityPhysics.Planet planet)
        {
            _gameObjectFactory = gameObjectFactory;
            _consumablesParent = consumablesParent;
            _planet = planet;
            _radius = planet.GetComponentInChildren<SphereCollider>().radius;
        }

        
        public IConsumableView Get(Action<IConsumableView> OnConsumed , IConsumableView consumedApple)
        {
            if (consumedApple == null)
            {
                consumedApple =_gameObjectFactory.Create(AssetPath._consumable, _consumablesParent.transform, true).GetComponent<IConsumableView>();
                consumedApple.InitConsumable(_planet,_consumablesParent);
            }
            consumedApple.GameObject.SetActive(false);
            consumedApple.Transform.position = GetRandomPointOnSphereSurface(_radius);
            consumedApple.SetAttractorPlanet(_planet);
            consumedApple.Subscribe(OnConsumed);
            consumedApple.GameObject.SetActive(true);
            
            return consumedApple;
        }

        public void Init(Action<IConsumableView> OnConsumed )
        {
            for (int i = 0; i < _consumablesCount; i++) 
            {
                IConsumableView consumableView = _gameObjectFactory.Create(
                    AssetPath._consumable,
                    _consumablesParent.transform, 
                    true).GetComponent<IConsumableView>();
                Get(OnConsumed, consumableView);

            }
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