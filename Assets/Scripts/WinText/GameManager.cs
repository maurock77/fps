using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject winText;

    private void Awake()
    {
        Instance = this;
        winText.SetActive(false);
    }

    public void FinishLevel()
    {
        winText.SetActive(true);
    }



}
