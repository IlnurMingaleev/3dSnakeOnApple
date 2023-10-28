using UnityEngine;

namespace Logic.Planet
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityBody : MonoBehaviour
    {
        [SerializeField] public Planet attractorPlanet;
        //private Transform playerTransform;
        
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody rigidbody
        {
            get => _rigidbody;
            set => _rigidbody = value;
        }
#if UNITY_EDITOR
        private void OnValidate()
        {
            if(!gameObject.activeInHierarchy)
                return;

            rigidbody = _rigidbody;
        }
#endif
        private void Awake()
        {
            attractorPlanet = FindObjectOfType<Planet>();
            _rigidbody = GetComponent<Rigidbody>();
            rigidbody = _rigidbody;
        }

        private void Start()
        {
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void FixedUpdate()
        {
            if (attractorPlanet)
                attractorPlanet.Attract(transform);
        }
    }
}