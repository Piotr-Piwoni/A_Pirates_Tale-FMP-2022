using UnityEngine;
using CultureFMP.Movement;

namespace CultureFMP.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        private InputManager _inputManager;
        private CharacterLocomotion _characterLocomotion;
        private CameraManager _cameraManager;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _characterLocomotion = GetComponent<CharacterLocomotion>();
            _cameraManager = FindObjectOfType<CameraManager>();
        }

        private void Update()
        {
            _inputManager.HandleAllInputs();
        }

        private void FixedUpdate()
        {
            _characterLocomotion.HandleAllMovement();    
        }

        private void LateUpdate()
        {
            _cameraManager.HandleAllCameraMovement();
        }
    }
}