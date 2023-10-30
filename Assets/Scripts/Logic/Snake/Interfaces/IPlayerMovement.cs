using UnityEngine;

namespace Logic.Snake.Interfaces
{
    public interface IPlayerMovement
    {
        void MovePlayer(Rigidbody rigidbody,Transform transform, float moveSpeed);
        void Look(Transform transform, Vector3 moveVector, float rotationSpeed);

    }
}