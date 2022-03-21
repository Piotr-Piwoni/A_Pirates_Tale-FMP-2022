using UnityEngine;

public class Flintlock_Pistol_Script : MonoBehaviour
{
    public float fireRate;
    private float fireCooldown;
    private int currentAmmo;
    public int ammoCap;

    Weapon_Raycasts ray;

    private void Start()
    {
        currentAmmo = ammoCap;
        ray = GetComponent<Weapon_Raycasts>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0 && fireRate < fireCooldown)
            {
                currentAmmo--;
                fireCooldown = 0f;
                ray.Shoot();
                Debug.Log("Pew" + currentAmmo); //Sound and animation trigger for shot should be here
            }
            else
            {
                Debug.Log("No Shot"); //Sound trigger for no ammo sound should be here
            }
        }
        fireCooldown = fireCooldown + Time.deltaTime;
    }

    public void Reload()
    {
        currentAmmo = ammoCap;
    }
}