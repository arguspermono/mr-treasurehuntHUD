using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public NavigationController navigation;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
            navigation.OnZonaTercapai();
    }
}
