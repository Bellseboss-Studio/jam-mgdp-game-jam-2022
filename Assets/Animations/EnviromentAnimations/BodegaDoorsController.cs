using SystemOfExtras;
using UnityEngine;

public class BodegaDoorsController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Item _item;
    private void OnTriggerEnter(Collider other)
    {
        if (!ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(_item.Id)) return;
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open", false);
        }
    }
}