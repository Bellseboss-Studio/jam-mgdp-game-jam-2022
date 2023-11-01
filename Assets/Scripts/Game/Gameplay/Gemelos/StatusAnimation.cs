using UnityEngine;

public class StatusAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetTrigger("idle");
    }
}