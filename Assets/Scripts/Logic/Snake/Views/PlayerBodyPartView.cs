using Logic.GravityPhysics;
using UnityEngine;

namespace Logic.Snake.Views
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerBodyPartView : MonoBehaviour,IPlayerBodyPartView
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Planet _attractorPlanet;

        public Planet AttractorPlanet
        {
            get => _attractorPlanet;
        }
        public Rigidbody Rigidbody
        {
            get => _rigidbody;
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
#endif
        public GameObject GameObject { get => gameObject; }
        public Transform Transform { get => transform; }

        public void SetPlayerBodyPartRigidbody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
        private void FixedUpdate()
        {
            if (_attractorPlanet)
                _attractorPlanet.Attract(transform);
        }

        #region Setters

        public void SetAttractorPlanet(Planet planet)
        {
            _attractorPlanet = planet;
        }


        #endregion
    }
}
