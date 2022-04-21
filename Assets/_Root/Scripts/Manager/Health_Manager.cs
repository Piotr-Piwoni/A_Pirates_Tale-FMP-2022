using UnityEngine;
using UnityEngine.UI;

namespace CultureFMP.Manager
{
    public class Health_Manager : MonoBehaviour
    {
        [Header("Health Manager")]
        [SerializeField] [Tooltip("This sets the max health for the player.")] private float maxHealth = 100.0f;
        private float _currentHealth;
        [Header("Regen Manager")]
        [SerializeField] [Tooltip("This sets the amoune of time before regeneration begins.")] private float regenTime = 5.0f;
        private float _regenCooldown;
        [SerializeField] [Tooltip("This sets how fast the entity regenerates.")] private float regenMultiplier = 1.0f;
        [Header("Slider")]
        [SerializeField] [Tooltip("This is where the slider is attatched.")] private Slider healthSlider;

        void Start()
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0.0f, maxHealth);
            _currentHealth = maxHealth;

            healthSlider.minValue = 0.0f;
            healthSlider.maxValue = maxHealth;
        }

        void Update()
        {
            if (_currentHealth <= 0.0f)
            {
                Afterlife();
            }

            if (Input.GetKeyDown("t"))
            {
                _currentHealth = _currentHealth - 40.0f;
                Debug.Log(_currentHealth);
                _regenCooldown = 0.0f;
            }

            _regenCooldown += Time.deltaTime;
            if (_regenCooldown >= regenTime && _currentHealth < maxHealth)
            {
                _currentHealth += Time.deltaTime * regenMultiplier;
                Debug.Log(_currentHealth);
            }

            healthSlider.value = _currentHealth;
        }

        private void Afterlife()
        {
            if (gameObject.CompareTag("Player"))
            {
                Respawn();
                Debug.Log("respawned");
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Respawn()
        {
            // code for respawn
        }
    }
}