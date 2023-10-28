using System;
using Infrustructure.Factory;
using Logic.Planet;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Logic.Consumables
{
    public class ConsumablesSpawner : IConsumablesSpawner
    {
        private Planet.Planet _planet;
        private float _radius;
        private IObjectPool<GravityBody> _pool;
        private GravityBody _currentConsuamble;
        private PrefabInject _prefabInject;
        private bool _initialized;
        
        public ConsumablesSpawner( PrefabInject prefabInject)
        {
            _prefabInject = prefabInject;
            
        }

        public void Initialize()
        {
            _planet = Object.FindObjectOfType<ConsumablesParentView>().planet;
            _radius = _planet.transform.GetComponentInChildren<SphereCollider>().radius;
            Func<GravityBody> funcRandomSpawn = () =>
            {
                GravityBody consumable = Object.Instantiate(
                    Resources.Load(AssetPath._consumable,typeof(GravityBody)) as GravityBody);
                _prefabInject.InjectGameObject(consumable.gameObject);
                return consumable;
            };
            _pool = new ObjectPool<GravityBody>(funcRandomSpawn);
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            _currentConsuamble = _pool.Get();
            _currentConsuamble.gameObject.SetActive(true);
            _currentConsuamble.attractorPlanet = _planet;
            _currentConsuamble.transform.position = GetRandomPointOnSphereSurface(_radius);

        }

        public void ReturnConsumable()
        {
            _pool.Return(_currentConsuamble);
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