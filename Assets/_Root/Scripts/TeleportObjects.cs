using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CultureFMP
{
    public class TeleportObjects : MonoBehaviour
    {
        [FormerlySerializedAs("moveLocation")] public Transform objectToMove;
        public void MoveObjects()
        {
            objectToMove.position = transform.position;
            objectToMove.rotation = transform.rotation;
        }
    }
}
