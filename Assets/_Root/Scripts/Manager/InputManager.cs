using CultureFMP.Input;
using CultureFMP.Movement;
using UnityEngine;

namespace CultureFMP.Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputActions _inputActions;
        private CharacterLocomotion _characterLocomotion;

        [Header("Debugging Stats")]
        [SerializeField] private Vector2 movementInput;
        [SerializeField] private Vector2 cameraInput;
        [SerializeField] private bool jumpInput;

        public float cameraInputX;
        public float cameraInputY;
        public float verticalInput;
        public float horizontalInput;

        private void Awake()
        {
            _characterLocomotion = GetComponent<CharacterLocomotion>();    
        }

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new InputActions();

                _inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                _inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

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
            HandleJumpInput();
        }

        private void HandleMovementInput()
        {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;

            cameraInputY = cameraInput.y;
            cameraInputX = cameraInput.x;
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