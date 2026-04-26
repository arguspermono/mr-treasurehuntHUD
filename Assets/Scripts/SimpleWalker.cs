using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWalker : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Tanpa perlu klik kanan, langsung tes pakai panah atau WASD
        float moveX = Input.GetAxis("Horizontal"); // A, D atau Panah Kiri, Kanan
        float moveZ = Input.GetAxis("Vertical");   // W, S atau Panah Atas, Bawah

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.position += move * speed * Time.deltaTime;

        if (move != Vector3.zero)
        {
            Debug.Log("Sistem Input Berhasil Membaca: " + move);
        }
    }
}