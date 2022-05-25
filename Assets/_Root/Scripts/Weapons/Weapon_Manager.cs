using CultureFMP.Manager;
using UnityEngine;

namespace CultureFMP
{
    public class Weapon_Manager : MonoBehaviour
    {
        private int _weaponSelect = 0;

        [SerializeField] private CameraManager cameraManager;
        [SerializeField] private GameObject targetADS;

        [SerializeField] private GameObject _cutlass;
        [SerializeField] private GameObject _pistol;

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

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _weaponSelect = 1;
                _cutlass.SetActive(true);
                _pistol.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _weaponSelect = 2;
                _cutlass.SetActive(false);
                _pistol.SetActive(true);
            }
            else if (Input.GetKeyDown("x"))
            {
                _weaponSelect = 0;
                _cutlass.SetActive(false);
                _pistol.SetActive(false);
            }
        }
    }
}
