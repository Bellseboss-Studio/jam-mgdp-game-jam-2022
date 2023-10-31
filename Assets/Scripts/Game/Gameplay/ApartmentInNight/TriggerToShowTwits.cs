using System;
using UnityEngine;

public class TriggerToShowTwits : MonoBehaviour
{
    [SerializeField] private Animator animator, animatorToEnable;
    [SerializeField] private GameObject objectToDisable, objectToEnable;

    private void Start()
    {
        objectToEnable.SetActive(false);
        objectToDisable.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("ShowTwits");
            objectToDisable.SetActive(false);
            objectToEnable.SetActive(true);
            animatorToEnable.SetTrigger("Enter");
            gameObject.SetActive(false);
        }
    }
}
