using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Raycasts : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main; // Gets the camera that has the main camera tag
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); // Starts the private method that is named Shoot
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)) // Shoots out a raycast that gathers information on what it hits
        {
            Debug.Log("pew");
        }
    }

}