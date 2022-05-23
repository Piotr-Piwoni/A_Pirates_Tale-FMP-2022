using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CultureFMP.Manager
{
    public class AnimatorManager : MonoBehaviour
    {
        [HideInInspector]
        public Animator animator;
        public PlayerManager playerManager;
        
        private int _horizontal;
        private int _vertical;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            _horizontal = Animator.StringToHash("Horizontal");
            _vertical = Animator.StringToHash("Vertical");
        }

        public void PlayTargetAnimation(string _targetAnimation, bool _isInteracting)
        {
            animator.SetBool("isInteracting", _isInteracting);
            animator.CrossFade(_targetAnimation, 0.2f);
        }

        public void PlayAnimationInDialogue(Animator _animator , bool _inDialogue)
        {
            _animator.SetBool("InDialogue", _inDialogue);
        }

        public void UpdateAnimatorValues(float _horizontalMovement, float _verticalMovement, bool _isSprinting)
        {
            float _snappedHorizontal;
            float _snappedVertical;

            #region Snapped Horizontal

                if (playerManager.inDialogue)
                    return;
                
                if (_horizontalMovement > 0 && _horizontalMovement < 0.55f )
                {
                    _snappedHorizontal = 0.5f;
                } else if (_horizontalMovement > 0.55f)
                {
                    _snappedHorizontal = 1;
                } else if (_horizontalMovement < 0 && _horizontalMovement > -0.55f)
                {
                    _snappedHorizontal = -0.5f;
                } else if (_horizontalMovement < -0.55f)
                {
                    _snappedHorizontal = -1;
                } else
                {
                    _snappedHorizontal = 0;
                }

            #endregion
            #region Snapped Vertical
                
                if (playerManager.inDialogue)
                    return;
                
                if (_verticalMovement > 0 && _verticalMovement < 0.55f)
                {
                    _snappedVertical = 0.5f;
                } else if (_verticalMovement > 0.55f)
                {
                    _snappedVertical = 1;
                } else if (_verticalMovement < 0 && _verticalMovement > -0.55f)
                {
                    _snappedVertical = -0.5f;
                } else if (_verticalMovement < -0.55f)
                {
                    _snappedVertical = -1;
                } else
                {
                    _snappedVertical = 0;
                }

            #endregion

            if (_isSprinting && !playerManager.inDialogue)
            {
                _snappedHorizontal = _horizontalMovement;
                _snappedVertical = 2;
            }
            
            animator.SetFloat(_horizontal, _snappedHorizontal, 0.1f, Time.deltaTime);
            animator.SetFloat(_vertical, _snappedVertical, 0.1f, Time.deltaTime);
        }
    }
}
