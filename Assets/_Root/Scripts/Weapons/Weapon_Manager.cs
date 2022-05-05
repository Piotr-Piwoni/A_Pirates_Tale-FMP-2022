using CultureFMP.Manager;
using UnityEngine;

namespace CultureFMP
{
    public class Weapon_Manager : MonoBehaviour
    {
        private int _weaponSelect = 0;

        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private GameObject targetADS;

        /*        [SerializeField] private GameObject _cutlass;
                [SerializeField] private GameObject _pistol;
                [SerializeField] private GameObject _musket;*/

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                cameraManager.targetTransform = targetADS.transform;
                transform.rotation = cameraManager.camTransform.rotation;
                cameraManager.cameraFollowSpeed = 0.1f;
            }
            else
            {
                cameraManager.cameraFollowSpeed = 0.2f;
                cameraManager.targetTransform = gameObject.transform;
            }

        }

/*            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("up");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _weaponSelect = 1;
                _cutlass.SetActive(true);
                _pistol.SetActive(false);
                _musket.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _weaponSelect = 2;
                _cutlass.SetActive(false);
                _pistol.SetActive(true);
                _musket.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _weaponSelect = 3;
                _cutlass.SetActive(false);
                _pistol.SetActive(false);
                _musket.SetActive(true);
            }
            else if (Input.GetKeyDown("x"))
            {
                _weaponSelect = 0;
                _cutlass.SetActive(false);
                _pistol.SetActive(false);
                _musket.SetActive(false);
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
            
        }*/
        
    }
}
