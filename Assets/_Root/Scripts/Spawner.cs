using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP
{
    public class Spawner : MonoBehaviour
    {
        public GameObject spawnObject;
        public bool isSpawning;
        public int amountToSpawn;

        [SerializeField] private int spawnedObjects;

        private void Update()
        {
            while (spawnedObjects != amountToSpawn && isSpawning)
            {
                Instantiate(spawnObject, transform.position, Quaternion.identity);
                spawnedObjects++;
            }
        }
    }
}
