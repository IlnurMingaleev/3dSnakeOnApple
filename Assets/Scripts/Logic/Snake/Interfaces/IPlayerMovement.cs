using UnityEngine;

namespace Logic.Snake.Interfaces
{
    public interface IPlayerMovement
    {
        void MovePlayer(Rigidbody rigidbody,Transform transform, float moveSpeed);

    }
}