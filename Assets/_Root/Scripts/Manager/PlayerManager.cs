using UnityEngine;
using CultureFMP.Movement;
using VIDE_Data;

namespace CultureFMP.Manager
{
    [RequireComponent(typeof(InputManager), typeof(CharacterLocomotion))]
    public class PlayerManager : MonoBehaviour
    {
        private Animator _animator;
        private InputManager _inputManager;
        private CharacterLocomotion _characterLocomotion;
        private CameraManager _cameraManager;
        
        public UIManager uiManager;
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
            
            if (Input.GetKeyDown(KeyCode.E) && !VD.isActive)
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            isInteracting = true;
            
            RaycastHit rHit;

            if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
            {
                VIDE_Assign assigned;
                if (rHit.collider.GetComponent<VIDE_Assign>() != null)
                    assigned = rHit.collider.GetComponent<VIDE_Assign>();
                else return;

                uiManager.Begin(assigned); 
            }
            else
            {
                isInteracting = false;
            }
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