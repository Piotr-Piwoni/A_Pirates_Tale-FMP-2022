using UnityEngine;
using CultureFMP.Manager;

namespace CultureFMP.Movement
{
    public class CharacterLocomotion : MonoBehaviour
    {
        private InputManager _inputManager;

        private Vector3 _moveDir;
        private Transform _cameraObject;
        private Rigidbody _characterRb;

        public float movementSpeed = 7;
        public float rotationSpeed = 15;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _characterRb = GetComponent<Rigidbody>();
            if (Camera.main != null) _cameraObject = Camera.main.transform;
        }

        public void HandleAllMovement()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            _moveDir = _cameraObject.forward * _inputManager.verticalInput;
            _moveDir += _cameraObject.right * _inputManager.horizontalInput;
            _moveDir.Normalize();
            _moveDir.y = 0;
            _moveDir *= movementSpeed;

            Vector3 _movementVelocity = _moveDir;
            _characterRb.velocity = _movementVelocity;
        }

        private void HandleRotation()
        {
            Vector3 _targetDir = Vector3.zero;

            _targetDir = _cameraObject.forward * _inputManager.verticalInput;
            _targetDir += _cameraObject.right * _inputManager.horizontalInput;
            _targetDir.Normalize();
            _targetDir.y = 0;

            if (_targetDir == Vector3.zero)
                _targetDir = transform.forward;

            Quaternion _targetRotation = Quaternion.LookRotation(_targetDir);
            Quaternion _characterRotation = Quaternion.Slerp(transform.rotation, _targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = _characterRotation;
        }
    }
}