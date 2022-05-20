using UnityEngine;

public class Cutlass : MonoBehaviour
{
    private Collider _myCol;
    public Animator anim;

    private void Start()
    {
        _myCol = gameObject.GetComponent<Collider>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("swipe");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
/*        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
        }*/

        if (other.transform.GetComponent<CultureFMP.Manager.Health_Manager>() != null)
        {
            var enemyHealth = GameObject.Find(other.transform.name).GetComponent<CultureFMP.Manager.Health_Manager>();
            enemyHealth.currentHealth -= 33.4f;
            Debug.Log(enemyHealth.currentHealth);
        }
    }
}
