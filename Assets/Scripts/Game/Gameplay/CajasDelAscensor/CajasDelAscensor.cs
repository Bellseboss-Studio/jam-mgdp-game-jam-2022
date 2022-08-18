
using UnityEngine;

public class CajasDelAscensor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider collider;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApllyAction();
        }
    }

    public void ApllyAction()
    {
        animator.SetTrigger("caer");
        collider.isTrigger = false;
    }
}