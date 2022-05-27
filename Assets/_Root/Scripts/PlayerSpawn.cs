using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CultureFMP.Manager;

namespace CultureFMP
{
    public class PlayerSpawn : MonoBehaviour
    {
        public Transform playerSpawn;
        public ScenesManager ScenesManager;

        public bool sceneReset;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (sceneReset)
                    ScenesManager.LoadGame();

                other.transform.position = playerSpawn.position;
            }
        }
    }
}
