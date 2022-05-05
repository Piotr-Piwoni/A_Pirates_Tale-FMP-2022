using UnityEngine;
using CultureFMP.Movement;

namespace CultureFMP.Manager
{
    [RequireComponent(typeof(InputManager), typeof(CharacterLocomotion))]
    public class PlayerManager : MonoBehaviour
    {
        private Animator _animator;
        private InputManager _inputManager;
        private CharacterLocomotion _characterLocomotion;
        private CameraManager _cameraManager;

        public bool isInteracting;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
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

            isInteracting = _animator.GetBool("isInteracting");
            _characterLocomotion.isJumping = _animator.GetBool("isJumping");
            _animator.SetBool("isGrounded", _characterLocomotion.isGrounded);
        }
    }
}