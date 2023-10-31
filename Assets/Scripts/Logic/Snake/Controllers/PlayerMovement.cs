using UnityEngine;

namespace Logic.Snake.Controllers
{
    public class PlayerMovement : Interfaces.IPlayerMovement
    {
        
        
        
    
        public void MovePlayer(Rigidbody rigidbody, Transform playerMesh, float moveSpeed)
        {
            rigidbody.MovePosition(rigidbody.position + playerMesh.forward * (moveSpeed * Time.fixedDeltaTime));

        }
    }
}