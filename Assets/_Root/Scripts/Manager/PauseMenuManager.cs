using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _pauseButtons;
        [SerializeField] private GameObject _optionsButtons;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void ReturnButton()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
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
