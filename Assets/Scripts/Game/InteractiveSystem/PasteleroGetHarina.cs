using SystemOfExtras;
using UnityEngine;

public class PasteleroGetHarina : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    [SerializeField] private string harinaId;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
        ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(harinaId);
    }
}