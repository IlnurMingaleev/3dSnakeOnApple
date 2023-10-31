using System;
using Infrustructure.MVC;
using Logic.GravityPhysics;
using Logic.Snake;
using Logic.Snake.Views;
using UnityEngine;

namespace Logic.Consumables.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class ConsumableView : View, IConsumableView
    {
        [SerializeField] ConsumablesParentView _prefabsParent;
        [SerializeField] public GravityPhysics.Planet _attractorPlanet;
        [SerializeField] private Rigidbody _rigidbody;
        private Action<IConsumableView> _actionOnGet;
        public Action<IConsumableView> ActionOnGet
        {
            get => _actionOnGet;
        }
        
        public ConsumablesParentView PrefabsParent
        {
            get => _prefabsParent;
        }
        public Rigidbody Rigidbody
        {
            get => _rigidbody;
        }

        public GravityPhysics.Planet AttractorPlanet
        {
            get => _attractorPlanet;
        }

        public Transform Transform { get => transform; }
        public GameObject GameObject { get => gameObject; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            


        }
#endif

        #region Setters

        public void Subscribe(Action<IConsumableView> actionOnGet)
        {
            _actionOnGet = actionOnGet;
        }

        public void Unsubscribe()
        {
            _actionOnGet = null;
        }

        #endregion
       
        public void InitConsumable(GravityPhysics.Planet planet, ConsumablesParentView parent, Action<IConsumableView> onConsumed = null)
        {
            _attractorPlanet = planet;
            _prefabsParent = parent;
            _actionOnGet = onConsumed;
        }
        
        
        private void FixedUpdate()
        {
            if (_attractorPlanet)
                _attractorPlanet.Attract(transform);
        }

        private void OnCollisionEnter(Collision collision)
        {
            IPlayerView playerView;
            if (collision.gameObject.TryGetComponent(out playerView))
            {
                _actionOnGet?.Invoke(this);
            }
        }

        #region Setters

        public void SetAttractorPlanet(Planet planet)
        {
            _attractorPlanet = planet;
        }

        #endregion
    }
}