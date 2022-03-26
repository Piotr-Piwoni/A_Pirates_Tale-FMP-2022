using UnityEngine;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public float shipSpeed = 2;
        public bool isMoving;


        private void Update()
        {
            if (isMoving)
            {
                transform.position += Vector3.forward * shipSpeed * Time.deltaTime;
            }            
        }

    }
}
