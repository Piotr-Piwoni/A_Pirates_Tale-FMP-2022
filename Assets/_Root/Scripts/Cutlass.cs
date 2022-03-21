using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutlass : MonoBehaviour
{
    Collider myCol;

    private void Start()
    {
        myCol = gameObject.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Here the animation for the cutlass swing will go
            // Once the animation is implemted I will also toggle the collider on during the animation and off after it to avoid any collsion problems using Collider.enable
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
        }
    }
}
