using UnityEngine;

namespace Logic.Snake.Views
{
    public interface IPlayerBodyPartView
    {
        public Transform Transform { get; }
        void SetPlayerBodyPartRigidbody(Rigidbody rigidbody);
        Rigidbody Rigidbody { get; }
    }
}