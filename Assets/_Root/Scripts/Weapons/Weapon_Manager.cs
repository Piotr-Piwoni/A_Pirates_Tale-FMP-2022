using CultureFMP.Manager;
using UnityEngine;

namespace CultureFMP
{
    public class Weapon_Manager : MonoBehaviour
    {
        private int _weaponSelect = 0;

        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private GameObject targetADS;

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                cameraManager.targetTransform = targetADS.transform;
                transform.rotation = cameraManager.camTransform.rotation;
                cameraManager.cameraFollowSpeed = 0.2f;
            }
            else
            {
                cameraManager.cameraFollowSpeed = 0.2f;
                cameraManager.targetTransform = gameObject.transform;
            }

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("up");
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
