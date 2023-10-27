using System;
using UnityEngine;

public class ShowChildrenWentStayInsideOfMall : MonoBehaviour
{
    [SerializeField] private GameObject[] children;

    private void Start()
    {
        foreach (var child in children)
        {
            child.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var child in children)
            {
                child.SetActive(true);
            }
        }
    }
}