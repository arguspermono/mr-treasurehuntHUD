using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizDisplayManager : MonoBehaviour
{
    [Header("Data")]
    public TreasureItem currentItem; // Item yang sedang aktif di kuis ini
    public InventoryManager inventoryManager;

    [Header("UI References")]
    public TextMeshProUGUI questionText;
    public Button[] answerButtons; // Pastikan ada 4 tombol di inspector
    public GameObject quizPanel; // Panel kuis untuk di munculkan/sembunyikan

    void Start()
    {
        if (currentItem != null)
        {
            DisplayQuiz();
        }
    }

    public void DisplayQuiz()
    {
        quizPanel.SetActive(true);
        questionText.text = currentItem.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Reset listener agar tidak bertumpuk
            answerButtons[i].onClick.RemoveAllListeners();

            // Set teks jawaban
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentItem.answers[i];

            // Cek jawaban
            int index = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    void OnAnswerSelected(int index)
    {
        if (index == currentItem.correctAnswerIndex)
        {
            Debug.Log("Jawaban Benar!");
            inventoryManager.AddItem(currentItem);
            quizPanel.SetActive(false); // Sembunyikan kuis setelah berhasil
        }
        else
        {
            Debug.Log("Jawaban Salah, Coba Lagi!");
            // Tambahkan feedback visual (misal tombol berubah merah) di sini
        }
    }
}