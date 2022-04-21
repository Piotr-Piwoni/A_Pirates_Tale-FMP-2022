using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutlass : MonoBehaviour
{
    private Collider _myCol;

    private void Start()
    {
        _myCol = gameObject.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Here the animation for the cutlass swing will go
            // Once the animation is implemted I will also toggle the collider on during the animation and off after it to avoid any collsion problems using Collider.enable
        }

        if (Input.GetMouseButton(1))
        {
            //Here the animation for blocking with the cutlass will go
            //While the player is using the cutlass block, I will stop it from taking damage
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
