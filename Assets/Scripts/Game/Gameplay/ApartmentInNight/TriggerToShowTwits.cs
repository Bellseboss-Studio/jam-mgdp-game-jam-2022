using UnityEngine;

public class TriggerToShowTwits : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("ShowTwits");
        }
    }
}
