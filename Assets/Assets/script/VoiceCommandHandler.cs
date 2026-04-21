using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class VoiceCommandHandler : MonoBehaviour, IMixedRealitySpeechHandler
{
    public HUDStateManager hudManager;
    public void OnSpeechKeywordRecognized(
        SpeechEventData eventData)
    {
        switch (eventData.Command.Keyword.ToLower())
        {
            case "pindai inventaris":
                hudManager.SetState(
                    HUDStateManager.HUDState.LOADING);
                Invoke("LoadDataDummy", 2f);
                break;
            case "konfirmasi":
                hudManager.SetState(
                    HUDStateManager.HUDState.READY);
                break;
            case "ulangi":
                hudManager.SetState(
                    HUDStateManager.HUDState.LOADING);
                Invoke("LoadDataDummy", 2f);
                break;
        }
    }
    void LoadDataDummy()
    {
        hudManager.SetDataBarang(
            "UNIT P-882", "Laptop Macbook",
            "2.5 kg", "40 x 30 x 25 cm",
            "Surabaya", "A");
    }
}
