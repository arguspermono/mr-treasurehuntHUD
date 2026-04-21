using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public enum Arah { STRAIGHT, LEFT, RIGHT, UTURN, ENDPOINT }
    [Header("Model Panah")]
    public GameObject arrowStraight;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject arrowUturn;
    public GameObject arrowEndpoint;
    [Header("Zona Tujuan")]
    public Transform zonaA;
    public Transform zonaB;
    [Header("Zona Visual")]
    public GameObject kotakZonaA;
    public GameObject kotakZonaB;
    public Material materialZonaDefault;
    public Material materialZonaAktif;
    private Transform targetZona;
    private GameObject targetKotak;
    private GameObject panahAktif;
    void Start() { SetAktif(false); }
    public void SetAktif(bool aktif)
    {
        NonaktifkanSemua();
        if (!aktif) return;
        // Default mulai dengan straight
        TampilPanah(Arah.STRAIGHT);
    }
    public void SetTujuan(string zona)
    {
        kotakZonaA.SetActive(false);
        kotakZonaB.SetActive(false);
        if (zona == "A")
        {
            targetZona = zonaA;
            targetKotak = kotakZonaA;
        }
        else
        {
            targetZona = zonaB;
            targetKotak = kotakZonaB;
        }
        targetKotak.SetActive(true);
        targetKotak.GetComponent<Renderer>().material
            = materialZonaDefault;
        TampilPanah(Arah.STRAIGHT);
    }
    // Dipanggil oleh programmer saat instruksi navigasi berubah
    public void TampilPanah(Arah arah)
    {
        NonaktifkanSemua();
        switch (arah)
        {
            case Arah.STRAIGHT: panahAktif = arrowStraight; break;
            case Arah.LEFT: panahAktif = arrowLeft; break;
            case Arah.RIGHT: panahAktif = arrowRight; break;
            case Arah.UTURN: panahAktif = arrowUturn; break;
            case Arah.ENDPOINT: panahAktif = arrowEndpoint; break;
        }
        if (panahAktif != null)
            panahAktif.SetActive(true);
    }
    void NonaktifkanSemua()
    {
        arrowStraight.SetActive(false);
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
        arrowUturn.SetActive(false);
        arrowEndpoint.SetActive(false);
    }
    // Dipanggil saat worker masuk kotak zona
    public void OnZonaTercapai()
    {
        TampilPanah(Arah.ENDPOINT);
        targetKotak.GetComponent<Renderer>().material
            = materialZonaAktif;
    }
}
