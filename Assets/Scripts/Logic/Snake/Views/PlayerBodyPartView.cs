using UnityEngine;

namespace Logic.Snake.Views
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerBodyPartView : MonoBehaviour,IPlayerBodyPartView
    {
        [SerializeField] private Rigidbody _rigidbody;
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
        public Transform Transform { get => transform; }

        public void SetPlayerBodyPartRigidbody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
    }
}
