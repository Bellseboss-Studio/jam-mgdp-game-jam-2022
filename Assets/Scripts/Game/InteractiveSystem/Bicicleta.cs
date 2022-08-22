using SystemOfExtras;
using UnityEngine;

public class Bicicleta : InteractiveObject
{
    [SerializeField] private Dialog dialogConLlaves;
    [SerializeField] private Item llaves;
    public override void OnMouseDown()
    {
        if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(llaves.Id))
        {
            SetDialogo(dialogConLlaves);
        }
        else
        {
            RestoreDialog();
        }
        base.OnMouseDown();
    }
}