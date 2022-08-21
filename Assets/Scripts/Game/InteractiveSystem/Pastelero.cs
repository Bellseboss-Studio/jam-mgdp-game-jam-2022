using SystemOfExtras;
using UnityEngine;

public class Pastelero : InteractiveObject
{
    
    [SerializeField] private Dialog misionCompletada;
    [SerializeField] private Item mineral;
    public override void OnMouseDown()
    {
        if (CambioDialogo)
        {
            if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(mineral.Id))
            {
                SetDialogo(misionCompletada);
                ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(mineral.Id);
            }
        }

        base.OnMouseDown();
    }
}