using UnityEngine;

public class Flintlock_Pistol_Script : MonoBehaviour
{
    [SerializeField] private float fireRate;
    private float _fireCooldown;
    private int _currentAmmo;
    [SerializeField] private int ammoCap;
    private LineRenderer lr;
    [SerializeField] private float lineSpeed;
    [SerializeField] private Transform _adsPOS;
    [SerializeField] private float _adsSpeed;

    private void Start()
    {
        _currentAmmo = ammoCap;
        lr = GetComponent<LineRenderer>();
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
                //Sound and animation trigger for shot should be here
            }
            else
            {
                //Sound trigger for no ammo sound should be here
            }
        }
        _fireCooldown = _fireCooldown + Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            //Vector3.Lerp(transform.position, _adsPOS.position, Time.deltaTime * _adsSpeed);
            transform.position= _adsPOS.position;
        }

        Vector3 forward = transform.TransformDirection(Vector3.left) * 10000;
        Debug.DrawRay(transform.position, forward, Color.green);

        Vector3 linePos = Vector3.Lerp(lr.GetPosition(0), lr.GetPosition(1), Time.deltaTime * lineSpeed);
        lr.SetPosition(0, linePos);
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, - gameObject.transform.right, out hit)) // Shoots out a raycast that gathers information on what it hits
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);

            if (hit.transform.GetComponent<CultureFMP.Manager.Health_Manager>() != null)
            {
                var enemyHealth = GameObject.Find(hit.transform.name).GetComponent<CultureFMP.Manager.Health_Manager>();
                enemyHealth.currentHealth -= 25.0f;
                Debug.Log(enemyHealth.currentHealth);
            }
        }
    }

    public void Reload()
    {
        _currentAmmo = ammoCap;
    }
}