using SystemOfExtras;
using UnityEngine;

public class AncianaRobarCollar : InteractiveObjectFather
{
    [SerializeField] private Item collar;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(collar));
        ServiceLocator.Instance.GetService<IMoralService>().SetIsBad(true);
    }
}