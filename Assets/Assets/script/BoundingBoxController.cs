using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBoxController : MonoBehaviour
{
    public Material materialReady;
    public Material materialLoading;
    public Material materialError;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        SetState("READY");
    }

    public void SetState(string state)
    {
        if (state == "READY") rend.material = materialReady;
        else if (state == "LOADING") rend.material = materialLoading;
        else if (state == "ERROR") rend.material = materialError;
    }
}
