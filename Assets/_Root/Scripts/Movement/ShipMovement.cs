using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CultureFMP.Movement
{
    public class ShipMovement : MonoBehaviour
    {
        public float shipSpeed = 2;
        public bool isMoving;

        private Quaternion _shipSway;

        float xTilt = 5f;
        float zTilt = 10f;

        private void Start()
        {
            //_shipSway = transform.rotation;
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position += Vector3.forward * shipSpeed * Time.deltaTime;
            }



            transform.eulerAngles = new Vector3(Mathf.Sin(Time.time * xTilt) * 10.0f, transform.eulerAngles.y, Mathf.Sin(Time.time * zTilt) * 10.0f);

            /*if (transform.rotation == _shipSway)
            {
                RandomSway();
            }*/

            //transform.rotation = Quaternion.Lerp(transform.rotation, _shipSway, Time.deltaTime * 0.1f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, shipSway, Time.deltaTime * 0.1f);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, shipSway, Time.deltaTime);
            //transform.Rotate(_shipSway.x, _shipSway.y, _shipSway.z, Space.Self);
            //transform.localRotation = Quaternion.Lerp(transform.rotation, _shipSway, Time.deltaTime * 0.1f);

           /*if (Input.GetKeyDown("j"))
           {
               //_shipSway.Set(5.0f, 0f, 5.0f, 0);
               RandomSway();
           }*/


        }

        private void RandomSway()
        {
            /*_shipSway.Set(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f), 0);
            Debug.Log($"{_shipSway.x} {_shipSway.y} {_shipSway.z}");*/
            //transform.Rotate(_shipSway.x, _shipSway.y, _shipSway.z, Space.Self);
        }
    }
}