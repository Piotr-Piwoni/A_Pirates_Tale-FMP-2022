using System;
using UnityEngine;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public float shipSpeed = 2;
        public bool isMoving;

        private Vector3 _shipPos;

        private void Awake()
        {
            _shipPos = transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
                _shipPos = Vector3.forward * 1000f; //* shipSpeed * Time.deltaTime
            }
        }

    }
}
