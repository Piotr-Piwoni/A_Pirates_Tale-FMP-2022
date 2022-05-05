using CultureFMP.Manager;
using UnityEngine;

namespace CultureFMP.Movement
{
    public class CharacterLocomotion : MonoBehaviour
    {
        #region Variables
        private InputManager _inputManager;
        private PlayerManager _playerManager;
        private AnimatorManager _animatorManager;
        private Rigidbody _characterRb;
        private Transform _cameraObject;
        private Transform _groundChecker;
        private Vector3 _moveDir;

        [Header("Movement Speeds")]
        public float walkingSpeed = 15;
        public float runningSpeed = 22;
        public float sprintingSpeed = 28;
        public float rotationSpeed = 7;
        [Header("Movement Flags")]
        public bool isSprinting;
        public bool isGrounded = true;
        public bool isJumping;
        [Header("Jump Settings")]
        public float gravityIntensity = 20;
        public float jumpHeight= 9;
        [HideInInspector]
        public float inAirTimer;
        public float leapingVelocity = 20;
        public float fallingVelocity = 500;
        [Header("Ground Checker Settings")]
        public float rayCastHeightOffset;
        public float rayCastRadius = 0.2f;
        public LayerMask groundLayer;
        #endregion

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _playerManager = GetComponent<PlayerManager>();
            _animatorManager = GetComponent<AnimatorManager>();
            _characterRb = GetComponent<Rigidbody>();
            if (Camera.main != null) _cameraObject = Camera.main.transform;
            _groundChecker = transform.Find("Ground Checker");
        }

        public void HandleAllMovement()
        {
            HandleFallingAndLanding();
            
            if (_playerManager.isInteracting)
                return;
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            if (isJumping)
                return;
            
            _moveDir = _cameraObject.forward * _inputManager.verticalInput;
            _moveDir += _cameraObject.right * _inputManager.horizontalInput;
            _moveDir.Normalize();
            _moveDir.y = 0;
            if (isSprinting)
            {
                _moveDir *= sprintingSpeed;
            } else
            {
                if (_inputManager.moveAmount >= 0.55f)
                {
                    _moveDir *= runningSpeed;
                } else
                {
                    _moveDir *= walkingSpeed;
                }
            }

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
                if (!_playerManager.isInteracting)
                {
                    _animatorManager.PlayTargetAnimation("A_Falling", true);
                }
                
                inAirTimer += Time.deltaTime;
                _characterRb.AddForce(transform.forward * leapingVelocity);
                _characterRb.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
            }

            if (Physics.SphereCast(_groundChecker.position, rayCastRadius, -Vector3.up, out _hit, groundLayer))
            {
                if (!isGrounded && !_playerManager.isInteracting)
                {
                    _animatorManager.PlayTargetAnimation("A_Landing", true);
                }
                
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
                _animatorManager.animator.SetBool("isJumping", true);
                _animatorManager.PlayTargetAnimation("A_Jumping", false);
                float _jumpingVelocity = Mathf.Sqrt(2 * gravityIntensity * jumpHeight);
                Vector3 _playerVelocity = _moveDir;
                _playerVelocity.y = _jumpingVelocity;
                _characterRb.velocity = _playerVelocity;
            }
        }
    }
}
