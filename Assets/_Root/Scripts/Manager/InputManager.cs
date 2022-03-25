using CultureFMP.InputA;
using UnityEngine;

namespace CultureFMP.Manager
{
    public class InputManager : MonoBehaviour
    {
        private InputActions _inputActions;

        [Header("Debuging Staff")]
        [SerializeField] private Vector2 movementInput;
        [SerializeField] private Vector2 cameraInput;

        public float cameraInputX;
        public float cameraInputY;
        public float verticalInput;
        public float horizontalInput;

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new InputActions();

                _inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
                _inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
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
        }

        private void HandleMovementInput()
        {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;

            cameraInputY = cameraInput.y;
            cameraInputX = cameraInput.x;
        }
    }
}