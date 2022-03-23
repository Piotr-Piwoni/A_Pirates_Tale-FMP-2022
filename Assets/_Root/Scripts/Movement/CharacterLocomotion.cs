using UnityEngine;
using CultureFMP.Manager;
using System;

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
        public bool isGrounded;
        public bool isJumping;
        public float gravityIntensity = 15;
        public float jumpHeight= 3;

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
            if (isJumping)
                return;

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

        internal void HandleJumping()
        {
            if (isGrounded)
            {
                float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
                Vector3 playerVelocity = _moveDir;
                playerVelocity.y = jumpingVelocity;
                _characterRb.velocity = playerVelocity;
            }
        }
    }
}