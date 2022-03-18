using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutlass : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Here the animation for the cutlass swing will go
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
