using UnityEngine;

namespace Logic.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        
        [SerializeField] private Transform _following;
        [SerializeField] private Vector3 cameraOffsetFromTarget = new Vector3(0, 30, 0);
        [SerializeField] private bool _shouldLookAtPlayer = true;

        private Transform _mainCameraTransform;

        private void Start()
        {
            if (!_following)
            {
                Debug.LogError("CameraMovement: Player transform reference is missing.");
            }
            else
            {
                _mainCameraTransform = UnityEngine.Camera.main.transform;
            }
        }

        private void LateUpdate()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            if (!_following) return;
            Vector3 desiredCameraPosition = _following.position - (_following.forward * cameraOffsetFromTarget.z) + (_following.up * cameraOffsetFromTarget.y);
            transform.position = desiredCameraPosition;
            if (_shouldLookAtPlayer)
            {
                _mainCameraTransform.LookAt(_following, _following.up);
            }
            else
            {
                _mainCameraTransform.LookAt(_following);
            }
        }
        public void Follow(GameObject following)
        {
            _following = following.transform;
        }
        
    }
}
