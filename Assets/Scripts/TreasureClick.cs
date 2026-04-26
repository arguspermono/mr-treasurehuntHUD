using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ganti UnityEngine.UI menjadi TMPro

public class TreasureClick : MonoBehaviour
{
    public GameObject CollectibleEffect;
    public TMP_Text CountTreasureText; // Ganti 'Text' menjadi 'TMP_Text'
    public static int CountTreasure = 0;

    void Start()
    {
        UpdateUI();
    }

    private void OnMouseDown()
    {
        Debug.Log("Harta diambil!");

        CountTreasure++;
        UpdateUI();

        if (CollectibleEffect != null)
        {
            CollectibleEffect.SetActive(true);
        }

        // Ini yang bikin TreasureItem hilang saat diklik
        gameObject.SetActive(false);
    }

    void UpdateUI()
    {
        if (CountTreasureText != null)
        {
            CountTreasureText.text = "Harta: " + CountTreasure;
        }
    }
}