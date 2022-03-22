using UnityEngine;
using UnityEngine.Serialization;

namespace CultureFMP.Manager
{
    public class CameraManager : MonoBehaviour
    {
        #region
        private InputManager _inputManager;
        private Transform _transform;
        private Vector3 _followVelocity = Vector3.zero;
        private Vector3 _vectorPosition;
        private float _defaultPosition;
        private float _lookAngle;
        private float _pivotAngle;

        [Header("Object Refrancecs")]
        public Transform targetTransform;
        public Transform cameraPivot;

        [Header("Camera Settings")]
        public float cameraFollowSpeed = 0.2f;
        [Tooltip("Controlls the Right and Left look speed.")]
        public float cameraLookSpeed = 2;
        [Tooltip("Controlls the Up and Down look speed.")]
        public float cameraPivotSpeed = 2;
        public float minimumPivotAngle = -35;
        public float maximumPivotAngle = 35;

        [Space(5)]
        [SerializeField] private bool hideMouseCursor;

        [Header("Camera Collision")]
        public LayerMask collisionLayers;
        public float cameraCollisionRadius = 2;
        public float cameraCollisionOffset = 0.2f;
        [Tooltip("How close it need to be to the wall to offset.")]
        public float minimumCollisionOffset = 0.2f;
        #endregion

        private void Awake()
        {
            targetTransform = FindObjectOfType<PlayerManager>().transform;
            _inputManager = FindObjectOfType<InputManager>();
            if (Camera.main != null) _transform = Camera.main.transform;
            _defaultPosition = _transform.localPosition.z;
            if (hideMouseCursor)
                Cursor.lockState = CursorLockMode.Locked;
        }

        public void HandleAllCameraMovement()
        {
            FollowTarget();
            RotateCamera();
            HandleCameraCollision();
        }

        private void FollowTarget()
        {
            Vector3 _targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref _followVelocity, cameraFollowSpeed);

            transform.position = _targetPosition;
        }

        private void RotateCamera()
        {
            Vector3 _rotation;
            Quaternion _targetRotation;

            _lookAngle += (_inputManager.cameraInputX * cameraLookSpeed);
           _pivotAngle += (_inputManager.cameraInputY * cameraPivotSpeed);
            _pivotAngle = Mathf.Clamp(_pivotAngle, minimumPivotAngle, maximumPivotAngle);

            _rotation = Vector3.zero;
            _rotation.y = _lookAngle;
            _targetRotation = Quaternion.Euler(_rotation);
            transform.rotation = _targetRotation;

            _rotation = Vector3.zero;
            _rotation.x = _pivotAngle;
            _targetRotation = Quaternion.Euler(_rotation);
            cameraPivot.localRotation = _targetRotation;
        }

        private void HandleCameraCollision()
        {
            float _targetPosition = _defaultPosition;
            RaycastHit _hit;

            Vector3 _direction = _transform.position - cameraPivot.position;
            _direction.Normalize();

            if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, _direction, out _hit, Mathf.Abs(_targetPosition), collisionLayers))
            {
                float _distance = Vector3.Distance(cameraPivot.position, _hit.point);
                _targetPosition -= (_distance - cameraCollisionOffset);
            }

            if (Mathf.Abs(_targetPosition) < minimumCollisionOffset)
            {
                _targetPosition -= minimumCollisionOffset;
            }

            _vectorPosition.z = Mathf.Lerp(_transform.localPosition.z, _targetPosition, 0.2f);
            _transform.localPosition = _vectorPosition;
        }
    }
}
