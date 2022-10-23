using SystemOfExtras;
using UnityEngine;

public class PuertaApartamentoLlaves : InteractiveObject
{
    [SerializeField] private Dialog dialogConBillete;
    [SerializeField] private Item billete;
    public override void OnMouseDown()
    {
        if (ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForId(billete.Id))
        {
            SetDialogo(dialogConBillete);
        }
        else
        {
            RestoreDialog();
        }
        base.OnMouseDown();
    }
}