using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CultureFMP.Manager
{
    public class ScenesManager : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Main Menu");
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Treasure Island");
        }

        public void LoadEndScene()
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("End");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}
