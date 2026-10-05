using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRoja : MonoBehaviour {

    public int value = 1;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.FinishLevel();
            Destroy(gameObject);
        }
    }

}
