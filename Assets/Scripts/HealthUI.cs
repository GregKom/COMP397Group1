using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    public Scrollbar healthBar;

    private void Start()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.OnHealthChanged += UpdateHealthUI;
            UpdateHealthUI(playerStats.maxHealth, playerStats.currentHealth);
        }
    }

    void UpdateHealthUI(int maxHealth, int currentHealth)
    {
        healthText.text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
        float healthPercent = (float)currentHealth / maxHealth;
        healthBar.size = healthPercent;
    }
}
