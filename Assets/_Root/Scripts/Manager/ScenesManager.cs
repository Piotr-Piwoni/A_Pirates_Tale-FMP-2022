using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CultureFMP
{
    public class ScenesManager : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
        public void LoadEndScene()
        {
            SceneManager.LoadScene("End");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}
