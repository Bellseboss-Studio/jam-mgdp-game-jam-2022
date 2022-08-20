using SystemOfExtras;
using UnityEngine;

public class Traficante : InteractiveObject
{
    [SerializeField] private Dialog inventoryFull, misionCompletada;
    [SerializeField] private Item collar;
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
            if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(collar.Id))
            {
                SetDialogo(misionCompletada);
                ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(collar.Id);
            }
        }
        base.OnMouseDown();
    }
}