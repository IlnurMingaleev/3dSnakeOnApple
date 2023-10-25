using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Inspector Variables
    [SerializeField, Tooltip("Transform of the player to follow")]
    private Transform targetToFollow;

    [SerializeField, Tooltip("Offset of the camera from the player's position (ignores x-axis)")]
    private Vector3 cameraOffsetFromPlayer = new Vector3(0, 30, 0);

    [SerializeField]
    private bool shouldLookAtPlayer = true;

// Private Variables
    private Transform mainCameraTransform;

    private void Start()
    {
        if (!targetToFollow)
        {
            Debug.LogError("CameraMovement: Player transform reference is missing.");
        }
        else
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        if (!targetToFollow)
        {
            return;
        }

        // Calculate the camera's position relative to the player
        Vector3 desiredCameraPosition = targetToFollow.position - (targetToFollow.forward * cameraOffsetFromPlayer.z) + (targetToFollow.up * cameraOffsetFromPlayer.y);

        transform.position = desiredCameraPosition;

        // Adjust camera orientation
        if (shouldLookAtPlayer)
        {
            // Make the camera look at the player while considering the player's up direction
            mainCameraTransform.LookAt(targetToFollow, targetToFollow.up);
        }
        else
        {
            // Direct the camera to look at the player without considering the up direction
            mainCameraTransform.LookAt(targetToFollow);
        }
    }
}
