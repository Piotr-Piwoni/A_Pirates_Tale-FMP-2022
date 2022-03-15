using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    CharacterLocomotion characterLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        characterLocomotion = GetComponent<CharacterLocomotion>();
    }

    private void Update()
    {
        inputManager.HundalAllInputs();
    }

    private void FixedUpdate()
    {
        characterLocomotion.HandleAllMovement();
        
    }
}
