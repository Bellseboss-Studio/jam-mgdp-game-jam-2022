using SystemOfExtras;
using UnityEngine;

public class DarCaramelo : InteractiveObjectFather
{
    [SerializeField] private Item caramelo;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(caramelo.Id);
    }
}