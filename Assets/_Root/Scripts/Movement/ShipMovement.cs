using System;
using UnityEngine;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public Vector3 direction;
        public float duration;
        public bool isContinues;

        private Vector3 _position;

        private void Awake()
        {
            _position = transform.position;
        }

        private void Update()
        {
            _position += direction;
            //MoveSideways(direction, duration, isContinues);
        }

        // private void MoveSideways(Vector3 direction, float duration, bool isContinues)
        // {
        //     if (isContinues) return;
        //     Vector3 newPosition = _position + direction;
        //
        //     _position = Vector3.MoveTowards(_position, newPosition, duration * Time.deltaTime);
        // }
    }
}
