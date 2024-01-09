using SystemOfExtras;
using UnityEngine;

public class ChildrenWasSteal : InteractiveObjectFather
{
    [SerializeField] private string ingredientId;
    protected override void ActionEventCustom()
    {
        ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(ingredientId);
    }
}