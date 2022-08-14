using System;
using UnityEngine;

namespace SystemOfExtras
{
    public class Ingredient : InteractiveObjectFather
    {
        [SerializeField] private string id;

        public string Id => id;

        protected override void ActionEventCustom()
        {
            ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(id);
        }
    }
}