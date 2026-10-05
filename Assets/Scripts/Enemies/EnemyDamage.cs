using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;
    public float attackDistance = 2.5f;

    private float nextAttackTime;
    private Transform player;

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    void Update()
    {
        if (player == null)
            return;

        float distance =
            Vector3.Distance(transform.position,
                             player.position);

        Debug.Log("Distancia: " + distance);

        if (distance <= attackDistance &&
            Time.time >= nextAttackTime)
        {
            PlayerHealth health =
                player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);

                Debug.Log("Enemigo atacando");

                nextAttackTime =
                    Time.time + attackCooldown;

                Debug.Log("Daño aplicado");
            }
        }
    }
}