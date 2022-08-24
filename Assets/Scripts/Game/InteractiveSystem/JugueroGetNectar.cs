using SystemOfExtras;
using UnityEngine;

public class JugueroGetNectar : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    [SerializeField] private string nectarId;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
    }
}