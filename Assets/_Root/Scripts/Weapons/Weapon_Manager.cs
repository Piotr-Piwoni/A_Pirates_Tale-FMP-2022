using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP
{
    public class Weapon_Manager : MonoBehaviour
    {
        private int _weaponSelect = 1;

        void Start()
        {
        
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _weaponSelect = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _weaponSelect = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _weaponSelect = 3;
            }

            if (_weaponSelect == 1)
            {
                CutlassUpdate();
            }
            else if (_weaponSelect == 2)
            {
                PistolUpdate();
            }
            else if (_weaponSelect == 3)
            {
                MusketUpdate();
            }
        }

        private void CutlassUpdate()
        {
            Debug.Log("I have a cutlass");
        }

        private void PistolUpdate()
        {
            Debug.Log("I have a pistol");
        }

        private void MusketUpdate()
        {
            Debug.Log("I have a musket");
        }
    }
}
