using Game.Player;
using UnityEngine;

namespace SystemOfExtras
{
    public class IngredientsInventory : MonoBehaviour , IIngredientsInventory
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject panelIngredients;
        [SerializeField] private IngredientImage ingredientTemplate;

        private void Awake()
        {
            player.OnClickFromPlayer += OnClickFromPlayer;    
        }

        private void OnClickFromPlayer()
        {
            var ingredient = RayCastHelper.CompareIngredient(mainCamera);
            if (ingredient) ServiceLocator.Instance.GetService<IIngredientsInventory>().AddIngredient(ingredient);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            var ingredientImage = Instantiate(ingredientTemplate, panelIngredients.transform);
            ingredientImage.Configure(ingredient.Sprite, ingredient.Description);
        }
    }
}