using UnityEngine;

public class CheckForPlayerInCollider : MonoBehaviour
{
    public bool IsPlayerIn { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerIn = false;
        }
         
    }
}