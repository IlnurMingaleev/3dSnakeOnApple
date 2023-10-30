using System;
using Infrustructure.MVC;
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
        private Action _actionOnGet;
        public Action ActionOnGet
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

#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            


        }
#endif

        #region Setters

        public void Subscribe(Action actionOnGet)
        {
            _actionOnGet = actionOnGet;
        }
        

        #endregion
       
        public void InitConsumable(GravityPhysics.Planet planet, ConsumablesParentView parent, Action onReturn = null)
        {
            _attractorPlanet = planet;
            _prefabsParent = parent;
            _actionOnGet = onReturn;
        }
        
        
        private void FixedUpdate()
        {
            if (_attractorPlanet)
                _attractorPlanet.Attract(transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            IPlayerView playerView;
            if (other.gameObject.TryGetComponent(out playerView))
            {
                _actionOnGet?.Invoke();
            }
        }
    }
}