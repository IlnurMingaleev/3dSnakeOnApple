using UnityEngine;

namespace Snake
{
    public class PlayerBodyPart : MonoBehaviour
    {
        public Rigidbody _rigidbody;

        private void Awake()
        {
            if (!_rigidbody) _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
