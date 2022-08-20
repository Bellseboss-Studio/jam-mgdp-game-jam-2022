using SystemOfExtras;
using UnityEngine;

public class TraficanteGetBillete : InteractiveObjectFather
{
    [SerializeField] private Item billete, collar;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(collar.Id);
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(billete));
    }
}