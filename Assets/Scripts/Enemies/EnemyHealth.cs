using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth = 100;

    private int currentHealth;

    public GameObject collectiblePrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("El enemigo recibió daño");

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

        private void Die() {

        Debug.Log("ENEMIGO MUERTO");

        if (collectiblePrefab != null) {

            Debug.Log("Generando moneda");

            Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
