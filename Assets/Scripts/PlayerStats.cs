using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deadMenuCanvas;
    public int Coins;
    public AudioSource a;

    public AudioClip hurt;

    public event System.Action<int, int> OnHealthChanged;

    private void Start()
    {
        a = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

        private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spike")){
            TakeDamage(10);
            a.PlayOneShot(hurt, 1.0f);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(15);
            a.PlayOneShot(hurt, 1.0f);
        }
    }

    void Die()
    {
        Time.timeScale = 0f;
        deadMenuCanvas.SetActive(true);
    }

    void UpdateHealthUI()
    {
        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
    }
}
