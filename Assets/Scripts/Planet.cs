using UnityEngine;

namespace DefaultNamespace
{
    public class Planet : MonoBehaviour
    {
        private const float F = 50f;
        public float gravity = -9.98f;

        public void Attract(Transform playerTransform)
        {
            Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
            Vector3 localUp = playerTransform.up;
            
            playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,targetRotation,F*Time.deltaTime);

        }
    }
}