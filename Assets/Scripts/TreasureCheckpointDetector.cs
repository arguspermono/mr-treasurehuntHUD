using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCheckpointDetector : MonoBehaviour
{
    public GameObject TreasureQuiz;

    // Muncul pas masuk zona
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (TreasureQuiz != null)
            {
                TreasureQuiz.SetActive(true);
                Debug.Log("Hai! Apakah kamu mencari harta karun? Selesaikan dulu quiz ini ya!!");
            }
        }
    }

    // Hilang pas keluar/mundur dari zona
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (TreasureQuiz != null)
            {
                TreasureQuiz.SetActive(false); // Mematikan centang objek (jadi gaib lagi)
                Debug.Log("Anda keluar zona! Quiz kami sembunyikan kembali.");
            }
        }
    }
}