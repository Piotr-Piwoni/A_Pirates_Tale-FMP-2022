using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace CultureFMP
{
    public class TutoralPromt : MonoBehaviour
    {
        public VideoPlayer cutScene;
        public GameObject tutoralPromt;
        public float destroyAfter = 10f;

        private void Update()
        {
            if (cutScene.enabled == false)
            {
                tutoralPromt.SetActive(true);
                Destroy(tutoralPromt, destroyAfter);
                Destroy(this, destroyAfter);
            }
        }
    }
}
