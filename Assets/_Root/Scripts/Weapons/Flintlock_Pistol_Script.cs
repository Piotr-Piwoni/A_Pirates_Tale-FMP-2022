using UnityEngine;

public class Flintlock_Pistol_Script : MonoBehaviour
{
    [SerializeField] private float fireRate;
    private float _fireCooldown;
    private int _currentAmmo;
    [SerializeField] private int ammoCap;


    private void Start()
    {
        _currentAmmo = ammoCap;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentAmmo > 0 && fireRate < _fireCooldown)
            {
                _currentAmmo--;
                _fireCooldown = 0f;
                Shoot();
                Debug.Log("Pew" + _currentAmmo); //Sound and animation trigger for shot should be here
            }
            else
            {
                Debug.Log("No Shot"); //Sound trigger for no ammo sound should be here
            }
        }
        _fireCooldown = _fireCooldown + Time.deltaTime;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10000;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit)) // Shoots out a raycast that gathers information on what it hits
        {
            Debug.Log(hit.transform.name); // This will show the name of the object that the raycast hits in the console
        }
    }

    public void Reload()
    {
        _currentAmmo = ammoCap;
    }
}