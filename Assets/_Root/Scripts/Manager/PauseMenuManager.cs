using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace CultureFMP.Manager
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseButtons;
        [SerializeField] private GameObject _optionsButtons;

        public VideoPlayer videoPlayer;
        public AudioSource cutSceneAudio;
        public KeyCode pauseKey;
        public bool isPaused;

        void Update()
        {
            if (Input.GetKeyDown(pauseKey) && !isPaused)
            {
                _pauseButtons.SetActive(true);
                Time.timeScale = 0f;
                videoPlayer.Pause();
                cutSceneAudio.Pause();
                Cursor.lockState = CursorLockMode.None;
                isPaused = true;
            }
        }

        public void ReturnButton()
        {
            _pauseButtons.SetActive(false);
            Time.timeScale = 1.0f;
            videoPlayer.Play();
            cutSceneAudio.UnPause();
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }

        public void ReturnButton2()
        {
            _pauseButtons.SetActive(true);
            _optionsButtons.SetActive(false);
        }

        public void OptionsButton()
        {
            _pauseButtons.SetActive(false);
            _optionsButtons.SetActive(true);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
