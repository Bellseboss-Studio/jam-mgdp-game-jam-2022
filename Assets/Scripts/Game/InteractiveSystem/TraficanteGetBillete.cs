using SystemOfExtras;
using UnityEngine;

public class TraficanteGetBillete : InteractiveObjectFather
{
    [SerializeField] private Item billete;
    [SerializeField] private string ingredientId;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(billete.Id);
        ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(ingredientId);
    }
}