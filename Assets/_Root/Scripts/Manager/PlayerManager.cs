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
        public Animator npcAnimator = null;
        private InputManager _inputManager;
        private CharacterLocomotion _characterLocomotion;
        private CameraManager _cameraManager;
        private AnimatorManager _animatorManager;
        [SerializeField] private VIDE_Assign _currentDialogue;
        
        public DialogueManager dialogueManager;
        public bool isInteracting;
        public bool inDialogue;
        public bool inCutscene;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputManager = GetComponent<InputManager>();
            _characterLocomotion = GetComponent<CharacterLocomotion>();
            _cameraManager = FindObjectOfType<CameraManager>();
            _animatorManager = GetComponent<AnimatorManager>();
            npcAnimator = _animator;
        }

        private void Update()
        {
            _inputManager.HandleAllInputs();

            if (npcAnimator == null)
                npcAnimator = _animator;

            if (VD.isActive)
            {
                inDialogue = true;
                _animatorManager.PlayAnimationInDialogue(npcAnimator, inDialogue);
            }
            else
            {
                inDialogue = false;
                _animatorManager.PlayAnimationInDialogue(npcAnimator, inDialogue);
            }
            
            if (Input.GetKeyDown(KeyCode.E))
                TryInteract();
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
                _currentDialogue = _other.GetComponent<VIDE_Assign>();
            
            if (_other.GetComponent<Animator>() != null)
                npcAnimator = _other.GetComponent<Animator>();
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