using SystemOfExtras;
using UnityEngine;

public class Traficante : InteractiveObject
{
    [SerializeField] private Dialog inventoryFull;
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
        base.OnMouseDown();
    }
}