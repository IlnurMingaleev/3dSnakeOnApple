using Infrustructure.MVC;
using UnityEngine;
namespace Logic.Snake.Views
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : View, IPlayerView
    {
        [SerializeField] SnakeBodyParent _prefabsParent;
        [SerializeField] public GravityPhysics.Planet _attractorPlanet;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _playerMesh;
        public SnakeBodyParent PrefabsParent
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

#if UNITY_EDITOR
        private void OnValidate()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
        }
#endif
       
        public void InitPlayer(GravityPhysics.Planet planet, SnakeBodyParent parent)
        {
            _attractorPlanet = planet;
            _prefabsParent = parent;
        }

        public Transform PlayerMesh { get => _playerMesh; }

        private void FixedUpdate()
        {
            if (_attractorPlanet)
                _attractorPlanet.Attract(transform);
        }

        
        
    }
}
