using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputActions inputActions;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputActions();

            inputActions.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

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


    }
}
