using SystemOfExtras;
using UnityEngine;

public class Anciana : InteractiveObject
{
    [SerializeField] private Dialog inventoryFull, dialogConCaramelo, dialogoDrogada;
    [SerializeField] private Item caramelo;
    [SerializeField] private Animator animator;
    public override void OnMouseDown()
    {
        if (CambioDialogo)
        {
            if (!ServiceLocator.Instance.GetService<IItemsInventory>().HasSpace())
            {
                idDialog = inventoryFull;
            }
            else
            {
                idDialog = dialogoDrogada;
                animator.SetBool("drogada", true);
            }
        }
        else
        {
            if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(caramelo.Id))
            {
                SetDialogo(dialogConCaramelo);
            }
        }
        base.OnMouseDown();
    }
}