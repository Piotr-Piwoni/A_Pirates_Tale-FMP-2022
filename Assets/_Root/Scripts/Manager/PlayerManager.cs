using System;
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
        [SerializeField] private VIDE_Assign _currentDialogue;
        
        public DialogueManager dialogueManager;
        public bool isInteracting;
        public bool inDialogue;

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

            if (VD.isActive)
                inDialogue = true;
            else
            {
                inDialogue = false;
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
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

        private void OnTriggerEnter(Collider _other)
        {
            if (_other.GetComponent<VIDE_Assign>() != null)
            {
                _currentDialogue = _other.GetComponent<VIDE_Assign>();
            }
        }

        private void OnTriggerExit(Collider _other)
        {
            _currentDialogue = null;
        }
        
        void TryInteract()
        {
            if (_currentDialogue)
            {
                dialogueManager.Interact(_currentDialogue);
                return;
            }

            RaycastHit _rHit;

            if (Physics.Raycast(transform.position, transform.forward, out _rHit, 2))
            {
                VIDE_Assign _assigned;
                if (_rHit.collider.GetComponent<VIDE_Assign>() != null)
                    _assigned = _rHit.collider.GetComponent<VIDE_Assign>();
            }
        }
    }
}