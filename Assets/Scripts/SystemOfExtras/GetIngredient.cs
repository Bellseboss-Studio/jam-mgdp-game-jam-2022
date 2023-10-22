using UnityEngine;

namespace SystemOfExtras
{
    public class GetIngredient : Ingredient
    {
        [SerializeField] private float timeToDestroy = 0.5f;
        protected override void ActionEventCustom()
        {
            base.ActionEventCustom();
            Destroy(gameObject, timeToDestroy);
        }
    }
}