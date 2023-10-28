using System;
using UnityEngine;
using VContainer.Unity;

namespace Logic.Snake
{
    public class PlayerBodyPart : MonoBehaviour
    {
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
    }
}
