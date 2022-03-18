using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    CharacterLocomotion characterLocomotion;
    CameraManager cameraManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        characterLocomotion = GetComponent<CharacterLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    private void Update()
    {
        inputManager.HundalAllInputs();
    }

    private void FixedUpdate()
    {
        characterLocomotion.HandleAllMovement();    
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
