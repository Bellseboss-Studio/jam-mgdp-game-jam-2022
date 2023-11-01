using SystemOfExtras;
using UnityEngine;

public class StealHarinaToPanadero : InteractiveObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnMouseDown();
        }
    }
}