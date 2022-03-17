using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDir;
    Transform cameraObject;
    Rigidbody characterRB;

    public float movementSpeed = 7;
    public float roationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        characterRB = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDir = cameraObject.forward * inputManager.verticalInput;
        moveDir += cameraObject.right * inputManager.horizontalInput;
        moveDir.Normalize();
        moveDir.y = 0;
        moveDir *= movementSpeed;

        Vector3 movementVelocity = moveDir;
        characterRB.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDir = Vector3.zero;

        targetDir = cameraObject.forward * inputManager.verticalInput;
        targetDir += cameraObject.right * inputManager.horizontalInput;
        targetDir.Normalize();
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
            targetDir = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDir);
        Quaternion characterRotation = Quaternion.Slerp(transform.rotation, targetRotation, roationSpeed * Time.deltaTime);

        transform.rotation = characterRotation;
    }
}
