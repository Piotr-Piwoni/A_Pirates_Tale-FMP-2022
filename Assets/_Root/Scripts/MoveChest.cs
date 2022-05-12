using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP
{
    public class MoveChest : MonoBehaviour
    {
        public void TeleportChest()
        {
            transform.position = new Vector3(transform.position.x, -6.13f, transform.position.z);
        }
    }
}
