using UnityEngine;

namespace CultureFMP
{
    public class Flintlock_Musket : MonoBehaviour
    {
        [SerializeField] private float fireRate;
        private float _fireCooldown;
        private int _currentAmmo;
        [SerializeField] private int ammoCap;

        Weapon_Raycasts ray;

        private void Start()
        {
            _currentAmmo = ammoCap;
            ray = GetComponent<Weapon_Raycasts>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_currentAmmo > 0 && fireRate < _fireCooldown)
                {
                    _currentAmmo--;
                    _fireCooldown = 0f;
                    ray.Shoot();
                    Debug.Log("Pew" + _currentAmmo); //Sound and animation trigger for shot should be here
                }
                else
                {
                    Debug.Log("No Shot"); //Sound trigger for no ammo sound should be here
                }
            }

            if (Input.GetMouseButton(1))
            {
                //Animation for aiming down the sight
            }

            _fireCooldown = _fireCooldown + Time.deltaTime;
        }

        public void Reload()
        {
            _currentAmmo = ammoCap;
        }
    }
}
