using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using CultureFMP.Manager;

namespace CultureFMP
{
    public class CutsceneSettings : MonoBehaviour
    {
        private VideoPlayer _videoPlayer;
        public PlayerManager playerManager;

        public double reduceClipTime;

        private void Awake()
        {
            _videoPlayer = GetComponent<VideoPlayer>();
            playerManager.inCutscene = true;
        }


        private void Update()
        {
            double length = _videoPlayer.clip.length - reduceClipTime;

            if (_videoPlayer.time >= length)
            {
                _videoPlayer.Stop();
                _videoPlayer.enabled = false;
                playerManager.inCutscene = false;
            }

        }
    }
}
