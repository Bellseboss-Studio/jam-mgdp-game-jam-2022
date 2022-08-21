using SystemOfExtras;
using UnityEngine;

public class TraficanteGetBillete : InteractiveObjectFather
{
    [SerializeField] private Item billete, collar;
    [SerializeField] private string ingredientId;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IItemsInventory>().RemoveItemById(collar.Id);
        ServiceLocator.Instance.GetService<IItemsInventory>().SaveItem(Instantiate(billete));
        ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(ingredientId);
    }
}