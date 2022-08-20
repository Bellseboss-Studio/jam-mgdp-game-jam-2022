using SystemOfExtras;
using UnityEngine;

public class HueveraGetLlavesBodega : InteractiveObjectFather
{
    [SerializeField] private Item llavesBodega;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(llavesBodega));
    }
}