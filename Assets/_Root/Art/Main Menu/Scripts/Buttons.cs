using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CultureFMP
{
    public class Buttons : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("Treasure Island");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
