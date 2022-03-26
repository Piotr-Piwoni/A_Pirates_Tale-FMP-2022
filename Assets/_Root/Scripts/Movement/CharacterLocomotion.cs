using UnityEngine;
using CultureFMP.Manager;

namespace CultureFMP.Movement
{
    public class CharacterLocomotion : MonoBehaviour
    {
        #region Variables
        private InputManager _inputManager;
        private Rigidbody _characterRb;
        private Transform _cameraObject;
        private Transform _groundChecker;
        private Vector3 _moveDir;

        public float movementSpeed = 7;
        public float rotationSpeed = 15;
        public bool isGrounded;
        public bool isJumping;
        public float gravityIntensity = 15;
        public float jumpHeight= 3;
        public float inAirTimer;
        public float leapingVelocity;
        public float fallingVelocity;
        public float rayCastHeightOffset;
        public float rayCastRadius = 0.2f;
        public LayerMask groundLayer;
        #endregion

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _characterRb = GetComponent<Rigidbody>();
            if (Camera.main != null) _cameraObject = Camera.main.transform;
            _groundChecker = transform.Find("Ground Checker");
        }

        public void HandleAllMovement()
        {
            HandleFallingAndLanding();
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
            _characterRb.velocity = new Vector3(_movementVelocity.x, _characterRb.velocity.y, _movementVelocity.z);
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

        private void HandleFallingAndLanding()
        {
            RaycastHit _hit;
            Vector3 _rayCastOrigin = transform.position;
            _rayCastOrigin.y += rayCastHeightOffset;

            if (!isGrounded && !isJumping)
            {
                inAirTimer += Time.deltaTime;
                _characterRb.AddForce(transform.forward * leapingVelocity);
                _characterRb.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
            }

            if (Physics.SphereCast(_groundChecker.position, rayCastRadius, -Vector3.up, out _hit, groundLayer))
            { 
                inAirTimer = 0f;
                isGrounded = true;
            } else
            {
                isGrounded = false;
            }
        }

        public void HandleJumping()
        {
            if (isGrounded)
            {
                float _jumpingVelocity = Mathf.Sqrt(2 * gravityIntensity * jumpHeight);
                Vector3 _playerVelocity = _moveDir;
                _playerVelocity.y = _jumpingVelocity;
                _characterRb.velocity = _playerVelocity;
            }
        }
    }
}