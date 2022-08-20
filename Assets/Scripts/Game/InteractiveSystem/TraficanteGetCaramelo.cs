using SystemOfExtras;
using UnityEngine;

public class TraficanteGetCaramelo : InteractiveObjectFather
{
    [SerializeField] private Item caramelo;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(caramelo));
    }
}