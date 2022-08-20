using SystemOfExtras;
using UnityEngine;

public class TraficanteGetBillete : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(billete));
    }
}