using System;
using UnityEngine;

namespace CultureFMP.Manager
{
    public class AnimatorManager : MonoBehaviour
    {
        private Animator _animator;
        private int _horizontal;
        private int _vertical;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _horizontal = Animator.StringToHash("Horizontal");
            _vertical = Animator.StringToHash("Vertical");
        }

        public void UpdateAnimatorValues(float _horizontalMovement, float _verticalMovement)
        {
            float _snappedHorizontal;
            float _snappedVertical;

            #region Snapped Horizontal

                if (_horizontalMovement > 0 && _horizontalMovement < 0.55f)
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
            
            _animator.SetFloat(_horizontal, _snappedHorizontal, 0.1f, Time.deltaTime);
            _animator.SetFloat(_vertical, _snappedVertical, 0.1f, Time.deltaTime);
        }
    }
}
