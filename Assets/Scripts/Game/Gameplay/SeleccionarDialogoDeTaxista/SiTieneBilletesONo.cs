using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiTieneBilletesONo : MonoBehaviour
{
    [SerializeField] private InteractiveObject interactive;
    [SerializeField] private Dialog queSi, qieNo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //interactive.SetDialogo();  
        }
    }
}
