using UnityEngine;

namespace Logic.Snake
{
    public class PlayerMovement : IPlayerMovement
    {
        public void Look(Transform transform,Vector3 moveVector, float rotationSpeed)
        {
            if (moveVector != Vector3.zero)
            {
                var relative = (transform.position + moveVector) - transform.position;
                var rotation = Quaternion.LookRotation(relative, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
        
    
        public void MovePlayer(Rigidbody rigidbody, Transform transform, float moveSpeed)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * (moveSpeed * Time.fixedDeltaTime));

        }
    }
}