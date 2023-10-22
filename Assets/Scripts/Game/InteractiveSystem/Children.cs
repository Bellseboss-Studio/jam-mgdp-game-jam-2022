using SystemOfExtras;
using UnityEngine;

public class Children : InteractiveObject
{
    [SerializeField] private Dialog youCantHaveTheMoney;
    [SerializeField] private Item billete;
    public override void OnMouseDown()
    {
        if (!CambioDialogo)
        {
            idDialog = !ServiceLocator.Instance.GetService<IItemsInventory>().SearchItemForIdAndCount(billete.Id, 1) ? youCantHaveTheMoney : OriginalDialog;   
        }
        base.OnMouseDown();
    }
}