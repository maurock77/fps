using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText;

    void Start() {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateUI();

        if (currentHealth <= 0)
        {
            RestartLevel();
        }
    }

    void UpdateUI() {
        if (healthText != null) {
            healthText.text = "Vida: " + currentHealth;
        }
    }

    void RestartLevel() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
