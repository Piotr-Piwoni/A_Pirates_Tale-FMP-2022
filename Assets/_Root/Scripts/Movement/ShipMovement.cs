using UnityEngine;
using Random = UnityEngine.Random;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public float shipSpeed = 2;
        public bool isMoving;

        [Header ("Sway Settings")]

        [SerializeField] [Tooltip ("This changes how fast it tilts on the x Axis")] private float xTilt = 0.5f;
        [SerializeField] [Tooltip ("This changes how fast it tilts on the z Axis")] private float zTilt = 1.0f;
        [SerializeField] [Tooltip ("This changes how far it sways")] private float sway = 3.0f;

        private void Update()
        {
            if (isMoving)
            {
                transform.position += Vector3.forward * shipSpeed * Time.deltaTime;
            }

            transform.eulerAngles = new Vector3(Mathf.Sin(Time.time * xTilt) * sway, transform.eulerAngles.y, Mathf.Sin(Time.time * zTilt) * sway);
        }
    }
}