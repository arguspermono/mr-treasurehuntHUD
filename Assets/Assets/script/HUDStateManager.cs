using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDStateManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelUtamaReady;
    public GameObject panelPlacementLocation;
    public GameObject fallbackError;
    public GameObject fallbackLoading;
    [Header("Teks")]
    public TextMeshProUGUI textKodeBarang;
    public TextMeshProUGUI textStatus;
    public TextMeshProUGUI textNamaBarang;
    public TextMeshProUGUI textBerat;
    public TextMeshProUGUI textDimensi;
    public TextMeshProUGUI textTujuan;
    public TextMeshProUGUI textTimestamp;
    public TextMeshProUGUI textZonaRak;
    [Header("Tombol")]
    public GameObject buttonConfirm;
    public GameObject buttonUlangi;
    [Header("Controllers")]
    public NavigationController navigation;
    public BoundingBoxController boundingBox;
    public enum HUDState { READY, LOADING, ERROR }
    void Start() { SetState(HUDState.LOADING); }
    public void SetState(HUDState state)
    {
        panelUtamaReady.SetActive(false);
        panelPlacementLocation.SetActive(false);
        fallbackError.SetActive(false);
        fallbackLoading.SetActive(false);
        buttonConfirm.SetActive(false);
        buttonUlangi.SetActive(false);
        switch (state)
        {
            case HUDState.READY:
                panelUtamaReady.SetActive(true);
                panelPlacementLocation.SetActive(true);
                buttonConfirm.SetActive(true);
                textStatus.text = "STATUS: READY";
                textStatus.color = new Color32(39, 174, 96, 255);
                boundingBox.SetState("READY");
                break;
            case HUDState.LOADING:
                panelUtamaReady.SetActive(true);
                fallbackLoading.SetActive(true);
                textStatus.text = "STATUS: LOADING...";
                textStatus.color = new Color32(243, 156, 18, 255);
                boundingBox.SetState("LOADING");
                navigation.SetAktif(false);
                break;
            case HUDState.ERROR:
                fallbackError.SetActive(true);
                buttonUlangi.SetActive(true);
                boundingBox.SetState("ERROR");
                navigation.SetAktif(false);
                break;
        }
    }
    public void SetDataBarang(string kode, string nama,
        string berat, string dimensi, string tujuan, string zona)
    {
        textKodeBarang.text = kode;
        textNamaBarang.text = nama;
        textBerat.text = berat;
        textDimensi.text = dimensi;
        textTujuan.text = tujuan;
        textZonaRak.text = zona;
        textTimestamp.text = System.DateTime.Now.ToString("HH:mm:ss");
        navigation.SetTujuan(zona);
        SetState(HUDState.READY);
    }
}
