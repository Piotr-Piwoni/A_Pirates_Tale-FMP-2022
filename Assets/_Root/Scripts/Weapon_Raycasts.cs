using UnityEngine;

public class Weapon_Raycasts : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main; // Gets the camera that has the main camera tag
    }

/*    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); // Starts the private method that is named Shoot
        }
    }*/

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)) // Shoots out a raycast that gathers information on what it hits
        {
            Debug.Log(hit.transform.name); // This will show the name of the object that the raycast hits in the console
        }
    }
}