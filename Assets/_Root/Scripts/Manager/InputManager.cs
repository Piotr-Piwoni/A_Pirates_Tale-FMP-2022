using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputActions inputActions;
    private float moveAmount;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputActions();

            inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void HundalAllInputs()
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
