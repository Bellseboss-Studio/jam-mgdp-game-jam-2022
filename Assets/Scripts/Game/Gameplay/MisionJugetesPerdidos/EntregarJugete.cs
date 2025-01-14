using SystemOfExtras;
using UnityEngine;

public class EntregarJugete : InteractiveObjectFather
{
    [SerializeField] private MisionJugete mision;
    [SerializeField] private Item billete;
    [SerializeField] private Dialog dialogoAgradecimiento;
    protected override void ActionEventCustom()
    {
        var removeItemById = ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(mision.Toy.Id);
        mision.AddToys(removeItemById);
        if (mision.HasCompletedMission())
        {
            Debug.Log($"entrego el billete {billete.Id} {billete.name}");
            ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(billete);
            ServiceLocator.Instance.GetService<IStatesMissions>().MissionCompleted(IdMissions.JUGETE);
            if(dialogoAgradecimiento != null)
                mision.ConcatDialog(dialogoAgradecimiento);
        }
    }
}