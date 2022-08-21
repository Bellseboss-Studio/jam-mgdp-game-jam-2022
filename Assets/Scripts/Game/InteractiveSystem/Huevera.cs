using SystemOfExtras;
using UnityEngine;

public class Huevera : InteractiveObject
{
    [SerializeField] private Dialog inventoryFull, misionCompletada;
    [SerializeField] private Item billete, mercancia;
    public override void OnMouseDown()
    {
        if (!CambioDialogo)
        {
            if (!ServiceLocator.Instance.GetService<IItemsInventory>().HasSpace())
            {
                idDialog = inventoryFull;
            }
            else
            {
                idDialog = OriginalDialog;
            }
        }
        else
        {
            if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(billete.Id) &&
                ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(mercancia.Id))
            {
                SetDialogo(misionCompletada);
                ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
                ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(mercancia.Id);
            }
        }
        base.OnMouseDown();
    }
}