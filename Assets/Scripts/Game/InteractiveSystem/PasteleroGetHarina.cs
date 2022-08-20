using SystemOfExtras;
using UnityEngine;

public class PasteleroGetHarina : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
    }
}