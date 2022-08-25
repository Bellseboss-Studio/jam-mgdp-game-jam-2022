using SystemOfExtras;
using UnityEngine;

public class EntregarJugete : InteractiveObjectFather
{
    [SerializeField] private MisionJugete mision;
    [SerializeField] private Item billete;
    protected override void ActionEventCustom()
    {
        var removeItemById = ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(mision.Toy.Id);
        mision.AddToys(removeItemById);
        if (mision.HasCompletedMission())
        {
            ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(billete);
        }
    }
}