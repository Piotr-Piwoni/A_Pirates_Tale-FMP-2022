using CultureFMP.Manager;
using UnityEngine;

namespace CultureFMP
{
    public class Weapon_Manager : MonoBehaviour
    {
        private int _weaponSelect = 0;

        [SerializeField] GameObject cameraManager;
        CameraManager camManager;
        public GameObject endPos;
        

        void Start()
        {
            camManager = cameraManager.GetComponent<CameraManager>();
        }

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                camManager.isAiming = true;
                camManager.camTransform.position = Vector3.Lerp(camManager.camTransform.position, endPos.transform.position, Time.deltaTime);
                transform.rotation = camManager.camTransform.rotation;
            }
            else
            {
                camManager.isAiming = false;
            }

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
            
        }

        private void PistolUpdate()
        {
            
        }

        private void MusketUpdate()
        {
            
        }
    }
}
