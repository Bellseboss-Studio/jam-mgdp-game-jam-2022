using System;
using UnityEngine;

public class TriggerToChildrenRunToForwardPlayer : MonoBehaviour{
    [SerializeField] private Children children;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            children.RunToForwardPlayer();
        }
    }
}