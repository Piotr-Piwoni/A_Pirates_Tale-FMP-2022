using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public float shipSpeed = 2;
        public bool isMoving;

        private Quaternion shipSway;

        private void Start()
        {
            shipSway = transform.rotation;
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position += Vector3.forward * shipSpeed * Time.deltaTime;
            }

            if (transform.rotation == shipSway)
            {
                RandomSway();
            }

            //transform.rotation = Quaternion.Lerp(transform.rotation, shipSway, Time.deltaTime * 0.1f);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, shipSway, Time.deltaTime);
        }

        private void RandomSway()
        {
            shipSway.Set(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
            Debug.Log($"{shipSway.x} {shipSway.y} {shipSway.z}");
        }
    }
}