using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SystemOfExtras
{
    public class IngredientsInventory : MonoBehaviour , IIngredientsInventory
    {
        [SerializeField] private PlayerExtended player;
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject ingredientsHoja, panelIngredients;
        [SerializeField] private List<string> ingredients;
        [SerializeField] private IngredientImage ingredientImageTemplate;
        private List<IngredientImage> _ingredients;
        [SerializeField] private float moveInY, animationDuration;
        private bool _ingredientsShowed = true, _movingHojaIngredients;

        private void Awake()
        {
            player.OnItemPressed += OnClickFromPlayer;
            _ingredients = new List<IngredientImage>();
        }

        private void Start()
        {
            foreach (var ingredient in ingredients)
            {
                var ingredientInstance = Instantiate(ingredientImageTemplate, panelIngredients.transform);
                ingredientInstance.Configure(ingredient);
                _ingredients.Add(ingredientInstance);
            }
        }

        private void OnClickFromPlayer()
        {
            Debug.Log("simn, hizo click");
            var ingredient = RayCastHelper.CompareIngredient(mainCamera);
            if (ingredient) ServiceLocator.Instance.GetService<IIngredientsInventory>().CrossOutIngredient(ingredient.Id);
        }

        public void CrossOutIngredient(string id)
        {
            foreach (var ingredient in _ingredients)
            {
                if (ingredient.ID == id)
                {
                    ingredient.CrossOut();
                }
            }
        }

        private void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame) ShowOrHideIngredients();
        }

        private void ShowOrHideIngredients()
        {
            if (!_movingHojaIngredients)
            {
                if (_ingredientsShowed)
                {
                    _ingredientsShowed = false;
                    _movingHojaIngredients = true;
                    var sequence = DOTween.Sequence();
                    var localPosition = ingredientsHoja.transform.localPosition;
                    sequence.Insert(0,
                        ingredientsHoja.transform.DOLocalMove(
                            new Vector3(localPosition.x, localPosition.y - moveInY, localPosition.z), animationDuration).SetEase(Ease.InBack));
                    sequence.onComplete = () =>
                    {
                        _movingHojaIngredients = false;
                    };
                }
                else
                {
                    _ingredientsShowed = true;
                    _movingHojaIngredients = true;
                    var sequence = DOTween.Sequence();
                    var localPosition = ingredientsHoja.transform.localPosition;
                    sequence.Insert(0,
                        ingredientsHoja.transform.DOLocalMove(
                            new Vector3(localPosition.x, localPosition.y + moveInY, localPosition.z), animationDuration).SetEase(Ease.OutBack));
                    sequence.onComplete = () =>
                    {
                        _movingHojaIngredients = false;
                    };
                }
            }
        }
    }
}