using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarLaPuertaCuandoPlayerPase : MonoBehaviour
{
    [SerializeField] private PuertaInteractuable puerta;

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log($"Exit de {other.tag}");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Exit del player");
            puerta.CloseDoor();
        }
    }
}
