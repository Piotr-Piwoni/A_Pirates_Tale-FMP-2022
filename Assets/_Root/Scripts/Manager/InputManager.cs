using CultureFMP.InputA;
using CultureFMP.Movement;
using UnityEngine;

namespace CultureFMP.Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputActions _inputActions;
        private CharacterLocomotion _characterLocomotion;
        private AnimatorManager _animatorManager;

        [Header("Debugging Stats")]
        [SerializeField] private Vector2 movementInput;
        [SerializeField] private Vector2 cameraInput;
        [SerializeField] private bool sprintInput;
        [SerializeField] private bool jumpInput;

        public float horizontalInput;
        public float verticalInput;
        public float moveAmount;
        public float cameraInputX;
        public float cameraInputY;

        private void Awake()
        {
            _characterLocomotion = GetComponent<CharacterLocomotion>();
            _animatorManager = GetComponent<AnimatorManager>();
        }

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new InputActions();

                _inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                _inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

                _inputActions.PlayerActions.Sprint.performed += i => sprintInput = true;
                _inputActions.PlayerActions.Sprint.canceled += i => sprintInput = false;
                _inputActions.PlayerActions.Jump.performed += i => jumpInput = true;
            }

            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        public void HandleAllInputs()
        {
            HandleMovementInput();
            HandleSprintingInput();
            HandleJumpInput();
        }

        private void HandleMovementInput()
        {
            horizontalInput = movementInput.x;
            verticalInput = movementInput.y;

            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            _animatorManager.UpdateAnimatorValues(0,moveAmount, _characterLocomotion.isSprinting);
            
            cameraInputX = cameraInput.x;
            cameraInputY = cameraInput.y;
        }

        private void HandleSprintingInput()
        {
            if (sprintInput && moveAmount > 0.5f)
            {
                _characterLocomotion.isSprinting = true;
            } else
            {
                _characterLocomotion.isSprinting = false;
            }
        }
        
        private void HandleJumpInput()
        {
            if (jumpInput)
            {
                _characterLocomotion.HandleJumping();
                jumpInput = false;
            }
        }
    }
}